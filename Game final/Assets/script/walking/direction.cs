using UnityEngine;
using System.Collections;

public class direction : MonoBehaviour 
{
	private Rigidbody2D myRigidbody;
	[SerializeField]
	private float movementSpeed;

	private bool facingRight;

	[SerializeField]
	private Transform[]groundPoints;

	[SerializeField]
	private float groundRadius;

	private LayerMask whatisGround;

	private bool isGrounded; 

	private bool jump;
	private float  jumpForce;



	// Use this for initialization
	void Start () 
	{
		facingRight = true;
		myRigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float horizontal = Input.GetAxis("Horizontal");
		Debug.Log (horizontal);

		isGounded = IsGrounded ();

		HandleMovement(horizontal);

		flip(horizontal);
	}

	private void HandleMovement(float horizontal)
	{
		myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y); 
	}

	if(isGrounded && jump)

	{
		isGrounded = false;
		myRigidbody.AddForce(new Vector2(0, jumpForce));
	}

	private void flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight) 
		{
			facingRight = !facingRight;

			Vector3 theScale = transform.localScale;

			theScale.x *= -1;

			transform.localScale = theScale;
		}

	}
	private bool IsGrounded()
	{
		if (myRigidbody.velocity.y <= 0) 
		{
			foreach(TRansform point in groundpoints)
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatisGround);

				for (int i = 0 < colliders.Length; i++)
				{
					if (colliders[i].gameObject != gameObject
					    {
						return true;

						{
				}
			}
		}
					return false;
	}
}
