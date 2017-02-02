using UnityEngine;
using System.Collections;

public class home : MonoBehaviour {
	
	public GameObject screenFader;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			StartCoroutine(changeLevel());
		}
	}

	void OnMouseDown()
	{
		if(Input.GetMouseButtonDown(0)){
			StartCoroutine(resetLevel());
		}
		
	}
	
	IEnumerator changeLevel () {
		float fadeTime = screenFader.GetComponent<fade>().StartFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel("levelselect");
	}

	IEnumerator resetLevel () {
		float fadeTime = screenFader.GetComponent<fade>().StartFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel(Application.loadedLevelName);
	}
}
