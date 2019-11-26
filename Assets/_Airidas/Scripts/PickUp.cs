using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
	public Transform theDestination;

	private Rigidbody2D rb;
	[SerializeField] BoxCollider2D col;

	// throwing values
	public float throwSpeed = 50f;
	public ObjectRotation objRotation;
	float distance;
	Vector2 direction;
	bool isThrown = false;
	[SerializeField] GameObject destroyParticles;
	//
	[SerializeField] GameObject item;

	public SpriteRenderer rend;

	public bool inRadius = false;
	public bool isPickedUp = false;

	public Player player;

	private void Start()
	{
		rb = GetComponent<Rigidbody2D>();
		//col = GetComponent<BoxCollider2D>();
	}

	private void Update()
	{
		pickUpObject();
		throwObject();
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

	void throwObject()
	{
		if (Input.GetMouseButtonDown(0) && isPickedUp && player.count >= 1)
		{
			distance = objRotation.difference.magnitude;
			direction = objRotation.difference / distance;
			direction.Normalize();
			thrown(direction);
		}
	}

	public void pickedUp()
	{
		player.count++;
		col.enabled = false;
		rb.isKinematic = true;
		isPickedUp = true;
		this.transform.position = theDestination.position;
		this.transform.parent = GameObject.Find("Destination").transform;
		rend.sortingOrder = 11;
	}

	public void thrown(Vector2 direction)
	{
		player.count--;
		this.transform.parent = null;
		rb.isKinematic = false;
		isPickedUp = false;
		col.enabled = true;
		isThrown = true;
		rb.velocity = throwSpeed * direction;
		gameObject.tag = "Thrown";
		item.gameObject.layer = 12;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(isThrown && collision.gameObject.tag == "Enemy")
		{
			destroyThrownObject();
		}
		else if(isThrown && collision.gameObject)
		{
			FindObjectOfType<AudioManager>().Play("WallHit");
			destroyThrownObject();
		}
	}

	private void destroyThrownObject()
	{
		GameObject clonedParticles = Instantiate(destroyParticles, transform.position, Quaternion.identity);
		Destroy(gameObject);
		Destroy(clonedParticles, 1f);
	}
}
