using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Controller : MonoBehaviour {

	[SerializeField]
	float speedX, speedY, speedZ;
	void Start(){
		
	}

	void Update(){
		transform.Rotate (speedX * Time.deltaTime, speedY * Time.deltaTime, speedZ * Time.deltaTime);
	}

	public void AdjustSpeedX(float newSpeed){
		speedX = newSpeed;
	}

	public void AdjustSpeedY(float newSpeed){
		speedY = newSpeed;
	}

	public void AdjustSpeedZ(float newSpeed){
		speedZ = newSpeed;
	}
}
