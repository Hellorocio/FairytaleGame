using UnityEngine;
using System.Collections;

public class RoomScript : MonoBehaviour 
{
	public int roomNum;
	public GameObject clickPlaces;
	public Vector3[] startPositions;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	//if true enter room, if false leave room
	public void EnterRoom (bool enter)
	{
		clickPlaces.SetActive(enter);
		gameObject.SetActive (enter);
	}


}
