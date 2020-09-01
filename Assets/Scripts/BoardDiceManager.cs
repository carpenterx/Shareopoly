using System.Collections.Generic;
using UnityEngine;

public class BoardDiceManager : MonoBehaviour
{
    public List<DiceSprite> diceSprites;
    private List<Vector3> initialPositions = new List<Vector3>();
    private int rerolls = 2;

    void Start()
    {
        SaveInitialPositions();
        RollDice();
    }

    private void SaveInitialPositions()
    {
        for (int i = 0; i < diceSprites.Count; i++)
        {
            initialPositions.Add(diceSprites[i].transform.position);
        }
    }

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

    private void ResetDice()
    {
        rerolls = 2;
        for (int i = 0; i < diceSprites.Count; i++)
        {
            diceSprites[i].transform.position = initialPositions[i];
        }
        RollDice();
    }
}
