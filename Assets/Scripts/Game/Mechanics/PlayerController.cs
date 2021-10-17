using UnityEngine;

public class PlayerController : MonoBehaviour, IMovementInputController
{
    private Vector2 direction;

    private float speed;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        MovementInputUpdate();
    }

    public event IMovementInputController.ChangeDirectionHandle ChangeDirectionEvent;
    public event IMovementInputController.ChangeSpeedHandle ChangeSpeedEvent;

    private void MovementInputUpdate()
    {
        var newDir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (!direction.Equals(newDir))
        {
            direction = newDir;
            ChangeDirectionEvent?.Invoke(direction);

            var newSpeed = Mathf.Clamp(direction.magnitude, 0, 1);
            if (!speed.Equals(newSpeed))
            {
                speed = newSpeed;
                ChangeSpeedEvent?.Invoke(speed);
            }
        }
    }
}