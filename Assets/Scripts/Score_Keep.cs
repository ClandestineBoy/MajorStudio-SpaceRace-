using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Keep : MonoBehaviour
{
    public int score;
    public string scoreDisplay;
    public Text display;

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay = score + "";
        display.text = scoreDisplay;
    }
}
