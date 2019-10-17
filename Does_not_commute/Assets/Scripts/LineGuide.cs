using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGuide : MonoBehaviour {

	public GameObject currentObject;
	public GameObject objectiveObject;
	
	void Start () 
	{
		transform.position = (5 * Vector3.left) + currentObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = (5 * Vector3.left) + currentObject.transform.position;
		Vector3 diff = currentObject.transform.position - objectiveObject.transform.position;
		float angle = Mathf.Atan2(diff.x,diff.z) * Mathf.Rad2Deg;
		transform.eulerAngles = new Vector3(0f,angle,0f); 
	}
}
