using UnityEngine;
using System.Collections;

public class StoryScript : MonoBehaviour 
{
	public int storyStep = 5;

	//stuff that changes when story happens
	//public GameObject[] buttons;
	public GameObject[] characters;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (storyStep)
		{
		//emperor appears
		case 6: 
			characters[0].SetActive(true);
			break;
		}
	}

	public void SetStoryStep ()
	{
		storyStep++;
	}
}
