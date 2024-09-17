using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerGun : MonoBehaviour
{
    [SerializeField] PlayerStatus status;

    public Action OnGunFired { get; set; }
    public Action OnReloaded { get; set; }

    [SerializeField] private int ammor;
    [SerializeField] private int maxAmmor;
    private bool isAmmorEmpty = false;

    [SerializeField] private float reloadingTime;
    private WaitForSeconds wFReloading;
    private bool isReloading = false;

    [SerializeField] private float shotCoolTime;
    private WaitForSeconds wFCoolTime;
    private bool isCoolTime = false;

    private void Start()
    {
        wFReloading = new WaitForSeconds(reloadingTime);
        wFCoolTime = new WaitForSeconds(shotCoolTime);

        ammor = maxAmmor;
    }

    private void OnEnable()
    {
        InputManager.Instance.AddActionListenner(
            new Defines.InputDefines.InputActionName(Defines.InputDefines.ActionMapType.Player, "Fire"),
            Defines.InputDefines.ActionPoint.IsStarted,
            OnFire);

        InputManager.Instance.AddActionListenner(
            new Defines.InputDefines.InputActionName(Defines.InputDefines.ActionMapType.Player, "Reload"),
            Defines.InputDefines.ActionPoint.IsStarted,
            OnReload);
    }

    private void OnDisable()
    {
        InputManager.Instance.RemoveInputEventFunction(
            new Defines.InputDefines.InputActionName(Defines.InputDefines.ActionMapType.Player, "Fire"),
            Defines.InputDefines.ActionPoint.IsStarted,
            OnFire);

        InputManager.Instance.RemoveInputEventFunction(
            new Defines.InputDefines.InputActionName(Defines.InputDefines.ActionMapType.Player, "Reload"),
            Defines.InputDefines.ActionPoint.IsStarted,
            OnReload);
    }

    private void OnFire(InputAction.CallbackContext _context)
    {
        if (isReloading == true || isCoolTime == true || isAmmorEmpty == true)
            return;

        OnGunFired?.Invoke();
        isCoolTime = true;
        --ammor;
        isAmmorEmpty = ammor <= 0;
        StartCoroutine(CoolingGun());
    }

    private IEnumerator CoolingGun()
    {
        yield return wFCoolTime;
        isCoolTime = false;
    }

    private void OnReload(InputAction.CallbackContext _context)
    {
        OnReloaded?.Invoke();
        isReloading = true;
        StartCoroutine(Reloading());
    }

    private IEnumerator Reloading()
    {
        yield return wFReloading;
        isReloading = false;
        isAmmorEmpty = false;
        ammor = maxAmmor;
    }
}
