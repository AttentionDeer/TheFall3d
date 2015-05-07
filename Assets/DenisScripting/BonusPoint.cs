using UnityEngine;
using System.Collections;

public class BonusPoint : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset()
	{
		gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		gameObject.transform.rotation = Quaternion.identity;
	}
}
