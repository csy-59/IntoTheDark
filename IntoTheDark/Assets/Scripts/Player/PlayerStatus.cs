using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    public float Heath => heath;
    [SerializeField] float heath;

    public float Speed{ get => speed; set => speed = value; }
    [SerializeField] float speed;



    public float NormalSpeed => normalSpeed;
    [SerializeField] float normalSpeed;

    public bool IsDashing { get; set; }

    public float DashSpeed => dashSpeed;
    [SerializeField] float dashSpeed;

    public float DashTime => dashTime;
    [SerializeField] float dashTime;

    public float JumpForce => jumpForce;
    [SerializeField] float jumpForce;

    public float FallingSpeed => fallingSpeed;
    [SerializeField] float fallingSpeed;

    public float RotateSpeed => rotateSpeed;
    [SerializeField] float rotateSpeed;
}
