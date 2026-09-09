using UnityEngine;
using UnityEngine.InputSystem;

public class CameraDrag : MonoBehaviour
{
    [SerializeField] private float dragSpeed = 0.02f;
    [SerializeField] private bool invertDrag = false;

    [Header("X Constraint")]
    [SerializeField] private float minX = -10f;
    [SerializeField] private float maxX = 10f;

    private Vector2 lastPointerPosition;
    private bool isDragging;

    void Update()
    {
        if (Pointer.current == null) return;

        Vector2 currentPosition = Pointer.current.position.ReadValue();
        bool isPressed = Pointer.current.press.isPressed;

        if (isPressed && !isDragging)
        {
            isDragging = true;
            lastPointerPosition = currentPosition;
        }
        else if (isPressed && isDragging)
        {
            Vector2 delta = currentPosition - lastPointerPosition;
            MoveCamera(delta.x);
            lastPointerPosition = currentPosition;
        }
        else if (!isPressed && isDragging)
        {
            isDragging = false;
        }
    }

    void MoveCamera(float deltaX)
    {
        float direction = invertDrag ? 1f : -1f;
        float moveX = deltaX * dragSpeed * direction;

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x + moveX, minX, maxX);
        transform.position = pos;
    }
}