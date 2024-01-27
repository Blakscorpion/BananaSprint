using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ScoringManager : MonoBehaviour
{
    public static ScoringManager instance;
    [SerializeField]
    private int hitScoreValue;
    public int currentScore;
    [SerializeField] 
    private TextMeshProUGUI scoreText;
    // Start is called before the first frame update

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentScore = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            AddScore();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            ReduceScore();
        }
    }

    public void AddScore()
    {
        currentScore += hitScoreValue;
        scoreText.text = currentScore.ToString();
    }

    public void ReduceScore()
    {
        currentScore -= hitScoreValue;
        if (currentScore < 0) { currentScore = 0; }
        scoreText.text = currentScore.ToString();
    }
}
