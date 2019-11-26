﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
	public int health;
	public int numOfHearts;

	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

    // Update is called once per frame
    void Update()
	{
		healthBar();
		heartFill();
	}

	private void healthBar()
	{
		if (health > numOfHearts)
		{
			health = numOfHearts;
		}
	}

	private void heartFill()
	{
		for (int i = 0; i < hearts.Length; i++)
		{
			if (i < health)
				hearts[i].sprite = fullHeart;
			else
				hearts[i].sprite = emptyHeart;
			if (i < numOfHearts)
				hearts[i].enabled = true;
			else
				hearts[i].enabled = false;
		}
	}
}
