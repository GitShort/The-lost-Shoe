using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
	[SerializeField] GameObject pauseText;
	[SerializeField] GameObject mainMenuText;
	GameOver gameover;
	bool pauseOpen = false;

	// Start is called before the first frame update
	void Start()
    {
		pauseText.SetActive(false);
		gameover = GetComponent<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
		pauseMenu();
    }

	void pauseMenu()
	{
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseOpen && !gameover.isDead && !gameover.won)
        {
            pauseText.SetActive(true);
            Time.timeScale = 0;
            pauseOpen = true;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && pauseOpen && !gameover.isDead && !gameover.won)
        {
            Time.timeScale = 1f;
            Application.Quit();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && pauseOpen && !gameover.isDead && !gameover.won)
        {
            pauseText.SetActive(false);
            Time.timeScale = 1;
            pauseOpen = false;
        }

	}

}
