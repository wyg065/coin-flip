using UnityEngine;
using System.Collections;

public class level1 : MonoBehaviour {

	public GameObject screenFader;
	private int complete = 0;

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.HasKey("level1complete")){
			complete = PlayerPrefs.GetInt("level1complete");
		}else{
			PlayerPrefs.SetInt("level1complete",complete);
		}
		gameObject.GetComponent<Animator> ().SetInteger("complete", complete);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		if(Input.GetMouseButtonDown(0)){
			StartCoroutine(changeLevel());
		}

	}

	IEnumerator changeLevel () {
		transform.localScale += new Vector3(.2f,.2f,0);
		float fadeTime = screenFader.GetComponent<fade>().StartFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel("scene1");
	}
}
