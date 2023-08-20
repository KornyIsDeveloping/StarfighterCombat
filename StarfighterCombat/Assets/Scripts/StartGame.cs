using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public CraftSelectionManager craftSelectionManager;

    public void PlayGame()
    {
       /* //get the selected craft's information from PlayerPrefs
        string selectedCraftName = PlayerPrefs.GetString("SelectedCraftName");
        int selectedCraftLevel = PlayerPrefs.GetInt("SelectedCraftLevel");

        //pass the selected craft's information to the game scene
        PlayerPrefs.SetString("SelectedCraftNameForGame", selectedCraftName);
        PlayerPrefs.SetInt("SelectedCraftLevelForGame", selectedCraftLevel);*/

        //load the next scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
