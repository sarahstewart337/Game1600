using UnityEngine;
using System.Collections;

public class direction : MonoBehaviour
{  
	private Rigidbody2D myRigidbody;
	private Animator myAnimator;
	
	[SerializeField]
	private float moventSpeed;
	private bool attack;
	private bool slide;
	private bool facingRight;
	
	[SerializeField]
	private Transform[] GroundPoints;
	
	[SerializeField]
	private float groundRadius;
	
	private LayerMask whatIsGround;
	
	private bool isGrounded;
	private bool jump;
	private float JumpForce;
	
	
	// Use this for initialization
	void Start()
	{
		facingRight = true;
		myRigidbody = GetComponent <Rigidbody2D>();

	}
	
	void Update()
	{
		HandleInput();
	}
	
	// Update is called once per frame
	void FixedUpdate()
	{
		float horizontal = Input.GetAxis ("Horizontal");
		
		isGrounded = IsGrounded();
		
		HandleMovement (horizontal);
		
		Flip(horizontal);
		
		Handleattacks();
		
		ResetValues();
		
	}
	
	private void HandleMovement(float horizontal)
	{
		if (!myAnimator.GetBool("slide") && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
		{
			myRigidbody.velocity = new Vector2(horizontal * moventSpeed, myRigidbody.velocity.y);
		}
		
		if (isGrounded && jump)
		{
			isGrounded = false;
			myRigidbody.AddForce (new Vector2 (0, JumpForce));
		}
		
		if (slide && !this.myAnimator.GetCurrentAnimatorStateInfo (0).IsName ("slide")) {
			myAnimator.SetBool ("slide", true);
		}
		else if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
		{
			myAnimator.SetBool ("slide", false);
		}
		
		
		myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
	}
	
	private void Handleattacks()
	{
		if (attack && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
		{
			myAnimator.SetTrigger("attack");
			myRigidbody.velocity = Vector2.zero;
		}
	}
	
	private void HandleInput()
	{
		
		if (Input.GetKeyDown (KeyCode.Space))
		{
			jump = true;
		}
		
		if (Input.GetKeyDown (KeyCode.Mouse0))
		{
			attack = true;
		}
		if (Input.GetKeyDown (KeyCode.LeftShift))
		{
			slide = true;
			
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
		attack = false;
		slide = false;
	}
	
	
	
	private bool IsGrounded()
		
	{
		
		if (myRigidbody.velocity.y <= 0)
		{
			foreach (Transform point in GroundPoints)
			{
				BoxCollider[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
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
	}
}