using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float maxSpeed = 8f;
    [SerializeField] private bool cameraRelativeMovement = true;
    [SerializeField] private Transform cameraTransform = null;

    private Vector2 moveInput = Vector2.zero;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        if (cameraTransform == null && Camera.main != null)
            cameraTransform = Camera.main.transform;

        rb.interpolation = RigidbodyInterpolation.Interpolate;
    }

    // Chamado automaticamente pelo Player Input (Behavior = Send Messages)
    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        if (rb == null) return;

        Vector3 direction = new Vector3(moveInput.x, 0f, moveInput.y);

        if (cameraRelativeMovement && cameraTransform != null)
        {
            Vector3 forward = cameraTransform.forward;
            forward.y = 0f;
            forward.Normalize();

            Vector3 right = cameraTransform.right;
            right.y = 0f;
            right.Normalize();

            direction = right * moveInput.x + forward * moveInput.y;
        }

        if (direction.sqrMagnitude > 1f)
            direction.Normalize();

        // Aplica aceleração na direção desejada
        rb.AddForce(direction * moveSpeed, ForceMode.Acceleration);

        // Limita a velocidade máxima
        if (maxSpeed > 0)
        {
            Vector3 horizontalVelocity = rb.linearVelocity;
            horizontalVelocity.y = 0f;

            if (horizontalVelocity.magnitude > maxSpeed)
            {
                horizontalVelocity = horizontalVelocity.normalized * maxSpeed;

                rb.linearVelocity = new Vector3(
                    horizontalVelocity.x,
                    rb.linearVelocity.y,
                    horizontalVelocity.z
                );
            }
        }
    }

    public void SetMoveSpeed(float speed) => moveSpeed = speed;
    public void SetMaxSpeed(float max) => maxSpeed = max;
    public void SetCameraRelative(bool enabled) => cameraRelativeMovement = enabled;
    public void SetCameraTransform(Transform t) => cameraTransform = t;
}