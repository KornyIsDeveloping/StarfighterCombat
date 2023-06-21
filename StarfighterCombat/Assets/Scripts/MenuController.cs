using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MenuController : MonoBehaviour
{
    public Image imageDisplay;
    public TMP_Text craftNameText;
    public TMP_Text craftLevelText;
    public Button rightArrowButton;
    public Button leftArrowButton;

    public string[] craftLevels;
    public Sprite[] images;
    public string[] names;
    public Button nextButton;
    public Button previousButton;

    private int currentIndex = 0;

    private void Start()
    {
        imageDisplay.sprite = images[currentIndex];
        craftNameText.text = names[currentIndex];
        craftLevelText.text = craftLevels[currentIndex];

        nextButton.onClick.AddListener(NextImage);
        previousButton.onClick.AddListener(PreviousImage);

        //check if the initial index is 0
        if (currentIndex == 0)
        {
            leftArrowButton.interactable = false; //disable the left arrow button
        }

        //check if the last index is 9
        if (currentIndex == images.Length - 1)
        {
            rightArrowButton.interactable = false; //disable the right arrow button
        }
    }

    public void NextImage()
    {
        currentIndex = (currentIndex + 1) % images.Length;
        UpdateMenu();

        leftArrowButton.interactable = true; //enable the left arrow button

        // update the button state
        leftArrowButton.gameObject.SetActive(true); // show the left arrow button

        // check if the current index is the last index
        if (currentIndex == images.Length - 1)
        {
            rightArrowButton.gameObject.SetActive(false); // hide the right arrow button
        }
    }

    public void PreviousImage()
    {
        currentIndex = (currentIndex - 1 + images.Length) % images.Length;
        UpdateMenu();

        // update the button state
        rightArrowButton.gameObject.SetActive(true); // show the right arrow button

        // check if the current index is 0
        if (currentIndex == 0)
        {
            leftArrowButton.gameObject.SetActive(false); // hide the left arrow button
        }
    }
        
    private void UpdateMenu()
    {
        //Debug.Log("Current Index: " + currentIndex);

        if (currentIndex >= 0 && currentIndex < images.Length && currentIndex < names.Length && currentIndex < craftLevels.Length)
        {
            imageDisplay.sprite = images[currentIndex];
            craftNameText.text = names[currentIndex];
            craftLevelText.text = craftLevels[currentIndex];
        }
    }
    
}