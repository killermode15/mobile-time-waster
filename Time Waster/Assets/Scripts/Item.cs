using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeData
{
    public UpgradeData(float _initial, float _costBase, float _count = 0)
    {
        initialCost = _initial;
        costBase = _costBase;
        currentCount = _count;
    }

    [SerializeField] private float initialCost = 1;
    [SerializeField] private float costBase = 5;
    [SerializeField] private float currentCount = 0;

    public int GetCost()
    {
        return Mathf.RoundToInt(initialCost * Mathf.Pow(costBase, currentCount + 1));
    }

    public void Upgrade()
    {
        currentCount++;
    }
}

[CreateAssetMenu]
public class Item : ScriptableObject
{
    [SerializeField] private string itemName;
    [SerializeField] private UpgradeData itemUpgradeData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeItem()
    {

    }
}
