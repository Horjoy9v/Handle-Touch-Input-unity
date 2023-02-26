using UnityEngine.EventSystems;
using UnityEngine;

public enum SwipeDirection
{
    Up,
    Down,
    Left,
    Right,
    none
}
public class SwipeDetector : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Vector2 startPosition, endPosition;
    public static Vector2 direction;
    private const float MIN_SWIPE_DISTANCE = 100f;
    public static SwipeDirection lastSwipeDirection = SwipeDirection.none;
    public void Reset()
    {
        startPosition = Vector2.zero;
        endPosition = Vector2.zero;
    }
    public virtual void OnPointerDown(PointerEventData eventData)
    {
        startPosition = eventData.position;
    }

    public virtual void OnPointerUp(PointerEventData eventData)
    {
        endPosition = eventData.position;
        direction = (endPosition - startPosition);
        GetSwipeDirection();
    }

    public SwipeDirection GetSwipeDirection()
    {
        if (direction.magnitude > MIN_SWIPE_DISTANCE)
            direction.x.ToString();

        if (direction.magnitude > MIN_SWIPE_DISTANCE)
        {
            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                    lastSwipeDirection = SwipeDirection.Right;

                else
                    lastSwipeDirection = SwipeDirection.Left;
            }
            else if (Mathf.Abs(direction.x) < Mathf.Abs(direction.y))
            {
                if (direction.y > 0)
                    lastSwipeDirection = SwipeDirection.Up;

                else
                    lastSwipeDirection = SwipeDirection.Down;
            }
        }
        return lastSwipeDirection;
    }
}
