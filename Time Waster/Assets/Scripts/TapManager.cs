using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapManager : MonoBehaviour
{
    [SerializeField] private int tapCount;
    [SerializeField] private int tapValue;

    [SerializeField] private UpgradeData tapUpgrade;
    [SerializeField] private Gold gold;

    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private TextMeshPro onTapPrefab;

    [SerializeField] private TextMeshProUGUI goldText;



    // Start is called before the first frame update
    void Start()
    {
        tapUpgrade = new UpgradeData(1, 1.07f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (tapCount > 31535999)
        {
            timeText.text = "Time: " +
                            tapCount.ToYears() + " Y : " +
                            tapCount.ToDays() + " D : " +
                            tapCount.ToHours() + " H : " +
                            tapCount.ToMinutes() + " M";
        }
        else
        {
            timeText.text = "Time: " +
                            tapCount.ToDays() + " D : " +
                            tapCount.ToHours() + " H : " +
                            tapCount.ToMinutes() + " M : " +
                            tapCount.ToSeconds() + " S";
        }

        goldText.text = "Gold: " + gold.CurrentGold;


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
            gold.AddGold(tapValue);
        }
    }

    public void UpgradeTap()
    {
        tapUpgrade.Upgrade();
        tapValue = tapUpgrade.GetCost();

        Debug.Log(tapUpgrade.GetCost().ToString());
    }
}
