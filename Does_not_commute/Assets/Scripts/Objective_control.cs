using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective_control : MonoBehaviour 
{
    private int index;
    public List<GameObject> AssociateVehicles;
    public GameObject controller;
    public AudioClip sound;
	
    private void OnTriggerEnter(Collider other)
    {
        SceneController con = controller.GetComponent<SceneController>();
        foreach (GameObject veh in AssociateVehicles)
        {
            if(veh.gameObject.name == other.gameObject.name) 
            {
                AudioSource.PlayClipAtPoint(sound,transform.position);
                con.nextObjective();
                break;
            }   
        }
    }

}
 