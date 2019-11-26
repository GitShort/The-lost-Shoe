using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
	[SerializeField] int Health;
	[SerializeField] GameObject destroyParticles;

    // Update is called once per frame
    void Update()
    {
        if(Health <= 0)
		{
			Debug.Log("Killed");
			deathParticles();
		}
    }

	void deathParticles()
	{
		GameObject clonedParticles = Instantiate(destroyParticles, transform.position, Quaternion.identity);
		Destroy(gameObject);
		Destroy(clonedParticles, 1f);
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "Thrown")
		{
			FindObjectOfType<AudioManager>().Play("PlayerHit");
			Health--;
		}
	}
}
