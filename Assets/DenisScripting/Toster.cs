using UnityEngine;
using System.Collections;

public class Toster : MonoBehaviour {
	public int Score = 0;
	public Vector3 lastpos;
	public Vector3 jostikRoot;
	
	
	//public GUIContent content = new GUIContent();
	public Texture imageOfRoot;
	public Texture imageOfArrow;
	//public bool supportsMultiTouch = Input.multiTouchEnabled;
	// Use this for initialization
	
	void Start () {
		//jostikRoot = Input.mousePosition;
		//content.image = (Texture2D)image;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log (Score - (int)transform.position.y);
		/*float moveUp;
		if (Input.GetKey ("e")) {
			moveUp = 1;
			Debug.Log("Fly!");
		}
		else{
			moveUp = 0;
		}*/
		//moveUp++;
		//Debug.Log(moveUp);
		//Vector3 lastpos = Vector3.zero;
		/*if (Input.GetKeyDown (KeyCode.Mouse0)) {
			lastpos = Input.mousePosition;
				}
		
		if (Input.GetMouseButton (0)) {
			Vector3 delta = Input.mousePosition - lastpos;
			lastpos =  Input.mousePosition;


			Vector3 Movement = new Vector3 (delta.x * Time.deltaTime * 100 , 0, delta.y * Time.deltaTime * 100);
			//Vector3 Movement = new Vector3 (Touch.deltaPosition.x * 10 * Time.deltaTime, moveUp * 100, Touch.deltaPosition.y * 10 * Time.deltaTime);
			rigidbody.AddForce (Movement);
			//transform.Rotate (0, speed * Time.deltaTime * delta.x, 0);
			//lastpos = Input.mousePosition;
		}
		*/
		//if(Input.touches.)
		//Touch toch = Input.touches();
		
		
		
		
	}
	
	void FixedUpdate () {
		if (Input.GetMouseButtonDown (0)) {//Input.GetKeyDown(KeyCode.Mouse0)) {
			jostikRoot = Input.mousePosition;
			
		}
		
		if (Input.GetMouseButton (0)) {//Input.GetKey(KeyCode.Mouse0)) {
			lastpos = Input.mousePosition;
			Vector3 delta = Input.mousePosition - jostikRoot;
			if (delta.x > 100) {
				delta.x = 100;
			}
			if (delta.x < -100) {
				delta.x = -100;
			}
			if (delta.y > 100) {
				delta.y = 100;
			}
			
			if (delta.y < -100) {
				delta.y = -100;
			}
			
			Vector3 Movement = new Vector3 (delta.x * 3 * Time.deltaTime, 0, -delta.y * 3 * Time.deltaTime);
			//Vector3 Movement = new Vector3 (Touch.deltaPosition.x * 10 * Time.deltaTime, moveUp * 100, Touch.deltaPosition.y * 10 * Time.deltaTime);
			GetComponent<Rigidbody>().AddForce (Movement);
		} else {
			
			
			//transform.Rotate (0, speed * Time.deltaTime * delta.x, 0);
			//lastpos = Input.mousePosition;
			//}
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = -Input.GetAxis ("Vertical");

			Vector3 Movement = new Vector3 (moveHorizontal * 10, 0, moveVertical * 10);
			//Vector3 Movement = new Vector3 (Touch.deltaPosition.x * 10 * Time.deltaTime, moveUp * 100, Touch.deltaPosition.y * 10 * Time.deltaTime);
			GetComponent<Rigidbody>().AddForce (Movement);
			//Vector2 Tach = Touch.deltaPosition.x;
		}
		
		//Touch Bad!!!!!

		
		//Vector3 Movement = new Vector3 (moveHorizontal, moveUp * 100, moveVertical);
		//Vector3 Movement = new Vector3 (Touch.deltaPosition.x * 10 * Time.deltaTime, moveUp * 100, Touch.deltaPosition.y * 10 * Time.deltaTime);
		//rigidbody.AddForce (Movement);
	}
	
	void OnGUI () {
		
		//GUI.DrawTexture(new Rect(Screen.width / 2 - 370, Screen.height / 2 - 25, 623, 50), imageOfRoot); 
		//if (image) image.pixelInset.Set (100,100,100,100);
		
		if (Input.GetMouseButton(0)){//Input.GetKeyDown(KeyCode.Mouse0)) {
			//GUI.Button(new Rect(jostikRoot.x - 10 ,(Screen.height) - jostikRoot.y -10,20,20), "Start Game");//(Screen.height)/2 
			//float
			//flout guiArrow = Vector3.Distance(jostikRoot, Input.mousePosition)
			//for(float i = 0; Vector3.Distance(jostikRoot, Input.mousePosition) > i; i + 20){
			//	Vector3.Lerp(jostikRoot)
			float guiArrow = Vector3.Distance(jostikRoot, Input.mousePosition);
			if (guiArrow > 100){guiArrow = 100;}
			
			
			
			float size = 50;
			//GUI.DrawTexture(new Rect(josticRootGuiPosition.x, josticRootGuiPosition.y,size,size), imageOfRoot); 
			//Color ColorT = imageOfRoot.
			for(int i = 0; i < guiArrow; i += 30){
				size -= 10;
				Vector3 inputMouseguiPosition =  new Vector3(Input.mousePosition.x - size, (Screen.height) - Input.mousePosition.y - size, 0);
				Vector3 josticRootGuiPosition = new Vector3(jostikRoot.x - 10 ,(Screen.height) - jostikRoot.y -10, 0);
				if (Vector3.Distance(inputMouseguiPosition, josticRootGuiPosition) > 100)
				{inputMouseguiPosition = Vector3.Normalize(inputMouseguiPosition - josticRootGuiPosition) * 100 + josticRootGuiPosition;}
				
				//Vector3.Slerp(jostikRoot, Input.mousePosition, i);
				
				//GUI.Button(new Rect(josticRootGuiPosition.x, josticRootGuiPosition.y,20,20), "Start Game");
				GUI.DrawTexture(new Rect(Vector3.Slerp(josticRootGuiPosition, inputMouseguiPosition, (float)i/100).x ,Vector3.Slerp(josticRootGuiPosition, inputMouseguiPosition, (float)i/100).y, size, size), imageOfRoot);
				//GUI.Button(new Rect(Vector3.Slerp(josticRootGuiPosition, inputMouseguiPosition, (float)i/100).x ,Vector3.Slerp(josticRootGuiPosition, inputMouseguiPosition, (float)i/100).y, 20, 20), "lala");
				
			}
			
		}
	}
}

