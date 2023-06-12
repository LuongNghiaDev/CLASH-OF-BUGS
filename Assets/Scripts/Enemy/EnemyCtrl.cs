using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : BaseMonobehavior
{

    [SerializeField]
    protected FootprintSpawner footprintSpawner;

    public FootprintSpawner FootprintSpawner { get => footprintSpawner; set => footprintSpawner = value; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFootprintSpawner();
    }

    protected virtual void LoadFootprintSpawner()
    {
        if (this.footprintSpawner != null) return;
        this.footprintSpawner = GetComponentInChildren<FootprintSpawner>();
    }
}
