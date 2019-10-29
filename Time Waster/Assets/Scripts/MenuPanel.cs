using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPanel : MonoBehaviour
{
    [SerializeField] private List<Button> menuButtons;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectButton(Button selectedButton)
    {
        foreach (Button button in menuButtons)
        {
            button.interactable = true;
        }

        selectedButton.interactable = false;
    }
}
