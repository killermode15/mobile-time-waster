using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

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

public class TapManager : MonoBehaviour
{
    [SerializeField] private int tapCount;
    [SerializeField] private int tapValue;

    [SerializeField] private UpgradeData tapUpgrade;

    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshPro onTapPrefab;



    // Start is called before the first frame update
    void Start()
    {
        tapUpgrade = new UpgradeData(1, 1.07f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        timeText.text = "Time: " +
                        tapCount.ToDays() + " D : " + 
                        tapCount.ToHours() + " H : " + 
                        tapCount.ToMinutes() + " M : " + 
                        tapCount.ToSeconds() + " S";

        int touchCount = Input.touchCount;

        if (touchCount <= 0)
            return;

        for (int i = 0; i < touchCount; i++)
        {

            if (EventSystem.current.IsPointerOverGameObject(i))
                continue;

            TouchPhase phase = Input.GetTouch(i).phase;

            if (!phase.Is(TouchPhase.Began)) continue;

            if (onTapPrefab)
            {
                Vector3 position = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                position.z += 10;
                GameObject text = Instantiate(onTapPrefab, position, Quaternion.identity).gameObject;
                text.GetComponent<TextMeshPro>().text = "+" + tapValue + "s"; 
                Destroy(text, 1);
            }

            tapCount += tapValue;
        }
    }

    public void UpgradeTap()
    {
        tapUpgrade.Upgrade();
        tapValue = tapUpgrade.GetCost();

        Debug.Log(tapUpgrade.GetCost().ToString());
    }
}
