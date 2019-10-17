using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour {

	private TextMeshProUGUI counterText;
	public float counter = 0f;
	private float lastRound;
	public bool rewinding;
	public GameObject player;
	// Use this for initialization
	void Start () 
	{
		rewinding = false;
		counterText = GetComponent<TextMeshProUGUI>();
		counterText.text = (counter).ToString("00");
		lastRound = counter;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if(rewinding) 
		{
			this.counter = this.counter + Time.fixedDeltaTime;
			counterText.text = counter.ToString("00");
			if(this.counter >= this.lastRound) 
			{
				lastRound -= 1;
				counter -= 1f;
				rewinding = false;
			}
		}
		else 
		{
			if(counter > 0f && !player.GetComponent<Player>().IsRewinding()) 
			{
				counter = counter - Time.fixedDeltaTime;
				counterText.text = counter.ToString("00");
			}
		}
	}

	public bool IsRewinding() 
	{
		return rewinding;

	}

	

	public void  UpdateLastRound()
	{
		lastRound = counter;
		counterText.text = counter.ToString("00");
	}

}
