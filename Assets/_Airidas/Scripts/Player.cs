using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	//public Animator animator;
	[SerializeField] float moveSpeed;
	Vector3 movement;
	private Rigidbody2D rb;

	public Animator animator;
	bool facingFront = false, facingLeft = false, facingRight = false, facingUp = false;

	//public PickUp pickup;
	public int count = 0;

	void Start()
    {
		rb = GetComponent<Rigidbody2D>();
    }

    void Update()
	{
		Movement();
		IdleAnimationConfig();
	}

	private void Movement()
	{
		movement = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed, 0.0f);

		////animator.SetFloat("Horizontal", Input.GetAxis("Horizontal"));		
		//transform.position = transform.position + movement * moveSpeed * Time.deltaTime;

		animator.SetFloat("Horizontal", movement.x);
		animator.SetFloat("Vertical", movement.y);
		animator.SetFloat("Magnitude", movement.magnitude);

		rb.velocity = new Vector2(movement.x, movement.y);
	}

	private void IdleAnimationConfig()
	{
		if (Input.GetAxis("Horizontal") > 0)
		{
			facingRight = true;
			facingFront = false;
			facingLeft = false;
			facingUp = false;
		}
		if (Input.GetAxis("Horizontal") < 0)
		{
			facingLeft = true;
			facingRight = false;
			facingFront = false;
			facingUp = false;
		}
		if (Input.GetAxis("Vertical") > 0)
		{
			facingUp = true;
			facingLeft = false;
			facingRight = false;
			facingFront = false;
		}

		if (Input.GetAxis("Vertical") < 0)
		{
			facingFront = true;
			facingLeft = false;
			facingRight = false;
			facingUp = false;
		}

		animator.SetBool("isRight", facingRight);
		animator.SetBool("isLeft", facingLeft);
		animator.SetBool("isUp", facingUp);
		animator.SetBool("isFront", facingFront);
	}
}
