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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManagement : MonoBehaviour
{
    public Transform spawnPoint;  // This is where the craft will actually spawn in world space.
    public Canvas uiCanvas;  // Assign your canvas here.

    private void Start()
    {
        if (DataManager.Instance != null && DataManager.Instance.selectedCraftPrefab != null)
        {
            // Instantiate the craft at the spawn point's position
            GameObject craft = Instantiate(DataManager.Instance.selectedCraftPrefab, spawnPoint.position, Quaternion.identity);

            // If you want to make it a child of the Canvas for hierarchy organization:
            if (uiCanvas)
            {
                craft.transform.SetParent(uiCanvas.transform, true);  // Set worldPositionStays to true to keep its world position.
            }

            Debug.Log("Craft instantiated at: " + spawnPoint.position);
        }
        else
        {
            Debug.LogError("DataManager not found or no craft selected.");
        }
    }
}
