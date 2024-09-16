using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float Heath => heath;
    [SerializeField] float heath;

    public float Speed => speed;
    [SerializeField] float speed;

    public float DashSpeed => dashSpeed;
    [SerializeField] float dashSpeed;

    public float JumpForce => jumpForce;
    [SerializeField] float jumpForce;

    public float FallingSpeed => fallingSpeed;
    [SerializeField] float fallingSpeed;

    public float RotateSpeed => rotateSpeed;
    [SerializeField] float rotateSpeed;
}
