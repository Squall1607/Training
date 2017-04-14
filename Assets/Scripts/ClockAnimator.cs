using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
public class ClockAnimator : MonoBehaviour {

	public Transform hours, minutes, seconds, alarm;
	private const float hoursToDegrees = 360f/12f,
	minutesToDegrees = 360f/60f,
	secondsToDegrees = 360f/60f,
	alarmToDegrees = 360f/12f;
	private int a_min, a_hour;
	public int A_min{
		get{ 
			return this.a_min;
		}
		set{ 
			this.a_min = value;
			if (a_min < 10) {
				alarmMinute.text = "0" + a_min + ":00";
			} else{
				alarmMinute.text = a_min + ":00";
			}
		}
	}

	public int A_hour{
		get{ 
			return this.a_hour;
		}
		set{ 
			this.a_hour = value;
			if (a_hour < 10) {
				alarmHour.text = "0" + a_hour + ":";
			} else {
				alarmHour.text = a_hour + ":";
			}
		}
	}

	public GameObject hourPrefab;
	public Transform parent;
	public Text alarmHour;
	public Text alarmMinute;
	public GameObject messageWhenAlarm;
	public bool analog;
	public bool isHoldUp = false;
	public bool isHoldDown = false;
	[SerializeField]
	bool isAlarm = false;
	float timeMouseDown = 0;

	void Start(){
		messageWhenAlarm.SetActive (false);

		alarmHour.text = "12:";
		alarmMinute.text = "00:00";
		a_hour = 12;

		DateTime time = DateTime.Now;
		for (int i = 0; i < 12; i++) {
			GameObject g = Instantiate (hourPrefab, parent);
			g.transform.localRotation = Quaternion.Euler (0f, 0f, i * -hoursToDegrees);
			if (i == 0)
				g.GetComponentInChildren<Text> ().text = "12";
			else
				g.GetComponentInChildren<Text> ().text = ""+i;

			g.GetComponentsInChildren<RectTransform>(true)[1].Rotate(0f,0f,i*hoursToDegrees);
		}	
	}

	void Update(){

		if (analog) {
			TimeSpan timespan = DateTime.Now.TimeOfDay;
			hours.localRotation = Quaternion.Euler (0f,0f, (float)timespan.TotalHours * - hoursToDegrees);
			minutes.localRotation = Quaternion.Euler (0f,0f, (float)timespan.TotalMinutes * - minutesToDegrees);
			seconds.localRotation = Quaternion.Euler (0f,0f, (float)timespan.TotalSeconds * - secondsToDegrees);
		} else {
			DateTime time = DateTime.Now;
			hours.localRotation = Quaternion.Euler (0f, 0f, time.Hour * -hoursToDegrees);
			minutes.localRotation = Quaternion.Euler (0f, 0f, time.Minute * -minutesToDegrees);
			seconds.localRotation = Quaternion.Euler (0f, 0f, time.Second * -secondsToDegrees);
		}

		if (isAlarm) {
			alarm.localRotation = Quaternion.Euler (0f, 0f, (A_hour* -alarmToDegrees) - ((A_min/10)*6));
		}

		if (DateTime.Now.Hour == A_hour && DateTime.Now.Minute == A_min) {
			messageWhenAlarm.SetActive (true);
		} else {
			messageWhenAlarm.SetActive (false);
		}

		if (isHoldUp) {
			timeMouseDown += Time.deltaTime;
			if (timeMouseDown >= 1) {
				A_min += 1;
				if (A_min >= 60) {
					A_hour += 1;
					A_min = 0;
				}
			}
		}

		if (isHoldDown) {
			timeMouseDown += Time.deltaTime;
			if (timeMouseDown >= 1) {
				A_min -= 1;
				if (A_min <= 0) {
					A_hour -= 1;
					A_min = 55;
				}
			}
		}
	}
		
	public void OnPointerDown_1(){
		isHoldUp = true;
		A_min += 5;
		if (A_min >= 60) {
			A_hour += 1;
			A_min = 0;
		}
		isAlarm = true;
	}

	public void OnPointerDown_2(){
		isHoldDown = true;
		A_min -= 5;
		if (A_min <= 0) {
			A_hour -= 1;
			A_min = 55;
		}
		isAlarm = true;
	}

	public void OnPointerUp(){
		isHoldUp = false;
		isHoldDown = false;
		timeMouseDown = 0;
	}
}
