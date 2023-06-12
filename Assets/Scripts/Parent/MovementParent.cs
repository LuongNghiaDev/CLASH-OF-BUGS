using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MovementParent : BaseMonobehavior
{

    [SerializeField]
    protected float moveSpeed = 1;
    [SerializeField]
    protected GameCtrl gameCtrl;
    [SerializeField]
    protected HouseParent houseParent;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadGameCtrl();
        this.LoadHouseParent();
    }

    protected virtual void LoadGameCtrl()
    {
        if (this.gameCtrl != null) return;
        this.gameCtrl = FindObjectOfType<GameCtrl>();
    }

    protected virtual void LoadHouseParent()
    {
        if (this.houseParent != null) return;
        this.houseParent = FindObjectOfType<HouseParent>();
    }

    private void Update()
    {
        this.Move();   
    }

    protected abstract void Move();

}
