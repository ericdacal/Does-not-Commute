using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour 
{
	private bool credits;
	private bool instructions;
	public GameObject MenuCanvas;
	public GameObject CreditCanvas;
	public GameObject InstructionCanvas;
	private float count;
	public float timeCredits;

	void Start() 
	{
		credits = false;
		count = 0f;
		CreditCanvas.SetActive(false);
		InstructionCanvas.SetActive(false);
	}
	void FixedUpdate() 
	{
		if(credits) 
		{
			count += Time.fixedDeltaTime;
			if(count >= timeCredits) 
			{
				count = 0f;
				credits = false;
				MenuCanvas.SetActive(true);
				CreditCanvas.SetActive(false);
			} 

		}
		else if(instructions)
		{
			count += Time.fixedDeltaTime;
			if(count >= timeCredits) 
			{
				count = 0f;
				instructions = false;
				MenuCanvas.SetActive(true);
				InstructionCanvas.SetActive(false);
			} 

		}

	}
	public void OpenGame() 
	{
		SceneManager.LoadScene("Scene3", LoadSceneMode.Single);
		
	}

	public void QuitGame() 
	{
		#if UNITY_EDITOR
         // Application.Quit() does not work in the editor so
         // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
         UnityEditor.EditorApplication.isPlaying = false;
    	#else
         	Application.Quit();
     	#endif
	}

	public void OpenCredits() 
	{
		credits = true;
		MenuCanvas.SetActive(false);
		CreditCanvas.SetActive(true);
	}
	
	public void OpenInstructions() 
	{
		instructions = true;
		MenuCanvas.SetActive(false);
		InstructionCanvas.SetActive(true);
	}
}
