using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {

	public ObjectLibrary EntitySource;
	public ObjectLibrary BonusSource;

	private float Depth = 20f;
	private float Interval = 0.12f;
	//protected float Speed = 10f;
	
	private int CorridorWidth = 9;
	private int CorridorHeight = 9;
	private float CorridorSpacing = 1.08f;

	private float timer = 0f;

	private float SurpriseTime = 10;
	private float countdown = 0f;

	private Vector3 position = new Vector3(0,0,0);
	private Vector3 offset = new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		countdown += Time.deltaTime;

		if(timer >= Interval)
		{
			timer = 0;

			GenerateLayer();
		}

		if (countdown >= SurpriseTime)
		{
			countdown = 0;
			SurpriseTime = Random.Range(4, 12);

			RandomizeParameters();
		}
	}

	void GenerateLayer ()
	{
		position = position + offset;
		float StartingWidth = (CorridorWidth-1)*CorridorSpacing/2;
		float StartingHeight = (CorridorHeight-1)*CorridorSpacing/2;

		for(int i = 0; i < CorridorWidth; i++)
		{
			GenerateBlock( new Vector3( -StartingWidth + i * CorridorSpacing, Depth, StartingHeight) +position );
			GenerateBlock( new Vector3( -StartingWidth + i * CorridorSpacing, Depth, -StartingHeight) +position );
		}

		for(int i = 1; i < CorridorHeight-1; i++)
		{
			GenerateBlock( new Vector3( StartingWidth, Depth, -StartingHeight + i * CorridorSpacing) +position );
			GenerateBlock( new Vector3( -StartingWidth, Depth, -StartingHeight + i * CorridorSpacing) +position );
		}

		int points = Random.Range(0, 7) - 3;

		if( points > 0 )
		{
			for(int i = 0; i < points; i++)
			{
				GenerateBlock( 
				            new Vector3(
								Random.Range(-StartingWidth+CorridorSpacing, StartingWidth-CorridorSpacing), 
				            	Depth, 
				            	Random.Range(-StartingHeight+CorridorSpacing, StartingHeight-CorridorSpacing)
							)
							+position,
				              1 );
			}
		}


	}

	void GenerateBlock (Vector3 atPosition, int type = 0)
	{
		GameObject temp;
		if(type == 1)
			temp = BonusSource.GiveObject();
		else
			temp = EntitySource.GiveObject();

		temp.transform.position = atPosition;
	}

	void RandomizeParameters()
	{
		//float RandomSeed = Random.Range(0f, 1f);
		if( Random.Range(0f, 1f) < 0.50f )
		{
			CorridorWidth = Random.Range(CorridorWidth-2, CorridorWidth+2);
			CorridorHeight = Random.Range(CorridorHeight-2, CorridorHeight+2);
			if(CorridorWidth < 6)
				CorridorWidth = 6;
			if(CorridorHeight < 6)
				CorridorHeight = 6;

			if(CorridorWidth > 12)
				CorridorWidth = 12;
			if(CorridorHeight > 12)
				CorridorHeight = 12;
		}

		if( Random.Range(0f, 1f) < 0.25f )
		{
			CorridorSpacing = Random.Range(CorridorSpacing-0.25f, CorridorSpacing+0.25f);

			if(CorridorSpacing < 1.08f)
				CorridorSpacing = 1.08f;
			
			if(CorridorSpacing > 1.5f)
				CorridorSpacing = 1.5f;

		}

		if( Random.Range(0f, 1f) > 0.75f )
		{
			offset = new Vector3( Random.Range(-0.45f, 0.45f), 0, Random.Range(-0.45f, 0.45f) );
		}
		else
			offset = new Vector3 (0, 0, 0);
	}

}
