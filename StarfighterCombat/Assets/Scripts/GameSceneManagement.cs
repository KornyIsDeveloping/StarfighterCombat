/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManagement : MonoBehaviour
{
    //this is the point where you want your craft to spawn. Assign it in the inspector.
    public Transform spawnPoint;

    private void Start()
    {
        //check if DataManager exists and a craft was selected
        if (DataManager.Instance != null && DataManager.Instance.selectedCraftPrefab != null)
        {
            //instantiate the selected craft at the spawn point's position
            Instantiate(DataManager.Instance.selectedCraftPrefab, spawnPoint.position, Quaternion.identity);
            Debug.Log("Craft instantiated at: " + spawnPoint.position);
        }
        else
        {
            Debug.LogError("DataManager not found or no craft selected.");
        }
    }
}
*/

using UnityEngine;

public class GameSceneManagement : MonoBehaviour
{
    public Transform spawnPoint;
    public RectTransform background;  // Drag and drop your background UI element here in the Inspector.

    private void Start()
    {
        Canvas mainCanvas = FindObjectOfType<Canvas>();

        if (!mainCanvas)
        {
            Debug.LogError("No Canvas found in the scene!");
            return;
        }

        if (DataManager.Instance != null && DataManager.Instance.selectedCraftPrefab != null)
        {
            GameObject craft = Instantiate(DataManager.Instance.selectedCraftPrefab, spawnPoint.position, Quaternion.identity, mainCanvas.transform);

            // This ensures the craft is instantiated above the background
            if (background)
            {
                craft.transform.SetSiblingIndex(background.GetSiblingIndex() + 1);
            }
            else
            {
                Debug.LogWarning("Background not assigned, so craft might not be above it.");
            }

            Debug.Log("Craft instantiated at: " + spawnPoint.position);
        }
        else
        {
            Debug.LogError("DataManager not found or no craft selected.");
        }
    }
}
