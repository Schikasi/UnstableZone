using UnityEngine;

public interface IMovementInputController
{
    public delegate void ChangeDirectionHandle(Vector2 value);

    public delegate void ChangeSpeedHandle(float value);

    public event ChangeDirectionHandle ChangeDirectionEvent;
    public event ChangeSpeedHandle ChangeSpeedEvent;
}