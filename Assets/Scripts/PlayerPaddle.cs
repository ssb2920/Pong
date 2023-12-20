using UnityEngine;

public class PlayerPaddle : Paddle
{
    public Vector2 direction { get; private set; }

    public float swipeSensitivity = 5.0f;
    public float paddleSpeed = 10.0f;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Moved:
                    float swipeValue = touch.deltaPosition.y / Screen.height;
                    direction = swipeValue * Vector2.up * swipeSensitivity;
                    break;

                case TouchPhase.Ended:
                    direction = Vector2.zero;
                    break;
            }
        }
    }

    private void FixedUpdate()
    {
        if (direction.sqrMagnitude != 0)
        {
            rigidbody.AddForce(direction * paddleSpeed);
        }
    }
}
