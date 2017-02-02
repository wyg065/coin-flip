using UnityEngine;
using System.Collections;

public class shadowConroller : MonoBehaviour {

	public GameObject coin;
	private Animator anim;
	private Animator anim2;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		anim2 = coin.gameObject.GetComponent<Animator> ();
		anim.SetBool ("purple", anim2.GetBool("purple"));
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("purple", anim2.GetBool("purple"));
	}
}
