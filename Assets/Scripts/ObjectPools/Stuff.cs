using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class Stuff : PooledObject {
	MeshRenderer[] meshRenderers;

	public void SetMaterial(Material m){
		for (int i = 0; i < meshRenderers.Length; i++) {
			meshRenderers[i].material = m;
		}
	}

	public Rigidbody Body{ get; private set;}
	// Use this for initialization
	void Awake () {
		Body = GetComponent<Rigidbody> ();
		meshRenderers = GetComponentsInChildren<MeshRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.CompareTag("Kill Zone")){
			ReturnToPool ();
		}
	}

	void OnLevelWasLoaded(){
		ReturnToPool ();
	}
}
