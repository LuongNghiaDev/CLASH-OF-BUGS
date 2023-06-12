using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainHouse : HouseParent
{
    [SerializeField]
    private HouseDamReceiver houseDamReceiver;
    public HouseDamReceiver HouseDamReceiver { get => houseDamReceiver; set => houseDamReceiver = value; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadHouseDamReceiver();
    }

    protected virtual void LoadHouseDamReceiver()
    {
        if (this.houseDamReceiver != null) return;
        this.houseDamReceiver = GetComponentInChildren<HouseDamReceiver>();
    }

    protected override void SpawnAnt()
    {
        base.SpawnAnt();

    }

}
