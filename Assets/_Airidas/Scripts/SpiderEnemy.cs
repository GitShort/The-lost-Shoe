using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderEnemy : MonoBehaviour
{
	public Transform player;
	private Rigidbody2D rb;
	public Vector2 movement;

	public float moveSpeed = 5f;

	public GameObject projectile;
	[SerializeField] float startTimeBtwShots;
	private float timeBtwShots;

	// Start is called before the first frame update
	void Start()
	{
		rb = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Shoot();
		Vector3 direction = player.position - transform.position;
		float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
		rb.rotation = angle;
		direction.Normalize();
		movement = direction;
	}

	private void Shoot()
	{
		if (timeBtwShots <= 0)
		{
			Instantiate(projectile, transform.position, Quaternion.identity);
			timeBtwShots = startTimeBtwShots;
		}
		else
			timeBtwShots -= Time.deltaTime;
	}

	private void FixedUpdate()
	{
		moveCharacter(movement);
	}

	void moveCharacter(Vector2 direction)
	{
		rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
	}
}
