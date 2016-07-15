using UnityEngine;
using System.Collections;

public class NPCEventScript : MonoBehaviour 
{
	public int eventNum;

	private GameObject player;
	PlayerScript playerScript;
	//NPCScript npcScript;

	public GameObject thing;
	
	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		playerScript = player.GetComponent<PlayerScript>();
		//npcScript = gameObject.GetComponent<NPCScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		switch (eventNum)
		{

		//npc disappears after player talks to it, and thing appears not null
		case 1:
			if (playerScript.HasSaveStuff("NPC " + gameObject.name))
			{
				if (thing != null)
				{
					thing.SetActive(true);
				}
				gameObject.SetActive(false);
				eventNum = 0;
			}
			break;

		}


	}
}
