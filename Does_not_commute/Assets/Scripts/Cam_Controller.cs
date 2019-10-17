using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam_Controller : MonoBehaviour {
	public Transform objTransform;

	// Use this for initialization
	void Start () 
	{
		transform.position = objTransform.position;
		transform.Translate(new Vector3(0f,10f,0f),Space.World);
		//myTransform = GetComponent<Transform>();
		//myTransform.Translate(objTransform.position);
		//myTransform.Translate(new Vector3(0f,20f,0f),Space.World);
	}
	
	// Update is called once per frame
	void Update () 
	{
		float diffx = transform.position.x - objTransform.position.x;
		float diffz = transform.position.z - objTransform.position.z;
		transform.Translate(-diffx,0f,-diffz,Space.World);
	}
}
