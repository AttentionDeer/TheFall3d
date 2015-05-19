using UnityEngine;
using System.Collections;

public class Devour : MonoBehaviour {

	public ObjectLibrary SendToCubes;
	public ObjectLibrary SendToBonuses;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter( Collider other)
	{
		int MyID = other.gameObject.GetComponent<ResetState>().ID;
		other.gameObject.GetComponent<ResetState>().DeactivateObject();
		if( MyID == 0)
			SendToCubes.StoreObject(other.gameObject);
		if( MyID == 1)
			SendToBonuses.StoreObject(other.gameObject);
	}
}
