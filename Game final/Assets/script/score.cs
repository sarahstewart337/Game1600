using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class score : MonoBehaviour {

	public float speed;
	public Text ScoreText;
	public Text winText;

	private Rigidbody rb;
	private int Score;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		Score = 0;
		SetScoreText ();
		winText.text = "";
	}



	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "coin"))
		{
			other.gameObject.SetActive (false);
			Score = Score + 1;
			SetScoreText ();
		}
	}

	void SetScoreText ()
	{
		ScoreText.text = "Score: " + Score.ToString ();
		if (Score >= 11)
		{
			winText.text = "You Win!";
		}
	}
}