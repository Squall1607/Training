using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShowText : MonoBehaviour {
	
	void Start(){
		Text txt = GetComponent<Text> ();
		txt.text = "my name is Dung but you can call me Squall!";
	}
}
