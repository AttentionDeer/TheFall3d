using UnityEngine;
using System.Collections;

public class ResetState : MonoBehaviour {

	public int ID;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ActivateObject()
	{
		//this.gameObject.SendMessage("Reset", SendMessageOptions.DontRequireReceiver);
		this.gameObject.active = true;
	}

	public void DeactivateObject()
	{
		this.gameObject.SendMessage("Reset", SendMessageOptions.DontRequireReceiver);
		this.gameObject.active = false;
	}
}
