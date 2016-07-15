using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BackpackScript : MonoBehaviour 
{
	public GameObject backpack;
	public GameObject[] inventoryStuff;	//all inventory boxes
	public GameObject openButton;
	public GameObject useButton;

	PlayerScript playerScript;
	ItemScript itemScript;
	private int selectedThing = 0;

	//"use" button things for special items
	public GameObject book;


	// Use this for initialization
	void Start () 
	{
		playerScript = gameObject.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	// open/close backpack
	public void SetBackpack (bool set)
	{
		//enable or disable button
		openButton.SetActive (!set);

		//enable or disable player movement
		gameObject.SendMessage ("StopMoving", set);
			
		//set inventory
		for (int i = 0; i < 6; i++)
		{
			if (i < PlayerStats.game.inventory.Count && PlayerStats.game.inventory[i] != null)
			{
				GameObject item = (GameObject)PlayerStats.game.inventory[i];
				inventoryStuff[i].SetActive(true);
				inventoryStuff[i].transform.FindChild ("Text").GetComponent<Text> ().text = item.name;
				inventoryStuff[i].GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
			}
			else
			{
				inventoryStuff[i].SetActive(false);
			}
		}
		useButton.SetActive (false);
		backpack.SetActive (set);

		if (!set)
		{
			playerScript.SetPromptText ("", false);
		}
	}

	//set prompt to description, happens when player clicks item in inventory
	public void ViewItemStats(int itemNum)
	{
		GameObject item = (GameObject)PlayerStats.game.inventory[itemNum];
		itemScript = item.GetComponent<ItemScript> ();
		playerScript.SetPromptText (itemScript.description, false);
		if (itemScript.useNum != 0)
		{
			useButton.SetActive(true);
		}
		else
		{
			useButton.SetActive(false);
		}
	}

	//uses item if usable
	public void UseInventoryItem ()
	{
		if (selectedThing >= 0)
		{
			switch (itemScript.useNum)
			{
			//open book
			case 1:
				book.SetActive(true);
				SetBackpack(false);
				gameObject.SendMessage ("StopMoving", true);
				break;
			}
		}
	}

	//if we need to drop things, nothing uses this yet
	public void DropInventoryItem ()
	{
		if (selectedThing >= 0)
		{
			PlayerStats.game.inventory.RemoveAt(selectedThing);
			SetBackpack(true);
		}
	}

	//adds item to inventory
	public void AddInventoryItem (GameObject item)
	{
		//if inventory not full, add the thing and open backpack to show it
		if (PlayerStats.game.inventory.Count < 6)
		{
			item.SetActive(false);
			PlayerStats.game.inventory.Add(item);
			playerScript.SetPromptText("", false);

			SetBackpack(true);
			ViewItemStats(PlayerStats.game.inventory.IndexOf(item));
		}
		else
		{
			//inventory is full, so pop up with a warning
			playerScript.SetPromptText ("Inventory full", true);
			//print ("full");
		}
	}
}
