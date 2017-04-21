using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Scrollview_Controller : MonoBehaviour {

	public GameObject nodePrefab;
	public GameObject holder;
	public Transform top, bottom;
	private GameObject go;
	private int num = 0;

	void Start(){
		for (int i = 0; i < 1000; i++) {
			go = Instantiate (nodePrefab);
			go.transform.SetParent (holder.transform);
			go.GetComponentsInChildren<Text> (true) [0].text = (1 + i).ToString();
		}

	}

	void Update(){

		//for the top of scrollview
		num = (int)((holder.transform.localPosition.y - 200)/25);
		if (num==0) {
			holder.transform.GetChild (0).GetChild(0).gameObject.SetActive (true);
		}
		for (int i = 0; i < num; i++) {
			holder.transform.GetChild (i).GetChild(0).gameObject.SetActive (false);


			for (int j = num; j < num + 16; j++) {
				holder.transform.GetChild (j).GetChild(0).gameObject.SetActive (true);
			}

		}

		for (int k = num + 16; k < holder.transform.childCount; k++) {
			holder.transform.GetChild (k).GetChild(0).gameObject.SetActive (false);
		}


	}

}
