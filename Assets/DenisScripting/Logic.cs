using UnityEngine;
using System.Collections;

public class Logic : MonoBehaviour {
	public GameObject player;
	public bool guiOn2 = false;
	protected int printScore;

	public bool pausedOn = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			pausedOn = !pausedOn ;
			
		}
	}

	void OnGUI () {
		if (pausedOn) {
			Time.timeScale = 0;
			guiOn2 = true;

		} else {
			guiOn2 = (player.GetComponent<ColluzionDead>()).guiOn;
			Time.timeScale = 1;

		}



		printScore = (player.GetComponent<ColluzionDead>()).printScore;



		if (guiOn2){
			if( GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "Your Score = "+printScore+"\n\nTry Again") )
				Application.LoadLevel("Fall3");
		}
			//GUI.Box(new Rect(10,10,100,90), "Menu");
			/*
			// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
			if(GUI.Button(new Rect((Screen.width)/2 -(Screen.width)/10,(Screen.height)/2-(Screen.height)/14,(Screen.width)/5,(Screen.height)/8), "Start Game") || Input.GetKey(KeyCode.Return)) {
				Application.LoadLevel("Fall3");
				
			}*/

			//if(GUI.Button(new Rect((Screen.width)/2 -(Screen.width)/10,(Screen.height)/2-(Screen.height)/17 + 100,(Screen.width)/5,(Screen.height)/16), "Menu")) {
			//	Application.LoadLevel(0);
				
			
	}
}
