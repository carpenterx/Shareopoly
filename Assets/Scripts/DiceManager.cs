using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public List<DiceImage> diceList;

    public void RollDice()
    {
        int totalRoll = 0;
        foreach (DiceImage dice in diceList)
        {
            totalRoll += dice.Roll();
        }
        Debug.Log("Rolled: " + totalRoll);
    }
}
