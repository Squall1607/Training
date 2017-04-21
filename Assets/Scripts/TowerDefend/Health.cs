using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

	TextMesh tm;

	void Start(){
		tm = GetComponent<TextMesh> ();
	}

	void Update(){
		transform.forward = Camera.main.transform.forward;
	}

	public int current(){
		return tm.text.Length;
	}

	public void decrease(){
		if (current() > 1) {
			tm.text = tm.text.Remove (tm.text.Length - 1);
		} else {
			Destroy (transform.parent.gameObject);
		}
	}
}
