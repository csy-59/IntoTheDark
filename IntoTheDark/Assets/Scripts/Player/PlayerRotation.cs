
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerRotation : MonoBehaviour
{
    [SerializeField] private PlayerStatus status;
    [SerializeField] private Rigidbody rigid;

    private float eulerAngleX, eulerAngleY;
    [SerializeField] private float limitMinX = 0;
    [SerializeField] private float limitMaxX = 180;

    public void Awake()
    {
        // 마우스 커서 안보이게, 위치 고정
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void FixedUpdate()
    {
        if ((status.IsDashing) == false)
        {
            UpdateRotate(UnityEngine.Input.GetAxis("Mouse X"), UnityEngine.Input.GetAxis("Mouse Y"));
        }
    }

    private void UpdateRotate(float mouseX, float mouseY)
    {
        eulerAngleY += mouseX * status.RotateSpeed;
        eulerAngleX -= mouseY * status.RotateSpeed;

        eulerAngleX = ClampAngle(eulerAngleX, limitMinX, limitMaxX);

        rigid.MoveRotation(Quaternion.Euler(eulerAngleX, eulerAngleY, 0f));
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }
}
