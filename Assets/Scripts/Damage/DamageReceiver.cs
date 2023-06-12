using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public abstract class DamageReceiver : BaseMonobehavior
{

    [SerializeField]
    protected CircleCollider2D circleCollider2D;
    [SerializeField]
    protected bool isDead = false;
    [SerializeField]
    protected float hp = 1;
    [SerializeField]
    protected float maxHp = 1;

    public float MaxHp { get => maxHp; set => maxHp = value; }

    protected override void OnEnable()
    {
        this.Rebord();
    }

    protected override void ResetValue()
    {
        base.ResetValue();
        this.Rebord();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
    }

    protected virtual void Rebord()
    {
        this.hp = this.maxHp;
        this.isDead = false;
    }

    public virtual void Add(float add)
    {
        if (this.isDead) return;
        this.hp += add;
        if (this.hp > this.maxHp) this.hp = this.maxHp;
    }

    public virtual void Deduct(float deduct)
    {
        if (this.isDead) return;

        this.hp -= deduct;
        if (this.hp < 0) this.hp = 0;
        this.CheckIsDead();
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void CheckIsDead()
    {
        if (!this.IsDead()) return;
        this.isDead = true;
        this.OnDead();
    }

    protected virtual void LoadCollider()
    {
        if (circleCollider2D != null) return;
        this.circleCollider2D = GetComponent<CircleCollider2D>();
        this.circleCollider2D.isTrigger = true;
        this.circleCollider2D.radius = 0.3f;
    }

    protected abstract void OnDead();
}
