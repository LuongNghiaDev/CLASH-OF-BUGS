using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CannonRocket : CannonParentShoot
{
    [SerializeField]
    protected CircleCollider2D circleCollider2D;
    [SerializeField]
    protected float radiusCnRocket;
    private bool isCheckShoot = false;
    [SerializeField]
    protected GameObject effect;

    public float RadiusCnRocket { get => radiusCnRocket; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2D();
    }

    protected virtual void LoadCircleCollider2D()
    {
        if (this.circleCollider2D != null) return;
        this.circleCollider2D = GetComponent<CircleCollider2D>();
        this.circleCollider2D.isTrigger = true;
        this.circleCollider2D.radius = this.radiusCnRocket;
    }

    protected override void Shoot()
    {
        if (isCheckShoot == false) return;
        this.targetEnemy = this.GetTargetEnemy();

        for (int i = 0; i < this.firePos.Count; i++)
        {
            this.shootTimer -= Time.deltaTime;
            if (this.shootTimer > 0) return;
            this.shootTimer = this.shootDelay;
            if (this.effect != null)
            {
                Instantiate(this.effect, this.firePos[i].position, Quaternion.identity);
            }
            Instantiate(this.targetBullet, this.targetEnemy.position, Quaternion.identity);
            AudioController.Instance.playSound(AudioController.Instance.WeaponSound2);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.isCheckShoot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.isCheckShoot = false;
        }
    }

    protected virtual Transform GetTargetEnemy()
    {
        targetEnemy = GameObject.FindGameObjectWithTag("Enemy").transform;
        return targetEnemy;
    }
}
