using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBullet : MonoBehaviour
{
	public float bulletSpeed = 50f;
    //public SpiderEnemy enemy;
    public GameObject destroyEffect;
    Transform player;
    Vector3 targetPosition;
    Vector3 normalized;
    bool shot = false;
    Rigidbody2D rb;

	public PlayerHealth health;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!shot)
        {
            targetPosition = player.position;
            shoot();
            shot = true;
        }
        targetPosition += normalized;
        shoot();

    }

    void shoot()
    {
        Vector2 position = targetPosition - transform.position;
        position.Normalize();
        if (!shot)
        {
            normalized = position;
        }
        rb.MovePosition((Vector2)transform.position + (position * bulletSpeed * Time.deltaTime));
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Wall")
		{
			FindObjectOfType<AudioManager>().Play("WallHit");
			destroyProjectile();
		}
		else if(collision.gameObject)
		{
			destroyProjectile();
		}
	}

	private void destroyProjectile()
	{
		GameObject clonedParticles = Instantiate(destroyEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
		Destroy(clonedParticles, 1f);
	}
}
