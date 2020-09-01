using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public TextMesh scoreText;
    private int currentScore = 0;

    private void Start()
    {
        UpdateScore();
    }

    public void CalculateScore(List<int> diceRolls, string combinationName)
    {
        //currentScore += 20;
        switch (combinationName)
        {
            case "Ones":
                currentScore += ScoreRepetitions(1, diceRolls);
                break;
            case "Twos":
                currentScore += ScoreRepetitions(2, diceRolls);
                break;
            case "Threes":
                currentScore += ScoreRepetitions(3, diceRolls);
                break;
            case "Fours":
                currentScore += ScoreRepetitions(4, diceRolls);
                break;
            case "Fives":
                currentScore += ScoreRepetitions(5, diceRolls);
                break;
            case "Sixes":
                currentScore += ScoreRepetitions(6, diceRolls);
                break;
            case "Full House":
                currentScore += ScoreFullHouse(diceRolls);
                break;
            case "Four-Of-A-Kind":
                currentScore += ScoreFourOfAKind(diceRolls);
                break;
            case "Little Straight":
                currentScore += ScoreLittleStraight(diceRolls);
                break;
            case "Big Straight":
                currentScore += ScoreBigStraight(diceRolls);
                break;
            case "Choice":
                currentScore += ScoreChoice(diceRolls);
                break;
            case "Yacht":
                currentScore += ScoreYacht(diceRolls);
                break;
            default:
                break;
        }

        UpdateScore();
    }

    private int ScoreRepetitions(int value, List<int> diceRolls)
    {
        int score = 0;
        for (int i = 0; i < diceRolls.Count; i++)
        {
            if(diceRolls[i] == value)
            {
                score += value;
            }
        }
        return score;
    }

    private int ScoreFullHouse(List<int> diceRolls)
    {
        int score = 0;
        int valueOccuringTwoTimes = 0;
        int valueOccuringThreeTimes = 0;
        var groups = diceRolls.GroupBy(i => i);
        foreach (var group in groups)
        {
            int count = group.Count();
            if (count == 2)
            {
                valueOccuringTwoTimes = group.Key;
            }
            if (count == 3)
            {
                valueOccuringThreeTimes = group.Key;
            }
        }
        if(valueOccuringTwoTimes != 0 && valueOccuringThreeTimes != 0)
        {
            score = (valueOccuringTwoTimes * 2) + (valueOccuringThreeTimes * 3);
        }
        return score;
    }

    private int ScoreFourOfAKind(List<int> diceRolls)
    {
        int score = 0;
        int valueOccuringFourTimes = 0;
        var groups = diceRolls.GroupBy(i => i);
        foreach (var group in groups)
        {
            int count = group.Count();
            if (count == 4 || count == 5)
            {
                valueOccuringFourTimes = group.Key;
            }
        }
        if (valueOccuringFourTimes != 0)
        {
            score = valueOccuringFourTimes * 4;
        }
        return score;
    }

    private int ScoreLittleStraight(List<int> diceRolls)
    {
        int score = 0;
        if(diceRolls.Contains(1) && diceRolls.Contains(2) && diceRolls.Contains(3) && diceRolls.Contains(4) && diceRolls.Contains(5))
        {
            score = 30;
        }
        return score;
    }

    private int ScoreBigStraight(List<int> diceRolls)
    {
        int score = 0;
        if (diceRolls.Contains(2) && diceRolls.Contains(3) && diceRolls.Contains(4) && diceRolls.Contains(5) && diceRolls.Contains(6))
        {
            score = 30;
        }
        return score;
    }

    private int ScoreChoice(List<int> diceRolls)
    {
        int score = 0;
        for (int i = 0; i < diceRolls.Count; i++)
        {
            score += diceRolls[i];
        }
        return score;
    }

    private int ScoreYacht(List<int> diceRolls)
    {
        int score = 0;
        int valueOccuringFiveTimes = 0;
        var groups = diceRolls.GroupBy(i => i);
        foreach (var group in groups)
        {
            int count = group.Count();
            if (count == 5)
            {
                valueOccuringFiveTimes = group.Key;
            }
        }
        if (valueOccuringFiveTimes != 0)
        {
            score = 50;
        }
        return score;
    }

    private void UpdateScore()
    {
        scoreText.text = currentScore.ToString();
    }
}
