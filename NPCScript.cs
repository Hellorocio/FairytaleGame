using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class NPCScript : MonoBehaviour 
{
	public Vector3 playerLocation; //where player stops to interact

	public TextAsset dialogue;
	private string[][] fullSpeech;
	public GameObject textBox;
	public Vector3 boxLocation; //where the text box will appear

	public bool playerTalk = false;
	private int currentLine = 0; //current line of dialogue, referring to fullSpeech[][x]
	private int textNumber = 0;		// the line of dialogue based on past interactions, referring to fullSpeech[x][]
	private string dialogueLine = "";
		
	private GameObject player;
	PlayerScript playerScript;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		playerScript = player.GetComponent<PlayerScript>();
		SetFullSpeech ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerTalk)
		{
			textBox.SetActive(true);			
			dialogueLine = fullSpeech[textNumber][currentLine];

			textBox.transform.FindChild ("Text").GetComponent<Text>().text = dialogueLine;
		}
		else
		{
			textBox.SetActive(false);
		}
	}
	
	void OnMouseDown() 
	{
		//start dialogue
		textBox.transform.position = boxLocation;
		player.transform.position = playerLocation;

		if (!playerTalk)
		{	
			//if player has talked to npc, go to next textNumber
			if (playerScript.HasSaveStuff("NPC " + gameObject.name) && (textNumber < fullSpeech.Length - 1))
			{
				textNumber++;
			}

			playerTalk = true;
			currentLine = 0;
			player.SendMessage ("StopMoving", true);
			playerScript.SetPromptText ("", false);
			
		}
		else
		{
			if (currentLine + 1 == fullSpeech[textNumber].Length)
			{
				playerTalk = false;
				textBox.SetActive(false);
				player.SendMessage ("StopMoving", false);
				player.SendMessage ("SetSaveStuff", "NPC " + gameObject.name);
			}
			else
			{
				currentLine++;
				//player.SendMessage("SetSaveStuff", "NPC " + gameObject.name + " " + textNumber);
			}
		}
	}

	void SetFullSpeech()
	{
		currentLine = 0;
		
		string[] temp = (dialogue.text.Split("#"[0]));
		fullSpeech = new string[temp.Length][];
		
		for (int i = 0; i < temp.Length; i++)
		{
			fullSpeech[i] = (temp[i].Split("\n"[0]));
		}
	}
}
