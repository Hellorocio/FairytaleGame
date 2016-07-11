using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour 
{
	//display
	public GameObject prompt;
	private bool showTimedText = false;
	private float timer = 0f;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (showTimedText)
		{
			timer += Time.deltaTime;
			if (timer > 4f)
			{
				SetPromptText ("", false);
				showTimedText = false;
			}
		}
	}

	//shows message as prompt text, turns off prompt text if message is blank
	public void SetPromptText (string message, bool timed)
	{
		prompt.SetActive (!message.Equals (""));
		prompt.transform.FindChild ("Text").GetComponent<Text>().text = message;
		if (timed)
		{
			timer = 0f;
			showTimedText = true;
		}
	}

}
