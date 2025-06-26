using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class GameData 
{
    public int deathCount;
    public Vector3 playerPosition;
    public List<string> coinsCollected;
    public int coinCount;

    public GameData()
    {
        this.deathCount = 0;
        playerPosition = Vector3.zero;
        coinsCollected = new List<string>();
        coinCount = 0;
    }
}
