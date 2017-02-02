using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {

	// Update is called once per frame
	float maxValue = 8; // or whatever you want the max value to be
	float minValue = -8; // or whatever you want the min value to be
	float currentValue = 8; // or wherever you want to start
	float direction = -1; 

	// Use this for initialization
	void Start () {
		Screen.fullScreen = false;
		//PlayerPrefs.DeleteAll ();
	}
	
	void Update() {
		currentValue += Time.deltaTime * direction * 0.05f; // or however you are incrementing the position
		if(currentValue >= maxValue) {
			direction *= -1;
			currentValue = maxValue;
		} else if (currentValue <= minValue){
			direction *= -1; 
			currentValue = minValue;
		}
		transform.position = new Vector3(currentValue, transform.position.y, 0);
	}
}
