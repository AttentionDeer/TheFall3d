using UnityEngine;
using System.Collections;

public class ProceduralCorridor : MonoBehaviour {

	//public
	public Vector3[] PreviousLayer;
	public Vector3[] CurrentLayer;
	private GameObject ShapeHolder;
	// Use this for initialization
	void Start ()
	{
		if(PreviousLayer.Length > 0 )
			GenerateLayer (PreviousLayer.Length, PreviousLayer);
		else
			GenerateLayer (8);
	}


	void GenerateLayer(int ofSegments = 4, Vector3[] conformTo = null)
	{
		Mesh mesh = new Mesh();
		Vector3[] verticesTop;
		Vector3[] verticesBottom;
		if (conformTo != null)
			verticesTop = conformTo;
		else
			verticesTop = GenerateOutline (ofSegments, -0.5f);

		verticesBottom = GenerateOutline (ofSegments, 0.5f);

		int[] triangles = GenerateTriangles (ofSegments);

		CurrentLayer = verticesBottom;

		Vector3[] totalVertices = new Vector3[verticesTop.Length + verticesBottom.Length];
		for (int i = 0; i < verticesTop.Length; i++)
			totalVertices [i] = verticesTop [i];
		for (int i = 0; i < verticesBottom.Length; i++)
			totalVertices [verticesTop.Length+i] = verticesBottom [i];
		
		mesh.vertices = totalVertices;
		Debug.Log (mesh.vertices.Length);
		mesh.triangles = triangles;
		mesh.uv = GenerateUVmap (mesh.vertices.Length/2);

		GetComponent<MeshFilter>().mesh = mesh;
		GetComponent<MeshCollider> ().sharedMesh = mesh;

	}

	// Update is called once per frame

	Vector3[] GenerateOutline(int sections = 4, float height = 0, float jitter = 0.1f)
	{
		Vector3[] newOutline = new Vector3[sections*4];
		//Debug.Log ("newOutline length is = " + newOutline.Length);

		float sampleOffset = 0;

		for (int i = 0; i < sections; i++)
		{
			newOutline[i] = 			new Vector3(-0.5f+sampleOffset, height ,-0.5f +Random.Range(-jitter, jitter) );
			newOutline[i+sections] = 	new Vector3(0.5f +Random.Range(-jitter, jitter), height, -0.5f+sampleOffset);

			newOutline[i+sections*2] =	new Vector3(0.5f-sampleOffset, height ,0.5f +Random.Range(-jitter, jitter) );
			newOutline[i+sections*3] = 	new Vector3(-0.5f +Random.Range(-jitter, jitter), height, 0.5f-sampleOffset);
			if( i == sections-1)
				sampleOffset = 1;
			else
				sampleOffset += 1.0f/sections +Random.Range(-jitter, jitter);
		}

		return newOutline;
	}

	int[] GenerateTriangles(int sections)
	{
		// выделить место под треугольники
		int[] newTriangles = new int[3*2*4*sections];

		int j = 0;
		for(int i = 0; i < sections*4; i++)
		{
			// создать все треульники с двумя точками на нижней границе и одной на верхней
			newTriangles[j] = i;
			newTriangles[j+1] = i+1;
			if(i == sections*4-1) // wrap around when out of index bounds
				newTriangles[j+1] = 0;
			newTriangles[j+2] = sections*4 + i;

			j+=3;
			// создать остальные треугольники
			newTriangles[j+2] = sections*4 +i;
			newTriangles[j+1] = sections*4 +i+1;
			newTriangles[j] = i+1;
			if(i == sections*4-1) // wrap around when out of index bounds
			{
				newTriangles[j+1] = sections*4;
				newTriangles[j] = 0;
			}
			j+=3;
		}

		return newTriangles;
	}

	Vector2[] GenerateUVmap(int vertices)
	{
		Vector2[] uvs = new Vector2[2*vertices];
		Debug.Log (uvs.Length);
		bool step = true;
		//map the top of sector
		for(int i = 0; i < vertices; i++)
		{
			if( step)
			{
				uvs[i] = new Vector2(0,0);
				uvs[i+vertices] = new Vector2(0,1);
			}
			else
			{
				uvs[i] = new Vector2(1,0);
				uvs[i+vertices] = new Vector2(1,1);
			}
			step = !step;
		}
		return uvs;
	}
}
