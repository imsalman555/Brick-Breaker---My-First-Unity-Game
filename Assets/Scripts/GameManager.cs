using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public int lives;
    public Text ScoreT;
    public Text LivesT;
    public bool lastLife;
    public GameObject gop;
    int bricksCount;
    public Transform paddle;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ScoreT.text = "Score : " + score;
        LivesT.text = "Lives : " + lives;
        bricksCount = GameObject.FindGameObjectsWithTag("Brick").Length;
     }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLives()
    {
        lives--;
        if (lives == 0)
            GameOver();
        LivesT.text = "Lives : " + lives;
    }
    public void UpdateScore(int points)
    {
        score += points;
        ScoreT.text = "Score : " + score;
    }
    public void UpdateBricks()
    {
        bricksCount--;
        if (bricksCount == 0)
            GameOver();
    }
    public void GameOver()
    {
        lastLife = true;
        paddle.position = new Vector2(0f, -4.79f);
        ball.GetComponent<Rigidbody2D>().AddForce(Vector2.zero);
        ball.transform.position= new Vector2(0f, -4.5f);
        gop.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
