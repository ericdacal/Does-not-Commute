using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour 
{

	public float value;
	public GameObject counter;
	public GameObject parent;
	private bool rewind = false;
	private void OnTriggerEnter(Collider other)
    {
		if(!rewind) 
		{
    		counter.GetComponent<Counter>().counter += value;
			parent.SetActive(false);
		}
		else rewind = false;
    }

	public void Rewind() 
	{
		rewind = true; 
		counter.GetComponent<Counter>().counter -= value;
		parent.SetActive(true);
	}
}
