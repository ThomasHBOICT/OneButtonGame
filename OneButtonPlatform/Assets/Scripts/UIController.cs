using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class UIController : MonoBehaviour
{
    public GameObject deathScreen;
    public GameObject shopScreen;
    public TextMeshProUGUI thisScore;
    public FloatValue currentScore;

    public PlayerMovement player;
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

    public void OpenShop()
    {
        shopScreen.SetActive(true);
        Time.timeScale = 0;
        Debug.Log("shop entered");
    }

    public void CloseShop()
    {
        shopScreen.SetActive(false);
        Time.timeScale = 1;
        Debug.Log("shop left");
    }

    public void BuyJumpForce()
    {
        Debug.Log("jumpforce bought");
        player.AddJumpForce();
    }
}
