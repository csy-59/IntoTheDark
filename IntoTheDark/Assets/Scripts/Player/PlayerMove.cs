using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.HID;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerStatus status;
    [SerializeField] private Rigidbody rigid;

    [Header("Ray")]
    [SerializeField] private float rayLength;
    [SerializeField] private float floatingHeight;
    [SerializeField] private LayerMask groundLayer;

    public Vector3 MoveDirection { get; private set; }
    public bool IsGround { get; private set; }

    private void OnEnable()
    {
        InputManager.Instance.AddActionListenner(
            new Defines.InputDefines.InputActionName(Defines.InputDefines.ActionMapType.Player, "Move"),
            Defines.InputDefines.ActionPoint.All,
            OnMove);
    }

    private void FixedUpdate()
    {
        Move();

        RaycastHit hit;
        IsGround = ShotRay(out hit);
        if(IsGround)
        {
            Rebound(in hit);
        }

    }

    private void Move()
    {
        // 대시 중이면 이동 연산 안함
        if (status.IsDashing == true)
        {
            return;
        }

        if (MoveDirection != Vector3.zero)
        {
            Vector3 locVel = transform.InverseTransformDirection(rigid.velocity);
            Vector3 newVel = MoveDirection.normalized * status.Speed;
            locVel.x = newVel.x;
            locVel.z = newVel.z;
            rigid.velocity = transform.TransformDirection(locVel);
        }
        rigid.velocity *= 0.9f;
    }

    private bool ShotRay(out RaycastHit _hit)
    {
        Debug.DrawRay(transform.position, Vector3.down, Color.green);
        return Physics.Raycast(transform.position, Vector3.down, out _hit, rayLength, groundLayer);
    }

    private void Rebound(in RaycastHit _hit)
    {
        float deep = _hit.distance - floatingHeight;
        rigid.MovePosition(rigid.transform.position - new Vector3(0f, deep, 0f));
    }

    private void OnDisable()
    {
        InputManager.Instance?.RemoveInputEventFunction(
            new Defines.InputDefines.InputActionName(Defines.InputDefines.ActionMapType.Player, "Move"),
            Defines.InputDefines.ActionPoint.All,
            OnMove);
    }

    private void OnMove(InputAction.CallbackContext _context)
    {
        MoveDirection = new Vector3(_context.ReadValue<Vector2>().x, 0f, _context.ReadValue<Vector2>().y);
    }
}
