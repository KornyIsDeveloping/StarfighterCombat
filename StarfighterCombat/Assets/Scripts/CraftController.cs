/*using System.Collections;
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
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(RectTransform))]
public class CraftController : MonoBehaviour
{
    private bool isBeingTouched = false;
    private bool hasValidDragStart = false;
    private RectTransform rectTransform;
    private Canvas canvas;
    private Vector2 touchStartOffset; // To store the difference between the touch start point and the object's position

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
        // Handle touch controls
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, touch.position, null))
                    {
                        isBeingTouched = true;

                        if (!hasValidDragStart)
                        {
                            Vector2 localTouchStartPoint;
                            RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, touch.position, canvas.worldCamera, out localTouchStartPoint);
                            touchStartOffset = rectTransform.anchoredPosition - localTouchStartPoint;
                            hasValidDragStart = true;
                        }
                    }
                    break;

                case TouchPhase.Moved:
                    if (isBeingTouched)
                    {
                        MoveCraftToPosition(touch.position + touchStartOffset);  // Apply the offset here
                    }
                    break;

                case TouchPhase.Ended:
                case TouchPhase.Canceled:
                    isBeingTouched = false;
                    hasValidDragStart = false;
                    break;
            }
        }

        // Handle mouse controls
        else if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Input.mousePosition;
            if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePosition, null) && !isBeingTouched)
            {
                isBeingTouched = true;

                if (!hasValidDragStart)
                {
                    Vector2 localMouseStartPoint;
                    RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, mousePosition, canvas.worldCamera, out localMouseStartPoint);
                    touchStartOffset = rectTransform.anchoredPosition - localMouseStartPoint;
                    hasValidDragStart = true;
                }
            }

            if (isBeingTouched)
                MoveCraftToPosition(mousePosition + touchStartOffset); // Apply the offset here
        }
        else
        {
            isBeingTouched = false;
            hasValidDragStart = false;
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
