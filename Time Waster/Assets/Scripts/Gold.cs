using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : MonoBehaviour
{
    public int CurrentGold => currentGold;

    [SerializeField] private int currentGold;

    public void DeductGold(int gold)
    {
        if (gold > currentGold)
            gold = currentGold;
        currentGold -= gold;
    }

    public void AddGold(int gold) => currentGold += gold;

    public bool IsAffordable(int cost) => currentGold <= cost;
    
}
