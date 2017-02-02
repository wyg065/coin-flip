using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class coinController : MonoBehaviour {

	public Text flips;
	public GameObject screenFader;
	public bool purple;

	[HideInInspector]
	public Animator anim;
	public GameObject[] coins;
	private int complete = 0;
	private AudioSource flip;
	private AudioSource win;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		coins = GameObject.FindGameObjectsWithTag("coins");
		anim.SetBool("purple", purple);
		AudioSource[] sounds = GetComponents<AudioSource>();
		flip = sounds[0];
		win = sounds[1];
		initPrefs();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnMouseDown()
	{
		if(Input.GetMouseButtonDown(0)){
			flip.Play();
			purple = !purple;
			anim.SetBool("purple", purple);
			int i = int.Parse(flips.text)+1;
			flips.text = i.ToString();

			foreach (GameObject coin in coins) {
				if (transform.position.x == coin.transform.position.x) {
					bool temp = coin.GetComponent<coinController>().purple;
					coin.GetComponent<coinController>().purple = !temp;
					coin.GetComponent<Animator>().SetBool("purple", coin.GetComponent<coinController>().purple);
				}
				if (transform.position.y == coin.transform.position.y) {
					bool temp = coin.GetComponent<coinController>().purple;
					coin.GetComponent<coinController>().purple = !temp;
					coin.GetComponent<Animator>().SetBool("purple", coin.GetComponent<coinController>().purple);
				}
			}

			bool done = true;
			foreach (GameObject coin in coins) {
				if (coin.GetComponent<Animator>().GetBool("purple") == true) {
					done = false;
				}
			}
			if (done && !(Application.loadedLevelName).Equals("howto")) {
				win.Play();
				updatePrefs();
				StartCoroutine(delaychangeLevel());
			}
		}
	}

	IEnumerator changeLevel () {
		float fadeTime = screenFader.GetComponent<fade>().StartFade (1);
		yield return new WaitForSeconds(fadeTime);
		Application.LoadLevel("levelselect");
	}

	IEnumerator delaychangeLevel () {
		yield return new WaitForSeconds(1);
		StartCoroutine(changeLevel());
	}

	void updatePrefs() {
		int i = int.Parse (flips.text);
		if ((Application.loadedLevelName).Equals("scene1")) {
			PlayerPrefs.SetInt("level1complete",1);
			if (i <= 2 || complete == 2) {
				PlayerPrefs.SetInt("level1complete",2);
			}
		}
		if ((Application.loadedLevelName).Equals("scene2")) {
			PlayerPrefs.SetInt("level2complete",1);
			if (i <= 3 || complete == 2) {
				PlayerPrefs.SetInt("level2complete",2);
			}
		}
		if ((Application.loadedLevelName).Equals("scene3")) {
			PlayerPrefs.SetInt("level3complete",1);
			if (i <= 3 || complete == 2) {
				PlayerPrefs.SetInt("level3complete",2);
			}
		}
		if ((Application.loadedLevelName).Equals("scene4")) {
			PlayerPrefs.SetInt("level4complete",1);
			if (i <= 3 || complete == 2) {
				PlayerPrefs.SetInt("level4complete",2);
			}
		}
		if ((Application.loadedLevelName).Equals("scene5")) {
			PlayerPrefs.SetInt("level5complete",1);
			if (i <= 4 || complete == 2) {
				PlayerPrefs.SetInt("level5complete",2);
			}
		}
		if ((Application.loadedLevelName).Equals("scene6")) {
			PlayerPrefs.SetInt("level6complete",1);
			if (i <= 4 || complete == 2) {
				PlayerPrefs.SetInt("level6complete",2);
			}
		}
		if ((Application.loadedLevelName).Equals("scene7")) {
			PlayerPrefs.SetInt("level7complete",1);
			if (i <= 4 || complete == 2) {
				PlayerPrefs.SetInt("level7complete",2);
			}
		}
		if ((Application.loadedLevelName).Equals("scene8")) {
			PlayerPrefs.SetInt("level8complete",1);
			if (i <= 4 || complete == 2) {
				PlayerPrefs.SetInt("level8complete",2);
			}
		}
		if ((Application.loadedLevelName).Equals("scene9")) {
			PlayerPrefs.SetInt("level9complete",1);
			if (i <= 4 || complete == 2) {
				PlayerPrefs.SetInt("level9complete",2);
			}
		}
	}

	void initPrefs() {
		complete = 0;
		if ((Application.loadedLevelName).Equals ("scene1")) {
			if(PlayerPrefs.HasKey("level1complete")){
				complete = PlayerPrefs.GetInt("level1complete");
			}
		}
		if ((Application.loadedLevelName).Equals ("scene2")) {
			if(PlayerPrefs.HasKey("level2complete")){
				complete = PlayerPrefs.GetInt("level2complete");
			}
		}
		if ((Application.loadedLevelName).Equals ("scene3")) {
			if(PlayerPrefs.HasKey("level3complete")){
				complete = PlayerPrefs.GetInt("level3complete");
			}
		}
		if ((Application.loadedLevelName).Equals ("scene4")) {
			if(PlayerPrefs.HasKey("level4complete")){
				complete = PlayerPrefs.GetInt("level4complete");
			}
		}
		if ((Application.loadedLevelName).Equals ("scene5")) {
			if(PlayerPrefs.HasKey("level5complete")){
				complete = PlayerPrefs.GetInt("level5complete");
			}
		}
		if ((Application.loadedLevelName).Equals ("scene6")) {
			if(PlayerPrefs.HasKey("level6complete")){
				complete = PlayerPrefs.GetInt("level6complete");
			}
		}
		if ((Application.loadedLevelName).Equals ("scene7")) {
			if(PlayerPrefs.HasKey("level7complete")){
				complete = PlayerPrefs.GetInt("level7complete");
			}
		}
		if ((Application.loadedLevelName).Equals ("scene8")) {
			if(PlayerPrefs.HasKey("level8complete")){
				complete = PlayerPrefs.GetInt("level8complete");
			}
		}
		if ((Application.loadedLevelName).Equals ("scene9")) {
			if(PlayerPrefs.HasKey("level9complete")){
				complete = PlayerPrefs.GetInt("level9complete");
			}
		}
	}
}
