using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public Canvas MainMenuCanvas;
    public Canvas StoreMenuCanvas;
    public Canvas SettingsMenuCanvas;

    public void ShowMainMenu()
    {
        MainMenuCanvas.gameObject.SetActive(true);
        StoreMenuCanvas.gameObject.SetActive(false);
        SettingsMenuCanvas.gameObject.SetActive(false);
    }

    public void ShowStoreMenu()
    {
        MainMenuCanvas.gameObject.SetActive(false);
        StoreMenuCanvas.gameObject.SetActive(true);
        SettingsMenuCanvas.gameObject.SetActive(false);
    }

    public void ShowSettingsMenu()
    {
        MainMenuCanvas.gameObject.SetActive(false);
        StoreMenuCanvas.gameObject.SetActive(false);
        SettingsMenuCanvas.gameObject.SetActive(true);
    }
}
