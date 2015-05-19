using UnityEngine;
using System.Collections;

public class ObjectLibrary : MonoBehaviour {

	// назначение - создать запас объектов, сохранять ненужные, выдавать из запаса новые вместо создания

	public GameObject Template;
	protected ArrayList ObjectArray;

	public int GeneratedCount = 0;
	public int ActiveCount = 0;
	public int StoredCount = 0;
	// Use this for initialization
	void Start () {
		ObjectArray = new ArrayList();
	}
	
	// Update is called once per frame
	void Update () {
	}



	public void StoreObject( GameObject Unused )
	{
		Unused.GetComponent<ResetState>().DeactivateObject();
		ObjectArray.Add( Unused );
		StoredCount++;
		ActiveCount--;
	}

	public void GenerateMore(int amount)
	{
		GameObject temp;
		for(int i = 0; i < amount; i++)
		{
			temp = (GameObject) Instantiate (Template, new Vector3 (0,0,0) , Quaternion.identity);
			temp.GetComponent<ResetState>().DeactivateObject();
			ObjectArray.Add(temp);
			GeneratedCount++;
		}
	}

	public GameObject GiveObject()
	{
		GameObject temp;
		if(ObjectArray.Count < 1)
		{
			GenerateMore(1);
			StoredCount++;
		}
		temp = (GameObject) ObjectArray[ObjectArray.Count-1];
		ObjectArray[ObjectArray.Count-1] = null;
		ObjectArray.RemoveAt(ObjectArray.Count-1);
		temp.GetComponent<ResetState>().ActivateObject();
		ActiveCount++;
		StoredCount--;
		return temp;
	}
}
