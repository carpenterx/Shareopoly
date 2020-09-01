using System.Collections.Generic;
using UnityEngine;

public class BoardDiceManager : MonoBehaviour
{
    public List<DiceSprite> diceSprites;
    private static int extraRerolls = 2;
    private int rerolls = extraRerolls;

    void Start()
    {
        //SaveInitialPositions();
        RollDice();
    }

    /*private void SaveInitialPositions()
    {
        for (int i = 0; i < diceSprites.Count; i++)
        {
            initialPositions.Add(diceSprites[i].transform.position);
        }
    }*/

    public void RollDice()
    {
        for (int i = 0; i < diceSprites.Count; i++)
        {
            diceSprites[i].Roll();
        }
    }

    public void RerollDice()
    {
        if(rerolls > 0)
        {
            for (int i = 0; i < diceSprites.Count; i++)
            {
                if (diceSprites[i].CanReroll())
                {
                    diceSprites[i].Roll();
                }
            }
            rerolls--;
        }
    }

    public List<int> GetDiceRolls()
    {
        List<int> rollsList = new List<int>();
        for (int i = 0; i < diceSprites.Count; i++)
        {
            rollsList.Add(diceSprites[i].GetDieValue());
        }
        return rollsList;
    }

    public void ResetDice()
    {
        rerolls = extraRerolls;
        for (int i = 0; i < diceSprites.Count; i++)
        {
            diceSprites[i].ResetDie();
        }
        RollDice();
    }
}
