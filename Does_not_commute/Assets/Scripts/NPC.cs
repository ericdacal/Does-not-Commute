using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour 
{
	public bool rewinding;
	public Vector3 Inipos;
	public Vector3 Inirot;
	private int index;
	public List<PointInTime> pointsInTime;
	public float recordTime = 5f;
	private float actualSpeed = 0;
	public bool pause;
	
	// Use this for initialization
	void Start () 
	{
		index = pointsInTime.Count - 1;
		transform.transform.eulerAngles = Inirot;
		transform.position = Inipos;
		this.actualSpeed = 0f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(rewinding) 
		{
			Rewind();
		}
		else if(!pause)
		{
			Play();
		}
	}

	private void Rewind() 
	{
		if(index < pointsInTime.Count - 1) 
		{
			PointInTime point = pointsInTime[index];
			transform.position = point.position;
			transform.rotation = point.rotation;
			index += 1;
		}
		else rewinding = false;
	
	}

	private void Play() 
	{
		if(index >= 0)
		{
			PointInTime point = pointsInTime[index];
			transform.position = point.position;
			transform.rotation = point.rotation;
			index -= 1;
		}
		else 
		{
			transform.Translate(Vector3.back);
		}	
	}
}



