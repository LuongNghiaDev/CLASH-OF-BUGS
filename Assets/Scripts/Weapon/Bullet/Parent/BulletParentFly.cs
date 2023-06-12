using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParentFly : BaseMonobehavior
{
    [SerializeField]
    protected float force;
    protected Vector3 direction;
    [SerializeField]
    protected TypeNameBullet nameBulletEnum;
    protected GameObject pos;
    [SerializeField]
    protected GameCtrl gameCtrl;
    public Rigidbody2D rg;

    private void Update()
    {
        this.RemoveBulletNoFly();
    }


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
    protected virtual void RemoveBulletNoFly()
    {

    }
}
