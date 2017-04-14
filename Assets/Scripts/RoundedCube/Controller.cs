using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Controller : MonoBehaviour {
	public GameObject txtEndGame;
	public GameObject cubePrefab;
	public Button lBtn;
	public Button rBtn;
	public Text lblTime;
	[SerializeField]
	private int quantity = 10;
	[SerializeField]

	private GameObject pusher;
	private GameObject coin;

	private float t;
	private float time;
	private bool isOk = false;
	private bool isDrop = false;

	public float getTime{
		get{ 
			return this.t;
		}
		set{ 
			this.t = value;
			lblTime.text = ((int)t).ToString ();
		}
	}
	public bool IsOk{
		get{ return this.isOk;}
		set{ this.isOk = value;}
	}
	public float cubeTime{
		get{ return this.time;}
		set{ this.time = value;}
	}

	void Awake(){
		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 60;
	}

	private void Start(){
		t = 60;
		IsOk = true;
		CreatePlane ();
		CreateCube ();
		CreatePusher ();
		cubeTime = 10;
	}

	public void OnClickCoin(){
		coin = Instantiate (cubePrefab, new Vector3 (35, 60, 70), Quaternion.Euler (20, 0, 0));
		coin.GetComponent<MeshRenderer> ().material.color = new Color (1, 1, 1,.5f);
		coin.GetComponent<Rigidbody> ().useGravity = false;
		coin.GetComponent<Cube> ().Generate ();
	}

	private void CreatePlane(){
		GameObject g = Instantiate (cubePrefab);
		var plane = g.GetComponent<Cube> ();
		g.GetComponent<Rigidbody> ().useGravity = false;
		g.GetComponent<Rigidbody> ().isKinematic = true;
		plane.xSize = plane.zSize = 80;
		plane.ySize = 8;
		plane.Generate ();
	}

	private void CreateCube(){
		for (int i = 0; i < quantity; i++) {
			float x = Random.Range (10, 60);
			float y = Random.Range (35, 120);
			float z = Random.Range (7, 45);
			GameObject g = Instantiate (cubePrefab, new Vector3(x, y,z), Quaternion.Euler(0,0,0));
			var cubeSize = g.GetComponent<Cube>();
			cubeSize.xSize = Random.Range (2,10);
			cubeSize.ySize = Random.Range (3,10);
			cubeSize.zSize = Random.Range (5,10);
			cubeSize.Generate ();
		}
	}

	private void CreatePusher(){
		pusher = Instantiate (cubePrefab);
		var plane = pusher.GetComponent<Cube> ();
		pusher.GetComponent<Rigidbody> ().useGravity = false;
		pusher.GetComponent<Rigidbody> ().isKinematic = true;
		pusher.GetComponent<Transform> ().position = new Vector3 (0,7,80);
		plane.xSize = 80;
		plane.zSize = 40;
		plane.ySize = 6;
		plane.Generate ();
	}

	private void Update(){
		getTime -= Time.deltaTime;
		if (getTime < 0) {
			Time.timeScale = 0;
			txtEndGame.SetActive (true);
		}
			
		cubeTime -= Time.deltaTime;
		if (cubeTime < 0) {
			CreateCube ();
			cubeTime = 10;
		}
	}

	public void OnClickDrop(){
		IsOk = false;
		coin.GetComponent<Rigidbody> ().useGravity = true;
		coin.GetComponent<MeshRenderer> ().material.color = new Color (1, 1, 1, 1);
		isDrop = true;
		StartCoroutine (MovePusher());
	}

	private IEnumerator MovePusher(){
		yield return new WaitForSeconds (6);
		iTween.MoveTo (pusher, iTween.Hash("z", 60, "time", .5f, "oncomplete", "MoveBack", "oncompletetarget",gameObject));
	}

	private void MoveBack(){
		iTween.MoveTo (pusher, iTween.Hash("z", 80, "time", 4, "oncomplete", "CheckOk", "oncompletetarget", gameObject));
	}

	private void CheckOk(){
		IsOk = true;
	}

	public void OnClick(string btnName){
		float x = coin.transform.position.x;
		float y = coin.transform.position.y;
		float z = coin.transform.position.z;
		bool canClick = true;
		if (btnName == "btnLeft" && canClick) {
			coin.transform.position = new Vector3 (x - 5, y, z);

			if (x <= 10) {
				lBtn.interactable = false;
			} else {
				lBtn.interactable = true;
			}
		}

		if (btnName == "btnRight" && canClick) {
			coin.transform.position = new Vector3 (x + 5, y, z);
			if (x >= 60) {
				rBtn.interactable = false;
			} else {
				rBtn.interactable = true;
			}
		}
	}



}
