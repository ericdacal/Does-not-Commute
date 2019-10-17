using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour 
{

	public GameObject SceneController; 

	private void OnTriggerEnter(Collider other)
    {
		print("entro");
    	SceneController.GetComponent<SceneController>().rewindTime();
    }
}
