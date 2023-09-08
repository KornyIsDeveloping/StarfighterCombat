using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class CraftController : MonoBehaviour
{
    public Button leftMovementButton;
    public Button rightMovementButton;

    private bool moveLeft = false;
    private bool moveRight = false;
    private float movementSpeed = 650f;
    private float minX, maxX; //calculating the half-width of the craft 

    private void Awake()
    {
        //check if buttons are assigned and add listeners to them
        //if (leftMovementButton)
        //leftMovementButton.onClick.AddListener(StartMovingLeft);

        //if (rightMovementButton)
        //rightMovementButton.onClick.AddListener(StartMovingRight);

        //implementing the boundaries for the craft movement
        /* Vector3 corner1 = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
         Vector3 corner2 = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

         float craftHalfWidth = GetComponent<RectTransform>().rect.width / 2;
         minX = corner1.x + craftHalfWidth;
         maxX = corner2.x - craftHalfWidth;

         GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f); //set pivot to center

         float craftHalfWidth = GetComponent<RectTransform>().rect.width / 2;
         minX = corner1.x + craftHalfWidth;
         maxX = corner2.x - craftHalfWidth;*/


        if (leftMovementButton)
            leftMovementButton.onClick.AddListener(StartMovingLeft);

        if (rightMovementButton)
            rightMovementButton.onClick.AddListener(StartMovingRight);

        //implementing the boundaries for the craft movement
        Vector3 corner1 = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, Camera.main.nearClipPlane));
        Vector3 corner2 = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, Camera.main.nearClipPlane));

        GetComponent<RectTransform>().pivot = new Vector2(0.5f, 0.5f); //set pivot to center

        float craftHalfWidth = GetComponent<RectTransform>().rect.width / 2;
        minX = corner1.x + craftHalfWidth;
        maxX = corner2.x - craftHalfWidth;
    }

    private void Update()
    {
        Vector3 targetPos = transform.position;

        if (moveLeft)
        {
            //targetPos.x -= movementSpeed * Time.deltaTime;

            targetPos = transform.position + new Vector3(-movementSpeed * Time.deltaTime, 0, 0);

            //move craft to the left
            //transform.Translate(-movementSpeed * Time.deltaTime, 0, 0);
        }
        else if (moveRight)
        {
            //targetPos.x += movementSpeed * Time.deltaTime;

            targetPos = transform.position + new Vector3(movementSpeed * Time.deltaTime, 0, 0);

            //move craft to the right
            //transform.Translate(movementSpeed * Time.deltaTime, 0, 0);
        }

        //smoothly interpolate between the current position and the target position
        //transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);

        //clamp the craft's x position
        //Vector3 pos = transform.position;
        //pos.x = Mathf.Clamp(pos.x, minX, maxX);
        //transform.position = pos;

        transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }

    //setting up OnPointerDown and OnPointerUp events for the buttons.
    public void SetMovementButtons(Button left, Button right)
    {
        if (left)
        {
            leftMovementButton = left;
            EventTrigger leftTrigger = leftMovementButton.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry pointerDownEntryLeft = new EventTrigger.Entry();
            pointerDownEntryLeft.eventID = EventTriggerType.PointerDown;
            pointerDownEntryLeft.callback.AddListener((data) => { StartMovingLeft(); });
            leftTrigger.triggers.Add(pointerDownEntryLeft);

            EventTrigger.Entry pointerUpEntryLeft = new EventTrigger.Entry();
            pointerUpEntryLeft.eventID = EventTriggerType.PointerUp;
            pointerUpEntryLeft.callback.AddListener((data) => { StopMoving(); });
            leftTrigger.triggers.Add(pointerUpEntryLeft);
        }

        if (right)
        {
            rightMovementButton = right;
            EventTrigger rightTrigger = rightMovementButton.gameObject.AddComponent<EventTrigger>();

            EventTrigger.Entry pointerDownEntryRight = new EventTrigger.Entry();
            pointerDownEntryRight.eventID = EventTriggerType.PointerDown;
            pointerDownEntryRight.callback.AddListener((data) => { StartMovingRight(); });
            rightTrigger.triggers.Add(pointerDownEntryRight);

            EventTrigger.Entry pointerUpEntryRight = new EventTrigger.Entry();
            pointerUpEntryRight.eventID = EventTriggerType.PointerUp;
            pointerUpEntryRight.callback.AddListener((data) => { StopMoving(); });
            rightTrigger.triggers.Add(pointerUpEntryRight);
        }
    }

    //called when the left button is pressed
    public void StartMovingLeft()
    {
        moveLeft = true;
        moveRight = false; //ensure we're not moving right if the left button is pressed
    }

    //called when the right button is pressed
    public void StartMovingRight()
    {
        Debug.Log("Right Button Clicked");
        moveRight = true;
        moveLeft = false; //ensure we're not moving left if the right button is pressed
    }

    // Optional: If you want to stop moving when the button is released
    public void StopMoving()
    {
        Debug.Log("Left Button Clicked");  
        moveLeft = false;
        moveRight = false;
    }
}
