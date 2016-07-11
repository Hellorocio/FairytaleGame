using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour 
{
	public Vector3 playerLocation; //where player stops to interact
	public bool pickup; //true if player can put in inventory
	public string description;

	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown() 
	{
		//inspect item, and put in inventory if possible
		player.SendMessage ("InspectItem", gameObject);
		if (pickup)
		{
			player.SendMessage("AddInventoryItem", gameObject);
		}
	}
}
