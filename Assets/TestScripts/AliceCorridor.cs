using UnityEngine;
using System.Collections;

public class AliceCorridor : MonoBehaviour {

	//public
	public ArrayList PreviousLayer;
	private GameObject ShapeHolder;
	// Use this for initialization
	void Start () {
		//PreviousLayer = new ArrayList ();
		Mesh mesh = new Mesh();
		Vector3[] verticesTop = GenerateOutline (1, -0.5f);
		Vector3[] verticesBottom = GenerateOutline (1, 0.5f);
		int[] triangles = GenerateTriangles (verticesTop, verticesBottom);

		Vector3[] totalVertices = new Vector3[verticesTop.Length + verticesBottom.Length];
		for (int i = 0; i < verticesTop.Length; i++)
			totalVertices [i] = verticesTop [i];
		for (int i = 0; i < verticesBottom.Length; i++)
			totalVertices [verticesTop.Length+i] = verticesBottom [i];

		mesh.vertices = totalVertices;
		mesh.triangles = triangles;

		GetComponent<MeshFilter>().mesh = mesh;
		}

	
	// Update is called once per frame

	Vector3[] GenerateOutline(int sections = 4, float height = 0)
	{
		Vector3[] newOutline = new Vector3[(sections)*4];
		Debug.Log ("newOutline length is = " + newOutline.Length);

		float sampleOffset = 0;

		for (int i = 0; i < sections; i++)
		{
			newOutline[i] = 			new Vector3(sampleOffset, height ,Random.Range(-0.01f, 0.01f) );
            newOutline[i+sections] = 	new Vector3(Random.Range(-0.01f, 0.01f), height, sampleOffset);

			newOutline[i+sections*2] =	new Vector3(sampleOffset, height ,1+ Random.Range(-0.01f,0.01f) );
            newOutline[i+sections*3] = 	new Vector3(1+Random.Range(-0.01f,0.01f), height, sampleOffset);
			sampleOffset += 1.0f/sections;
		}

		return newOutline;
	}

	int[] GenerateTriangles(Vector3[] topLine, Vector3[] BottomLine)
	{
		int[] newTriangles = new int[3*(topLine.Length+BottomLine.Length)];
		int j = 0;
		for(int i = 0; i < topLine.Length; i++)
		{
			newTriangles[j] = i;
			newTriangles[j+1] = i+1;
			newTriangles[j+2] = topLine.Length + i;
			j+=3;
			//newTriangles[j] = BottomLine.Length +i+1;
			//newTriangles[j+1] = BottomLine.Length +i+2;
			//newTriangles[j+2] = i+1;
			//j+=3;
		}
		return newTriangles;
	}

	/*
	ArrayList GenerateBorder (int sections = 4, float height = 0)
	{
		ArrayList Border = new ArrayList();

		float x = 0;
		float y = 0;

		Border.Add ( new Vector3(x, height, y) );
		// create first wall
		for (int i = 0; i < sections; i++)
		{
			x += Random.Range(0.1, (1.0/sections) );
			Border.Add ( new Vector3(x, height, y) );
		}
		Border.Add ( new Vector3(1, height, 0) );

		return Border;
	}

	void GenerateLayer(float endWidth, float endHeight)
	{
		// create an object for the shape
		ShapeHolder = new GameObject();
		// generate the shape of it
		ArrayList topBorder = PreviousLayer;

		ArrayList bottomBorder = new ArrayList();
		// generate bottom layer from at least 4 points


		// apply shape to object

		// add the self-destruct script
		// save shape
		// release game object
	}*/

}
