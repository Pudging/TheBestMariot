using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public GameObject gameOverScreen;
    public BirdScript birdScript;
    public AudioSource sound;
    public AudioSource deathSound;

    private void Start()
    {
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();
    }
    public void addScore(int scoreToAdd)
    {
        if (birdScript.isAlive())
        {
            playerScore+=scoreToAdd;
            scoreText.text = playerScore.ToString();
            sound.Play();
        }

    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
        deathSound.Play();
    }
}
