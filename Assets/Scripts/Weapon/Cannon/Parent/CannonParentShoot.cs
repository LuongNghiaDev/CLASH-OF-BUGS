using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CannonParentShoot : BaseMonobehavior
{
    [SerializeField]
    protected GameObject bullet;
    [SerializeField]
    protected GameObject targetBullet;
    [SerializeField]
    protected List<Transform> firePos;
    [SerializeField]
    protected float shootDelay = 1f;
    [SerializeField]
    protected float shootTimer = 0f;
    [SerializeField]
    protected Transform targetEnemy;
    protected GameObject enemyPos;
    protected GameObject target;
    [SerializeField]
    protected float forceBullet;

    public GameObject Bullet { get => bullet; set => bullet = value; }

    private void Update()
    {
        this.Shoot();
    }

    protected abstract void Shoot();

}
