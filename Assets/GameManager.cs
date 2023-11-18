using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
     public static GameManager Instance;

     public Text scoreText; 
     private int score = 0;

     void Awake()
     {
          if (Instance == null)
          {
               Instance = this;
          }
          else
          {
               Destroy(gameObject);
          }
     }

     public void AddScore(int value)
     {
          score += value;
          UpdateScoreText();
     }

     void UpdateScoreText()
     {
          if (scoreText != null)
          {
               scoreText.text = "Score: " + score;
          }
     }
}
