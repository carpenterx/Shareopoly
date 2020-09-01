using UnityEngine;

public class Reroll : MonoBehaviour
{
    public BoardDiceManager diceManager;
    public ScoreKeeper scoreKeeper;
    public GameObject combinationsHolder;

    public TextMesh buttonText;
    private static string REROLL_LABEL = "REROLL";
    private static string NEW_GAME_LABEL = "NEW GAME";

    private void OnMouseDown()
    {
        if(scoreKeeper.IsGameOver())
        {
            scoreKeeper.ResetScore();
            diceManager.ResetDice();
            Combination[] combinations = combinationsHolder.GetComponentsInChildren<Combination>();
            for (int i = 0; i < combinations.Length; i++)
            {
                combinations[i].EnableCombination();
            }
            SetRerollLabel();
        }
        else
        {
            diceManager.RerollDice();
        }
    }

    public void SetRerollLabel()
    {
        SetLabel(REROLL_LABEL);
    }

    public void SetNewGameLabel()
    {
        SetLabel(NEW_GAME_LABEL);
    }

    private void SetLabel(string label)
    {
        buttonText.text = label;
    }
}
