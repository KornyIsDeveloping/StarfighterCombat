/*using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class CraftController : MonoBehaviour
{
    private bool isBeingTouched = false;
    private RectTransform rectTransform;
    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();

        // Add any additional initializations here.
    }

    private void Update()
    {
        //check if the current scene is the game scene
        if (SceneManager.GetActiveScene().name == "Game")
        {
            HandleDrag();
        }

        HandleDrag();

        // You can call other functionalities here, like:
        // HandleShooting();
        // HandleAbilities();
        // etc.
    }

    private void HandleDrag()
    {
        //handle touch controls
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, touch.position, null))
                    {
                        isBeingTouched = true;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isBeingTouched)
                    {
                        MoveCraftToPosition(touch.position);
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isBeingTouched = false;
                    break;
            }
        }

        //handle mouse controls
        else if (Input.GetMouseButton(0))
        {
            MoveCraftToPosition(Input.mousePosition);
        }
    }

    private void MoveCraftToPosition(Vector2 position)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), position, canvas.worldCamera, out localPoint))
        {
            rectTransform.anchoredPosition = localPoint;
        }
    }

    // Add other methods for different functionalities below.
}

*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(RectTransform))]
public class CraftController : MonoBehaviour
{
    private bool isBeingTouched = false;
    private RectTransform rectTransform;
    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = FindObjectOfType<Canvas>();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            HandleDrag();

            // If you have other functionalities, you can call them here:
            // HandleShooting();
            // HandleAbilities();
            // etc.
        }
    }

    private void HandleDrag()
    {
        //handle touch controls
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, touch.position, null))
                    {
                        isBeingTouched = true;
                    }
                    break;

                case TouchPhase.Moved:
                    if (isBeingTouched)
                    {
                        MoveCraftToPosition(touch.position);
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isBeingTouched = false;
                    break;
            }
        }

        //handle mouse controls
        else if (Input.GetMouseButton(0))
        {
            MoveCraftToPosition(Input.mousePosition);
        }
    }

    private void MoveCraftToPosition(Vector2 position)
    {
        Vector2 localPoint;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.GetComponent<RectTransform>(), position, canvas.worldCamera, out localPoint))
        {
            rectTransform.anchoredPosition = localPoint;
        }
    }

    // Add other methods for different functionalities below.
}
