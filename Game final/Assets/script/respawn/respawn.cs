using UnityEngine;
using System.Collections;

public class respawn : MonoBehaviour 
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		var deathHeight : float = -5;
		
		if(Transform.Position.Y <= deathHeight)
		{
			respawn();
		}

	}
}
