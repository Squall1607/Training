using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Image_Controller : MonoBehaviour {

	[SerializeField]
	Sprite[] img = new Sprite[5];
	int i = 0;
	public Image sprImage;
	public Button btnNext, btnPrev;
	void Start(){
		sprImage.sprite = img [0];
	}

	public void OnClick(string btnName){
		if (btnName == "btnNext") {
			i++;
			sprImage.sprite = img [i];
			btnPrev.interactable = true;
			if (i >= img.Length - 1) {
				btnNext.interactable = false;
			}
		}else if(btnName=="btnPrev"){
			i--;
			sprImage.sprite = img [i];
			btnNext.interactable = true;
			if (i <= 0) {
				btnPrev.interactable = false;
			}
		}
	}
}
