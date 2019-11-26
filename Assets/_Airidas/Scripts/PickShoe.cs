using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickShoe : MonoBehaviour
{
	public Transform theDestination;

	private Rigidbody2D rb;
	[SerializeField] BoxCollider2D col;

	public bool inRadius = false;
	public bool isPickedUp = false;
	public bool shoeFound = false;

	public Player player;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		//col = GetComponent<BoxCollider2D>();
	}

	private void Update()
	{
		pickUpObject();
		
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "PickUpRadius")
		{
			inRadius = true;
		}
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
		if (collision.tag == "PickUpRadius")
		{
			inRadius = false;
		}
	}

	void pickUpObject()
	{
		if (Input.GetKeyDown(KeyCode.E) && inRadius && !isPickedUp && player.count < 1)
		{
			pickedUp();
		}
	}

	public void pickedUp()
	{
		shoeFound = true;
		col.enabled = false;
		rb.isKinematic = true;
		isPickedUp = true;
		this.transform.position = theDestination.position;
		this.transform.parent = GameObject.Find("Destination").transform;
	}
}
