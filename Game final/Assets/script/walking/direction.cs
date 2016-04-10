using UnityEngine;
using System.Collections;

public class direction : MonoBehaviour 
{
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag ( "Player"))
		{
			Debug.Log("Hit");
			Destroy (gameObject);
		}
	}




	private Rigidbody myRigidbody;



	[SerializeField]
	private float movementSpeed;

	private bool facingRight;

	[SerializeField]
	private Transform[] groundPoints;

	[SerializeField]
	private float groundRadious;

	[SerializeField]
	private LayerMask whatIsGround;

	private bool isGrounded;

	private bool jump;

	[SerializeField]
	private bool airControl;

	[SerializeField]
	private float jumpForce;

	// Use this for initialization
	void Start () 
	{
		facingRight = true;
		myRigidbody = GetComponent<Rigidbody> ();

	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		float horizontal = Input.GetAxis ("Horizontal");

		//isGrounded = IsGrounded();

		HandleMovement (horizontal);

		HandleInput ();

		Flip (horizontal);

		ResetValues ();
	}

	private void HandleMovement(float horizontal)
	{
		if (isGrounded || airControl)
		{
			myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y);
		}


	}

	private void HandleInput ()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			jump = true;
		}

		if (isGrounded && jump) 
		{
			isGrounded = false;
			myRigidbody.AddForce(new Vector2(0,jumpForce));
		}
	}

	private void Flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
		{
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;

			theScale.x *= -1;
			transform.localScale = theScale;
		}
	}

	private void ResetValues()
	{
		jump = false;
	}

	/*private bool IsGrounded()
	{
		if (myRigidbody.velocity.y <= 0) 
		{
			foreach (Transform point in groundPoints)
			{
				Collider[] colliders = Physics.OverlapBox(point.position,point.rotation, whatIsGround);

				for (int i = 0; i < colliders.Length; i++)
				{
					if (colliders[i].gameObject != gameObject)
					{
						return true;
					}
				}
			}
		}
		return false;
	}*/
}