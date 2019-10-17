using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Player : MonoBehaviour {
	public bool rewinding;
	public float speed;
	public float oldSpeed;
	public float actualSpeed = 0;
	public float acc =  0.5f;
	private float yAxis;
	public float recordTime = 5f;
	public Vector3 iniPos;
	public Vector3 iniRot;
	public bool pause;
	public List<PointInTime> pointsInTime;
	public GameObject counter;

	
	// Use this for initialization
	void Start () 
	{
		iniPos = transform.position;
		iniRot = transform.eulerAngles;
		pause = false;
		pointsInTime = new List<PointInTime>();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(rewinding) Rewind();
		else if(!pause && !counter.GetComponent<Counter>().IsRewinding()) 
		{
			transform.Translate(Vector3.back*(this.actualSpeed)*Time.fixedDeltaTime,Space.Self);
			actualSpeed += Time.deltaTime*acc;
			if (actualSpeed > speed) 
			{
				actualSpeed = speed;
			}
			/* if (pointsInTime.Count > Mathf.Round(recordTime / Time.fixedDeltaTime))
			{
				pointsInTime.RemoveAt(pointsInTime.Count - 1);
			}*/

			pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
			
			if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
			{
				yAxis = Input.GetAxis("Horizontal");
				Vector3 rotation = new Vector3(0,this.yAxis,0);
				transform.Rotate(rotation);
			}
		}
		
	}
	
	public void Rewind() 
	{
		if (pointsInTime.Count > 0)
		{
			PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.position;
			transform.rotation = pointInTime.rotation;
			pointsInTime.RemoveAt(0);
		}
		else 
		{
			rewinding = false;
			this.speed = this.oldSpeed;
			this.actualSpeed = 0f;

		} 
		acc =  1f;
	}

	public bool IsRewinding() 
	{
		return rewinding;
	}
}
