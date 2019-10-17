using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSound : MonoBehaviour {
	public AudioClip sound;

	// Update is called once per frame
	void Start () 
	{
		AudioSource audioSource = gameObject.AddComponent<AudioSource>();
		audioSource.loop = true;
		audioSource.volume = 0.05f;
		audioSource.clip = sound;
		audioSource.Play();
	}
}
