using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI score_text;
    public GameObject gameOverScreen;

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore += 1;
        score_text.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void gameOver()
    {
        gameOverScreen.SetActive(true);
    }
}
