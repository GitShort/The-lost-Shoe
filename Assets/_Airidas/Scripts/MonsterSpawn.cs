using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpawn : MonoBehaviour
{
	public GameObject[] monsters;
    // Start is called before the first frame update
    void Start()
    {
		foreach (var monster in monsters)
		{
			monster.SetActive(false);
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.gameObject.tag == "Player")
		{
			foreach (var monster in monsters)
				monster.SetActive(true);
			Destroy(this.gameObject);
		}
	}
}
