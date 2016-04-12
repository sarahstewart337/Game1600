using UnityEngine;
using System.Collections;

public class Load : MonoBehaviour
{

	public GameObject loadingImage;

	public void LoadScene(int play)
	{
		loadingImage.SetActive(true);
		Application.LoadLevel(play);
	}
}
