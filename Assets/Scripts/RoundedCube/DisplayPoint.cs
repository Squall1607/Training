using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayPoint : MonoBehaviour {

	public Text lblPoint;
	private int point;
	public int Point{
		get{ return this.point;}
		set{ 
			this.point = value;
			lblPoint.text = point.ToString();
		}
	}

	// Use this for initialization
	void Start () {
		Point = 0;
	}


	void OnTriggerEnter(Collider myTrigger){
		if (myTrigger.gameObject.name == "RoundedCube(Clone)") {
			Point+=1;
		}
	}

	void OnTriggerExit(Collider myTrigger){
		if (myTrigger.gameObject.name == "RoundedCube(Clone)") {
			Destroy (myTrigger.gameObject, 3);
		}
	}
}
