using UnityEngine;
using System.Collections;

public class RandomBlock : MonoBehaviour {
	protected Vector3 RandVector;
	protected float TimerScale = 0;
	public float AdjustScale = 1; // дополнительный модификатор масштаба объектов

	protected int type = 0;
	// Use this for initialization
	void Start () {
		//StartFunction();
	}

	void StartFunction()
	{
		RandomizeBlock(AdjustScale);
	}

	void RandomizeBlock(float ScaleModifier)
	{
		double RngValue = Random.value;

		if (RngValue < 0.1) {
			RandVector = new Vector3 (Mathf.Pow (Random.value * 1.2f, 10) + 0.2f, 1, Mathf.Pow (Random.value * 1.2f, 15) + 0.2f);
			transform.localScale = new Vector3 (0, 0, 0);
		} else if (RngValue < 0.2) {
			RandVector = new Vector3 (Mathf.Pow (Random.value * 1.2f, 15) + 0.2f, 1, Mathf.Pow (Random.value * 1.2f, 10) + 0.2f);
			transform.localScale = new Vector3 (0, 0, 0);
		} else {
			//RandVector = new Vector3 (Mathf.Pow (Random.value * 1.2f, 5) + 0.2f, 1, Mathf.Pow (Random.value * 1.2f, 5) + 0.2f);
			RandVector = new Vector3 (0.9f, 1, 0.9f);
			transform.localScale = new Vector3 (0, 0, 0);
		}
		RandVector = new Vector3( RandVector.x * ScaleModifier, RandVector.y * ScaleModifier, RandVector.z * ScaleModifier);
	}

	// Update is called once per frame
	void Update () {
		if (TimerScale < 1) {
						TimerScale += Time.deltaTime;
			transform.localScale = Vector3.Lerp (new Vector3 (0, 0, 0), RandVector, TimerScale);
						//transform.localScale. = new Vector3 (Mathf.Pow(Random.value * 2, 2), 0, Mathf.Pow(Random.value * 2, 2));
				}
	}

	public void Reset()
	{
		TimerScale = 0;
		gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
		gameObject.transform.rotation = Quaternion.identity;
		StartFunction();
	}

}
