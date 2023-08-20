using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSelectionManager : MonoBehaviour
{
    /*public string SelectedCraftName { get; private set; }
    public int SelectedCraftLevel { get; private set; }

    public void SelectCraft(string craftName, int craftLevel)
    {
        SelectedCraftName = craftName;
        SelectedCraftLevel = craftLevel;

        //store selected craft's information in PlayerPrefs
        PlayerPrefs.SetString("SelectedCraftName", craftName);
        PlayerPrefs.SetInt("SelectedCraftLevel", craftLevel);
    }*/

    public static CraftSelectionManager Instance;

    public string SelectedCraftName { get; private set; }
    public int SelectedCraftLevel { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SelectCraft(string craftName, int craftLevel)
    {
        SelectedCraftName = craftName;
        SelectedCraftLevel = craftLevel;
    }
}
