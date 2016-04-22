using UnityEngine;
using System.Collections;

public class walking2 : MonoBehaviour 

	{
	private bool facingRight;

		public Transform myArt;
		public float speed = 5f;
		public float height = 5f;


		
		
		void Update ()
		{
		float horizontal = Input.GetAxis ("Horizontal");
			if (Input.GetKey(KeyCode.LeftArrow))
			{
			transform.position += Vector3.left * speed * Time.deltaTime;
				
			}
			if (Input.GetKey(KeyCode.RightArrow))
			{
			transform.position += Vector3.right * speed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.Space))
			{
			transform.position += Vector3.up * height * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
			transform.position += Vector3.down * speed * Time.deltaTime;


			}
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight;

			Vector3 theScale = myArt.localScale;

			theScale.x *= -1;
			myArt.localScale = theScale;
		}
		}
	}