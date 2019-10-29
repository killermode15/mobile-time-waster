using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapManager : MonoBehaviour
{
    [SerializeField] private int tapCount;
    [SerializeField] private int tapValue;

    [SerializeField] private TextMeshPro onTapPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
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

                Destroy(text, 1);
            }

            tapCount += tapValue;
        }
    }
}
