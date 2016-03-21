﻿using UnityEngine;
using System.Collections;

public class walking2 : MonoBehaviour 

	{
		public float speed = 5f;
		
		void Update ()
		{
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
				transform.position += Vector3.up * speed * Time.deltaTime;
			}
			if (Input.GetKey(KeyCode.DownArrow))
			{
				transform.position += Vector3.down * speed * Time.deltaTime;
			}
		}
	}