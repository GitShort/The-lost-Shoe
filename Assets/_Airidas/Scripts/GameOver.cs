using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
	public PlayerHealth health;
	public Animator animator;
	public bool isDead = false;
    public bool won = false;
	[SerializeField] GameObject loseText;
	[SerializeField] GameObject winText;

	public PickShoe shoe;

    // Start is called before the first frame update
    void Start()
    {
		loseText.SetActive(false);
		winText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
		loseGame();
		winGame();
    }

	void loseGame()
	{
		if(health.health < 1)
		{
			loseText.SetActive(true);
			isDead = true;
			Time.timeScale = 0f;
			RestartSpace();
		}
		animator.SetBool("isDead", isDead);
	}

	void winGame()
	{
		if(shoe.shoeFound)
        {
			winText.SetActive(true);
            won = true;
            Time.timeScale = 0f;
            RestartSpace();
		}
	}

	private static void RestartSpace()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			Time.timeScale = 1f;
			SceneManager.LoadScene("SampleScene");
		}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 1f;
            Application.Quit();
        }
	}

	private static void Restart()
	{
		if (Input.anyKeyDown)
		{
			Time.timeScale = 1f;
			SceneManager.LoadScene("SampleScene");
		}
	}
}
