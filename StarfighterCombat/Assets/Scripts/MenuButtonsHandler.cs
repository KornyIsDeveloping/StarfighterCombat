using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuButtonsHandler : MonoBehaviour
{
    //hiding the elements for Store
    public GameObject StartGameButton;
    public GameObject RightArrowButton;
    public GameObject LeftArrowButton;
    public GameObject CraftMenuSelector;

    //showing the elements for Store
    public GameObject NoAddsButton;
    public GameObject Option2;
    public GameObject Option3;
    public GameObject Option4;
    public GameObject Option5;
    public GameObject StoreButton;
    public GameObject HomeButton;
    public GameObject SettingsButton;

    //function for hiding the elements from Home
    public void HideHomeElements()
    {
        StartGameButton.SetActive(false);
        RightArrowButton.SetActive(false);
        LeftArrowButton.SetActive(false);
        CraftMenuSelector.SetActive(false);
    }
}
