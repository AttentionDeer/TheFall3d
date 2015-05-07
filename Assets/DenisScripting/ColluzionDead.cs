using UnityEngine;
using System.Collections;

public class ColluzionDead : MonoBehaviour {
	public GameObject pease;
	public GameObject player;
	protected bool notDone = true;
	public bool guiOn = false;
	public int printScore;
	public GameObject logic;

	public float startTime;
	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter(Collision collision) {
		if (notDone) {

			if( collision.other.GetComponent<BonusPoint>() != null)
			{
				this.GetComponent<Toster>().Score += 10;
				Destroy(collision.other.gameObject);
				this.GetComponent<AudioSource>().Play();
			}
			else
			{

						for (int i = 0; i < 5; i++) {
								for (int i2 = 0; i2 < 5; i2++) {
										for (int i3 = 0; i3 < 5; i3++) {
											GameObject thispeace = Instantiate (pease, player.transform.position + new Vector3 (((float)i / 10) - 0.2f, (float)i2 / 10 - 0.2f, (float)i3 / 10 - 0.2f), Quaternion.identity) as GameObject;
											thispeace.GetComponent<Rigidbody>().AddForce(Random.value * 2000 - 1000, 1000, Random.value * 2000 - 1000);
										}
								}
						}
			notDone = !notDone;
			printScore = (int)(player.GetComponent<Toster>()).Score + (int) ((Time.time - startTime)*10);
			guiOn = true;
			(logic.GetComponent<Logic>()).guiOn2 = true;

			//player.SetActive(false);
			//this.gameObject.GetComponent<Collider>().enabled = false;
			this.gameObject.GetComponent<Toster>().enabled = false;

			}
		}

		
	}



	

}