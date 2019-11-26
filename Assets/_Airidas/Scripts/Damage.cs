using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
	//public PlayerHealth playerH;
	[SerializeField] List<string> targetTag;
	[SerializeField] int damageDone = 2;
    PlayerHealth playerHealth;

	//private void OnTriggerEnter2D(Collider2D collision)
	//{
	//	if(collision.gameObject.tag == targetTag)
	//	{
	//		playerH.health--;
	//	}
	//}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (targetTag.Contains(collision.gameObject.tag))
		{
            playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
			FindObjectOfType<AudioManager>().Play("MonsterHit");
            playerHealth.health = playerHealth.health - damageDone;
            if (playerHealth.health > 0)
            {
                collision.gameObject.GetComponent<Invulnerability>().StartCoorutine();
            }
		}
		
	}
}
