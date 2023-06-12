using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CuttingParent : BaseMonobehavior
{

    [SerializeField]
    protected float speed;

    private void Update()
    {
        this.Rotate();
    }

    protected abstract void Rotate();
}
