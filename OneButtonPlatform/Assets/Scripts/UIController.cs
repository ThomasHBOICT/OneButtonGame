using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject deathScreen;
    public TextMeshProUGUI thisScore;
    public FloatValue currentScore;
    public void OpenDeathScreen()
    {
        deathScreen.SetActive(true);
        ScoreThisRun();
    }

    public void ScoreThisRun()
    {
        thisScore.text = Mathf.Round(currentScore.@float).ToString();
    }
    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
