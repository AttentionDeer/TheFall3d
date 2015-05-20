using UnityEngine;
using System.Collections;

public class Rotation : MonoBehaviour {
	public float speed = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround (transform.position, Vector3.up, Time.deltaTime * speed);
	}
}
