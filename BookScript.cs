using UnityEngine;
using System.Collections;

public class BookScript : MonoBehaviour 
{
	private int currentPage = 0;
	public GameObject[] pages;
	public GameObject[] buttons;

	private GameObject player;
	StoryScript storyScript;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		storyScript = player.GetComponent<StoryScript>();

		pages [0].SetActive (true);
		buttons [0].SetActive (false);
		buttons [1].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	//right is true if right button was pressed
	public void SetPage (bool right)
	{
		pages [currentPage].SetActive (false);
		if (right)
		{
			currentPage++;
		}
		else
		{
			currentPage--;
		}
		pages [currentPage].SetActive (true);

		buttons [0].SetActive (currentPage != 0);
		buttons [1].SetActive (currentPage < pages.Length - 1);
	}

	public void CloseBook ()
	{
		if (storyScript.storyStep == 5)
		{
			player.SendMessage ("SetStoryStep");
		}

		player.SendMessage ("StopMoving", false);
		gameObject.SetActive (false);
	}
}
