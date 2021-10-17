using UnityEngine;

[RequireComponent(typeof(IMovementInputController))]
public class Movement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f;

    [SerializeField] private Vector2 direction = Vector2.zero;

    [Range(0f, 1f)] [SerializeField] private float currentSpeed;
    private IMovementInputController imi;

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovementLogic();
    }

    private void OnEnable()
    {
        imi ??= GetComponent<IMovementInputController>();
        imi.ChangeDirectionEvent += ChangeDirectionHandle;
        imi.ChangeSpeedEvent += ChangeSpeedHandle;
    }

    private void OnDisable()
    {
        imi.ChangeDirectionEvent -= ChangeDirectionHandle;
        imi.ChangeSpeedEvent -= ChangeSpeedHandle;
    }

    private void MovementLogic()
    {
        if (currentSpeed < 0.1f) return;
        var movement = direction.normalized * currentSpeed * maxSpeed * Time.fixedDeltaTime;
        Debug.Log(movement);
        transform.Translate(movement);
    }

    private void ChangeDirectionHandle(Vector2 dir)
    {
        // currentSpeed = dir.sqrMagnitude >= 0.0001 ? 1 : 0;
        direction = dir;
    }

    private void ChangeSpeedHandle(float speed)
    {
        currentSpeed = speed;
    }
}