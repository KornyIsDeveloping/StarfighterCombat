/*using System.Collections;
using System.Collections.Generic;
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
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManagement : MonoBehaviour
{
    public Transform spawnPoint;
    public RectTransform background;  

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
            //instantiate the craft as a child of the canvas.
            GameObject craft = Instantiate(DataManager.Instance.selectedCraftPrefab, spawnPoint.position, Quaternion.identity, mainCanvas.transform);

            //get the RectTransform of the instantiated craft.
            RectTransform craftRectTransform = craft.GetComponent<RectTransform>();

            //set the anchor and pivot for the craft to be bottom-center.
            craftRectTransform.anchorMin = new Vector2(0.5f, 0);
            craftRectTransform.anchorMax = new Vector2(0.5f, 0);
            craftRectTransform.pivot = new Vector2(0.5f, 0);

            craftRectTransform.anchoredPosition = new Vector2(0, 350); //vertical position of the spawned craft

            //ensure the craft is instantiated above the background.
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
