using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase : MonoBehaviour
{
    public virtual void Start() { }
    public virtual void OnEnable() { }

    public abstract void OnStateEnter();

    public virtual void FixedUpdate(float deltaTime) { }
    public virtual void Update(float deltaTime) { }
    public virtual void LateUpdate(float deltaTime) { }

    public abstract void OnStateExit();

    public virtual void OnDisable() { }
}
