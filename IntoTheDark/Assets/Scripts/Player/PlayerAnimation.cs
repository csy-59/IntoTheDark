using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private PlayerMove move;
    [SerializeField] private PlayerGun gun;

    private readonly int horizontal = Animator.StringToHash("horizontal");
    private readonly int vertical = Animator.StringToHash("vertical");
    private readonly int fire = Animator.StringToHash("Fire");
    private readonly int Reload = Animator.StringToHash("Reload");

    private void Start()
    {
        move.OnInputDirectionChanged = SetLegAnimation;

        gun.OnGunFired = OnGunFire;
        gun.OnReloaded = OnGunReload;
    }

    private void OnGunFire()
    {
        animator.SetTrigger(fire);
        Logger.Instance.Log("Fire");
    }

    private void OnGunReload()
    {
        animator.SetTrigger(Reload);
    }
    private void SetLegAnimation(Vector2 inputDir)
    {
        animator.SetFloat(horizontal, inputDir.x);
        animator.SetFloat(vertical, inputDir.y);
    }
}
