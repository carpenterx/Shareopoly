using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceManager : MonoBehaviour
{
    public List<DiceImage> diceList;

    public GameObject player;
    public GameObject tilesHolder;

    public CameraScroll cameraScroll;

    private List<Transform> tileList = new List<Transform>();
    private int curentTileIndex = 0;
    private IEnumerator cameraTransition;

    void Start()
    {
        GenerateTileList();
    }

    private void GenerateTileList()
    {
        Transform[] allChildren = tilesHolder.GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChildren.Length; i++)
        {
            Transform child = allChildren[i];
            if (child.CompareTag("Game Tile"))
            {
                tileList.Add(child);
            }
        }
    }

    public void RollDice()
    {
        int totalRoll = 0;
        foreach (DiceImage dice in diceList)
        {
            totalRoll += dice.Roll();
        }

        curentTileIndex += totalRoll;
        // make sure the current index does not go out of bounds
        if(curentTileIndex>= tileList.Count)
        {
            curentTileIndex -= tileList.Count;
        }
        PlacePlayerOnTile(curentTileIndex);
    }

    private void PlacePlayerOnTile(int tileIndex = 0)
    {
        player.transform.position = tileList[tileIndex].transform.position;
        player.transform.rotation = tileList[tileIndex].transform.rotation;
        
        if (cameraTransition != null)
        {
            StopCoroutine(cameraTransition);
            //cameraTransition = StartCoroutine(cameraScroll.ScrollToPlayer(player.transform));
        }
        cameraTransition = cameraScroll.ScrollToPlayer(player.transform);
        StartCoroutine(cameraTransition);
    }
}
