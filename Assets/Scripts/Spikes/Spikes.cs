/*
 * Ben - 3/26/2015
 * 
 * This script still needs to have the animate added
 * and be tested to see if the sending the damage
 * message works.
 * 
 * */


using UnityEngine;
using System.Collections;

public class Spikes : MonoBehaviour 
{
	public float damageValue = 1.0f;

	void awake()
	{
		Debug.Log ("Spikes are awake!");
	}

	/* This will check to see if the player has stepped onto the spikes
	 * if so then it will send a message to the player object to run
	 * the damage method.
	 * */
	void onTriggerStay(Collider other)
	{
		other.SendMessage("Damage", damageValue, SendMessageOptions.DontRequireReceiver);
	}
}
