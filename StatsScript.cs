using UnityEngine;
using System.Collections;

[System.Serializable]
public class PlayerStats 
{ //don't need ": Monobehaviour" because we are not attaching it to a game object
	
	public static PlayerStats current; //the saved game
	public static PlayerStats game = new PlayerStats(); //the unsaved game
	//clone when you save
	
	//changeable stuff
	public ArrayList inventory = new ArrayList();
	public ArrayList saveStuff = new ArrayList();
	//money? health?
	
	public PlayerStats () 
	{
		inventory = new ArrayList();
	}
	
	public void SetStuff (ArrayList i, ArrayList saveS) //add all the changeable stuff for saving
	{
		inventory = (ArrayList)i.Clone();
		saveStuff = (ArrayList)saveS.Clone();
	}
	
}
