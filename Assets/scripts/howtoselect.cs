using UnityEngine;
using System.Collections;

public class howtoselect : MonoBehaviour {
	
	public GameObject screenFader;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			StartCoroutine(gohome());
		}
	}
	
	void OnMouseDown()
	{
		if(Input.GetMouseButtonDown(0)){
			StartCoroutine(changeLevel());
		}
		
	}
	
	IEnumerator changeLevel () {
		float fadeTime = screenFader.GetComponent<fade>().StartFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel("howto");
	}
	
	IEnumerator gohome () {
		float fadeTime = screenFader.GetComponent<fade>().StartFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel("open");
	}
}
