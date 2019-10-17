using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterHelper : MonoBehaviour {

	public List<GameObject> Helpers;
	// Update is called once per frame
	public void Rewind () 
	{
		foreach (GameObject h in Helpers)
		{
			h.GetComponent<Helper>().Rewind();
		}
	}
}
