using UnityEngine;
using System.Collections;

public class MovementScript : MonoBehaviour 
{
	private int currentRoom = 0;
	public GameObject[] rooms;

	RoomScript roomScript;
	PlayerScript playerScript;
	ItemScript itemScript;

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
		currentRoom = roomNum;
		roomScript = rooms [currentRoom].GetComponent<RoomScript>();
		PlayerMove(roomScript.startPositions[oldRoom]);


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

	//moves player to item and shows descriptive text
	public void InspectItem (GameObject item)
	{
		itemScript = item.GetComponent<ItemScript>();
		playerScript.SetPromptText (itemScript.description, true);

		PlayerMove (itemScript.playerLocation);
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
}
