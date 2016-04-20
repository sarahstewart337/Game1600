using UnityEngine;
using System.Collections;

public class Spike : MonoBehaviour
{

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Spike"))
		{
			Debug.Log("Hit");
			Destroy (gameObject);
			GameController.GameOver ();
		}
	}
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
