using UnityEngine;
using System.Collections;

public class Propulsion : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate()
	{
		Vector3 temp = gameObject.GetComponent<Rigidbody>().velocity;
		temp = new Vector3 (temp.x, -10, temp.z);
		this.gameObject.GetComponent<Rigidbody>().velocity = temp;
	}
}
