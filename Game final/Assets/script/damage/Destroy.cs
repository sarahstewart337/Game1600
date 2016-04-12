using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{
	
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Player"))
		{
			Debug.Log("Hit");
			Destroy (gameObject);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
