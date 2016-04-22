using UnityEngine;
using System.Collections;

public class pause : MonoBehaviour {

	bool paused = false;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
			togglePause();
	}
	void togglePause()
	{
		if (paused)
		{
			Time.timeScale = 1f;
			paused = false;
		}
		else
		{
			Time.timeScale = 0f;
			paused = true;
		}
	}
}