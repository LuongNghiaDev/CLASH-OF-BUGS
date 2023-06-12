using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : BaseMonobehavior
{
    [SerializeField]
    protected Vector3 targetHouse;
    [SerializeField]
    protected Vector3 targetHouseEnemy;
    [SerializeField]
    protected float moveSpeed;
    [SerializeField]
    protected float force;

    protected virtual void Update()
    {
        this.Move();
    }

    protected virtual void Move()
    {

    }

    protected virtual void AddForceBug()
    {

    }

}
