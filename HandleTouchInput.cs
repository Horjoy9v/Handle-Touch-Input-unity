using UnityEngine;
using UnityEngine.UI;

public class SwipeDetector : MonoBehaviour
{
    [SerializeField] private Text textComponent;
    private Vector2 startPos, endPos, direction;
    private float touchTimeStart, touchTimeFinish, timeInterval;

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
            endPos = Input.GetTouch(0).position;
            direction = endPos - startPos;

            if (timeInterval > 0.05f)
            {
                if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
                {
                    if (direction.x > 0)
                        textComponent.text = "Right swipe";
                    else
                        textComponent.text = "Left swipe";
                }
                else
                {
                    if (direction.y > 0)
                        textComponent.text = "Up swipe";
                    else
                        textComponent.text = "Down swipe";
                }
            }
        }
    }
}
