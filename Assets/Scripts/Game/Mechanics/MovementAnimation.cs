using UnityEngine;

[RequireComponent(typeof(IMovementInputController))]
public class MovementAnimation : MonoBehaviour
{
    [SerializeField] private Vector2 direction = Vector2.zero;
    [Range(0f, 1f)] [SerializeField] private float currentSpeed;

    private Animator anim;
    private IMovementInputController imi;

    // Start is called before the first frame update
    private void OnEnable()
    {
        anim = GetComponent<Animator>();
        imi ??= GetComponent<IMovementInputController>();
        imi.ChangeDirectionEvent += ChangeDirectionHandle;
        imi.ChangeSpeedEvent += ChangeSpeedHandle;
    }

    private void OnDisable()
    {
        imi.ChangeDirectionEvent -= ChangeDirectionHandle;
        imi.ChangeSpeedEvent -= ChangeSpeedHandle;
    }

    private void ChangeDirectionHandle(Vector2 dir)
    {
        direction = dir.normalized;
        if (direction.sqrMagnitude > 0.1f)
        {
            var angle = -Vector2.SignedAngle(Vector2.up, direction);
            anim.SetFloat("Angle", angle);
        }
    }

    private void ChangeSpeedHandle(float speed)
    {
        currentSpeed = speed >= 0.1 ? 1 : 0;
        anim.SetFloat("Velocity", currentSpeed);
    }
}