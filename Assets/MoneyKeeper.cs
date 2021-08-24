using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyKeeper : MonoBehaviour
{
    public TextMeshProUGUI text;

    private int score = 0;

    private void Start()
    {
        score = 0;
    }

    public bool TryToSpend(int amount)
    {
        return false;
    }

    public void IncremetScore()
    {
        score++;
    }

    private void SetScore(int amount)
    {
        score = amount;
        text.text = "Score: \n\r" + score;
    }
}