using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseParent : BaseMonobehavior
{
    [SerializeField]
    protected float timeSpawn;
    protected float timer;
    [SerializeField]
    protected GameCtrl gameCtrl;
    [SerializeField]
    protected float timeBack;
    protected bool isBack = false;

    public bool IsBack { get => isBack; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameCtrl();
    }

    protected virtual void LoadGameCtrl()
    {
        if (this.gameCtrl != null) return;
        this.gameCtrl = FindObjectOfType<GameCtrl>();
    }

    private void Update()
    {
        this.SpawnAnt();
    }

    protected virtual void SpawnAnt()
    {

    }

}
