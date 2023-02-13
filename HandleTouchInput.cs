using UnityEngine;
using UnityEngine.UI;

public class HandleTouchInput : MonoBehaviour
{
    private float touchStartTime;
    private Vector2 touchStartPosition;
    [SerializeField] private float deadZone = 30f;
    [SerializeField] private Text textComponent;
    [SerializeField] private float minimumSwipeDuration = 0.1f;
    [SerializeField] private float minimumSwipeSpeed = 3f;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.position.x > Screen.width / 2)
            {
                textComponent.text = "right touch";
            }
            else
            {
                textComponent.text = "left touch";
            }

            if (touch.phase == TouchPhase.Began)
            {
                touchStartTime = Time.time;
                touchStartPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                float touchDuration = Time.time - touchStartTime;
                float touchSpeed = touch.position.y - touchStartPosition.y / touchDuration;

                if (touchDuration > minimumSwipeDuration && Mathf.Abs(touchSpeed) > minimumSwipeSpeed /*&& Mathf.Abs(touch.deltaPosition.y) > deadZone*/)
                {
                    if (touch.deltaPosition.y > 0)
                    {
                        textComponent.text = "Up swipe";
                    }
                    if (touch.deltaPosition.y < 0)
                    {
                        textComponent.text = "Down swipe";
                    }
                }
            }
        }
    }
}
