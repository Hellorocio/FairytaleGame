using UnityEngine;
using System.Collections;

public class ItemScript : MonoBehaviour 
{
	public Vector3 playerLocation; //where player stops to interact
	public bool pickup; //true if player can put in inventory
	public string description;
	public int useNum; //if not 0, determines what happens when "use" is pressed in the backpack

	private GameObject player;
	MovementScript movementScript;

	// Use this for initialization
	void Start () 
	{
		player = GameObject.FindWithTag("Player");
		movementScript = player.GetComponent<MovementScript>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnMouseDown() 
	{
		//inspect item, and put in inventory if possible
		movementScript.InspectItem (gameObject, pickup);
	}
}


