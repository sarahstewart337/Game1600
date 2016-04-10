using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour 
{

	void OnTriggerEnter2d(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("coin"))
		{
			other.gameObject.SetActive (false);
		}
	}
	}
	

