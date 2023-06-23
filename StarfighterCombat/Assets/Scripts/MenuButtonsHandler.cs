using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonsHandler : MonoBehaviour
{
    //show elements for StoreButton

    //hide elements from Menu and Settings
    //public GameObject[] elementsToHide;
    public GameObject[] StartGameButton;
    public GameObject[] RightArrowButton;
    public GameObject[] LeftArrowButton;
    public GameObject[] CraftMenuSelector;
    //--------------------------------------------------------------------
    //show elements for Home

    //hide elements from Store and Settigns
    //--------------------------------------------------------------------
    //show elements from Settings

    //hide elements from Menu and Store
    //--------------------------------------------------------------------
    public void OnButtonClick()
    {
/*        foreach (var elementToShow in elementsToShow)
        {
            elementToShow.SetActive(true);
        }*/
         
        foreach (var StartGameButton in StartGameButton) //menu
        {
            StartGameButton.SetActive(false);
        }

        foreach (var RightArrowButton in RightArrowButton) //menu
        {
            RightArrowButton.SetActive(false);
        }
        foreach (var LeftArrowButton in LeftArrowButton) //menu
        {
            LeftArrowButton.SetActive(false);
        }
        foreach (var CraftMenuSelector in CraftMenuSelector) //menu
        {
            CraftMenuSelector.SetActive(false);
        }
    }

}
