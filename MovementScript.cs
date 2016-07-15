using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour 
{
	public int currentRoom;
	public GameObject[] rooms;

	RoomScript roomScript;
	PlayerScript playerScript;
	ItemScript itemScript;

	private bool talking = false; //true if talking to NPC, turns off inspection & moving

	// Use this for initialization
	void Start () 
	{
		roomScript = rooms [currentRoom].GetComponent<RoomScript>();
		playerScript = gameObject.GetComponent<PlayerScript>();
		ChangeRoom (currentRoom);
	}
	
	// Update is called once per frame
	void Update () 
	{
	}

	//switches currentRoom to roomNum & moves player to startPosition[oldroom] 
	public void ChangeRoom (int roomNum)
	{
		int oldRoom = currentRoom;

		if (currentRoom == roomNum)
		{
			oldRoom = 0;
		}

		currentRoom = roomNum;
		roomScript = rooms [currentRoom].GetComponent<RoomScript>();

		if (roomScript.startPositions.Length > oldRoom)
		{
			PlayerMove(roomScript.startPositions[oldRoom]);
		}


		roomScript.EnterRoom (true);
		for (int i = 0; i < rooms.Length; i++)
		{
			if (i != currentRoom && rooms [i].activeSelf)
			{
				rooms [i].SendMessage("EnterRoom", false);
			}
		}

		playerScript.SetPromptText ("", false);
	}

	//moves player to item and shows descriptive text, adds item to inventory if pickup
	public void InspectItem (GameObject item, bool pickup)
	{
		if (!talking)
		{
			itemScript = item.GetComponent<ItemScript>();
			playerScript.SetPromptText (itemScript.description, true);

			PlayerMove (itemScript.playerLocation);

			if (pickup)
			{
				SendMessage("AddInventoryItem", item);
			}
		}
	}

	public void PlayerMove (Vector3 location)
	{
		//eventually animate here
		gameObject.transform.position = location;

		//probably temporary, turns player when needed
		if ((gameObject.transform.rotation.y != 1 && location.z == 1) || (gameObject.transform.rotation.y == 1 && location.z != 1))
		{
			gameObject.transform.Rotate(0, 180, 0);
		}
	}

	//prevents player from moving
	public void StopMoving (bool set)
	{
		roomScript.clickPlaces.SetActive(!set);
		talking = set;
	}
}
