using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text coinText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text highscoreText;

    private int scoreCount = 0;
    private int coinCount = 0;
    private int highscoreCount = 0;

    public static UIManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        highscoreText.text = "HIGHSCORE: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        StartCoroutine(AddToScore());
    }

    // Update is called once per frame
    void Update()
    {
        DisplayScore();

        Debug.Log(scoreCount);
    }

    public void AddCoin(int points)
    {
        coinCount += points;
        coinText.text = "COINS: " + coinCount.ToString();

        scoreCount += 5;
    }

    private void DisplayScore()
    {
        scoreText.text = "COINS: " + scoreCount.ToString();
        AddHighScore();
    }

    public void AddHighScore()
    {
        if (scoreCount > PlayerPrefs.GetInt("HighScore", scoreCount))
        {
            PlayerPrefs.SetInt("HighScore", scoreCount);
            highscoreText.text = "HIGHSCORE: " + scoreCount.ToString();
        }
    }

    IEnumerator AddToScore()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            scoreCount += 1;
        }
    }
}
