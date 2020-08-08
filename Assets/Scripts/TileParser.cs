using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TileParser : MonoBehaviour
{
    public GameObject tilesHolder;

    void Start()
    {
        Transform[] allChildren =  tilesHolder.GetComponentsInChildren<Transform>();
        for (int i = 0; i < allChildren.Length; i++)
        {
            Transform child = allChildren[i];
            if (child.CompareTag("Game Tile"))
            {
                Debug.Log(child.transform.position.x + ", " + child.transform.position.y);
            }
        }
    }
}
