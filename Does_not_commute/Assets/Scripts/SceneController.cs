using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneController : MonoBehaviour {

	public int lastActive;
	public List<GameObject> Vehicles;
	public List<GameObject> Objectives;
	public List<GameObject> Helpers;
	public GameObject currentObjective;
	public GameObject currentVehicle;
	public GameObject currentHelper;
	public GameObject cam;
	public GameObject Counter;
	public GameObject GameCanvas;
	public GameObject PauseCanvas;
	public GameObject Line;

	// Use this for initialization
	void Start () 
	{
		PauseCanvas.SetActive(false);
		foreach (GameObject veh in Vehicles)
		{
			print(veh.name);
			veh.SetActive(false);
		}
		foreach (GameObject obj in Objectives) 
		{
			obj.SetActive(false);
		}
		foreach (GameObject h in Helpers) 
		{
			if(h != null) h.SetActive(false);
		}
		currentObjective.SetActive(true);
		currentVehicle.SetActive(true);
		currentHelper.SetActive(true);
	}
	public void nextObjective()
	{
		if(lastActive != Vehicles.Count - 1)
		{
			foreach (GameObject veh in Vehicles)
			{
				if(veh.gameObject.active && veh.GetComponent<NPC>() != null) 
				{
					veh.transform.position = veh.GetComponent<NPC>().Inipos;
					veh.transform.eulerAngles = veh.GetComponent<NPC>().Inirot;
				}
			}
			currentVehicle.AddComponent(typeof(NPC));
			currentVehicle.GetComponent<NPC>().pointsInTime = currentVehicle.GetComponent<Player>().pointsInTime;
			currentVehicle.GetComponent<Rigidbody>().isKinematic = true;
			GameObject ocounter = currentVehicle.GetComponent<Player>().counter;
			float speed = currentVehicle.GetComponent<Player>().actualSpeed;
			Destroy(currentVehicle.GetComponents<BoxCollider>()[1]);
			Destroy(currentVehicle.GetComponent<Collision>());
			Destroy(currentVehicle.GetComponent<Player>());
			currentObjective.SetActive(false);
			lastActive += 1;
			currentObjective = Objectives[lastActive];
			currentVehicle = Vehicles[lastActive];
			if(currentHelper != null) currentHelper.active = false;
			currentHelper = Helpers[lastActive];
			if(currentHelper != null && !currentHelper.active) currentHelper.active = true;
			currentObjective.SetActive(true);
			currentVehicle.SetActive(true);
			currentVehicle.AddComponent(typeof(Player));
			currentVehicle.GetComponent<Player>().speed = 8;
			currentVehicle.GetComponent<Player>().acc = 2;
			currentVehicle.GetComponent<Player>().counter = ocounter;
			currentVehicle.GetComponent<Player>().oldSpeed = speed;
			currentVehicle.AddComponent<BoxCollider>();
			currentVehicle.GetComponents<BoxCollider>()[1].isTrigger = true;
			currentVehicle.AddComponent<Collision>();
			Counter.GetComponent<Counter>().player = currentVehicle;
			cam.GetComponent<Cam_Controller>().objTransform = currentVehicle.transform;
			Line.GetComponent<LineGuide>().currentObject = currentVehicle;
			Line.GetComponent<LineGuide>().objectiveObject = Objectives[lastActive];
			Counter.GetComponent<Counter>().UpdateLastRound();
		}
		else nextLevel();
		
	}
	public void nextLevel()
	{
		if(SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCount) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1, LoadSceneMode.Single);
		else endGame();
	}
	
	public void endGame()
	{
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}

	public void openMenu()
	{
		currentVehicle.GetComponent<Player>().pause = true;
		foreach (GameObject veh in Vehicles)
		{
			if(veh.gameObject.active && veh.GetComponent<NPC>() != null) 
			{
				veh.GetComponent<NPC>().pause = true;
			}
		}
		GameCanvas.SetActive(false);
		PauseCanvas.SetActive(true);
	}

	public void quitMenu()
	{
		currentVehicle.GetComponent<Player>().pause = false;
		foreach (GameObject veh in Vehicles)
		{
			if(veh.gameObject.active && veh.GetComponent<NPC>() != null) 
			{
				veh.GetComponent<NPC>().pause = false;
			}
		}
		GameCanvas.SetActive(true);
		PauseCanvas.SetActive(false);
	}

	public void rewindTime() 
	{

		foreach (GameObject veh in Vehicles)
		{
			if(veh.gameObject.active && veh.GetComponent<NPC>() != null) 
			{
				veh.GetComponent<NPC>().rewinding = true;
			}
		}
		currentVehicle.GetComponent<Player>().rewinding = true;
		Counter.GetComponent<Counter>().rewinding = true;
		if(currentHelper != null) currentHelper.GetComponent<MasterHelper>().Rewind();
	}

}

