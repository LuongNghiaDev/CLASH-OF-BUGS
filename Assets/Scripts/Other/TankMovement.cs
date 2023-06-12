using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : BaseMonobehavior
{

    [SerializeField]
    protected float speed;
    [SerializeField]
    protected GameCtrl gameCtrl;

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
        this.Move();
    }

    protected virtual void Move()
    {
        transform.parent.position = Vector2.MoveTowards(transform.parent.position, this.gameCtrl.PosLimit.position,
this.speed * Time.deltaTime);
    }
}
