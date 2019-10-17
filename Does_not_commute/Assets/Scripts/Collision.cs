using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour {

	private void OnTriggerEnter(Collider other)
    {
        if(other.name != "calle_1" && other.name != "calle_2" && other.name != "calle_3" && other.name != "calle_4" && other.GetComponent<Helper>() == null && other.GetComponent<Objective_control>() == null) 
        {
            this.GetComponent<Player>().speed -= 2f;
            if(this.GetComponent<Player>().speed < 0f) this.GetComponent<Player>().speed = 0f;
		    this.GetComponent<Player>().actualSpeed = -1f;
        }
        
        
    }
}
