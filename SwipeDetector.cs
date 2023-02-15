using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwipeDetector : MonoBehaviour
{
    [SerializeField] private Text textVector;
    [SerializeField] private Text textRange;
    private Vector2 startPos, endPos, direction;
    private float touchTimeStart, touchTimeFinish, timeInterval;

    private bool IsPointerOverUIObject()
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            textVector.text = "UI Object";
            textRange.text = IsPointerOverUIObject().ToString();
            if (!IsPointerOverUIObject())
            {
                touchTimeFinish = Time.time;
                timeInterval = touchTimeFinish - touchTimeStart;
                endPos = Input.GetTouch(0).position;
                direction = endPos - startPos;
            
                if (timeInterval > 0.05f && direction.magnitude > 100)
                {
                    if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                    {
                        if (direction.x > 0)
                        {
                            textVector.text = "Right swipe";
                            textRange.text = "delta x = " + direction.x.ToString();
                        }
                        else
                        {
                            textVector.text = "Left swipe";
                            textRange.text = "delta x = " + direction.x.ToString();
                        }
                    }
                    else
                    {
                        if (direction.y > 0)
                        {
                            textVector.text = "Up swipe";
                            textRange.text = "delta y = " + direction.y.ToString();
                        }
                        if (direction.y < 0)
                        {
                            textVector.text = "Down swipe";
                            textRange.text = "delta y = " + direction.y.ToString();
                        }
                    }
                }
                else
                {
                    textVector.text = "touch";
                    textRange.text = "null";
                }
            }
        }
    }
}