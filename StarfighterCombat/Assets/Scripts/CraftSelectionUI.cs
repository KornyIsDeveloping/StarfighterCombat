using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSelectionUI : MonoBehaviour
{
    public CraftSelectionManager craftSelectionManager; //reference to your CraftSelectionManager

    public void OnCraftSelected(string craftName, int craftLevel)
    {
        craftSelectionManager.SelectCraft(craftName, craftLevel);
    }
}
