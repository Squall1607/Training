using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class TimeController : MonoBehaviour {
	int hour, minute, second;
	[SerializeField]
	Text txt;
	
	void Update(){
		this.hour = DateTime.Now.Hour;
		this.minute = DateTime.Now.Minute;
		this.second = DateTime.Now.Second;

		txt.text = this.hour + " : " + this.minute + " : " + this.second;
	}
}
