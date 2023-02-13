using UnityEngine;
using UnityEngine.UI;

public class HandleTouchInput : MonoBehaviour
{
    private float touchStartTime;
    private Vector2 touchStartPosition;
    [SerializeField] private float deadZone = 3f;
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
            if (touch.phase == TouchPhase.Began)
            {
                touchStartTime = Time.time;
                touchStartPosition = touch.position;
            }

            if (touch.phase == TouchPhase.Ended)
            {
                float touchDuration = Time.time - touchStartTime;
                float touchSpeed = touch.position.y - touchStartPosition.y / touchDuration;

                if (touchDuration > minimumSwipeDuration && Mathf.Abs(touchSpeed) > minimumSwipeSpeed)
                {
                    if (touch.deltaPosition.y > 0)
                    {
                        textComponent.text = "Up swipe";
                    }
                    if (touch.deltaPosition.y < 0)
                    {
                        textComponent.text = "Down swipe";
                    }
                    if (touch.deltaPosition.x > deadZone)
                    {
                        textComponent.text = "right swipe";
                    }
                    if (touch.deltaPosition.x < -deadZone)
                    {
                        textComponent.text = "left swipe";
                    }
                }
            }
        }
    }
}
