using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour
{
	public int scoreValue;
	private GameController gameController;

	void OnTriggerEnter(Collider other) 
	{
		
		if (other.gameObject.CompareTag ( "Spike"))
		{
			
			Debug.Log("Hit");
		
			Application.LoadLevel (2);
			return;
			//GameController.GameOver ();
		}



	}
	// Use this for initialization
	void Start ()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null)
		{
			Debug.Log ("Cannot find 'GameController' script");
		}
	}

	// Update is called once per frame
	void Update () {

	}
}
