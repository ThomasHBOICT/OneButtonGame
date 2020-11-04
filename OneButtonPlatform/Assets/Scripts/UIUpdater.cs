using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScore;
    public TextMeshProUGUI coinScore;
    public FloatValue highScoreFloat;
    public FloatValue coinScoreFloat;

    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = Mathf.Round(player.transform.position.y).ToString();
        highScore.text = Mathf.Round(highScoreFloat.@float).ToString();
        coinScore.text = Mathf.Round(coinScoreFloat.@float).ToString();
    }
}
