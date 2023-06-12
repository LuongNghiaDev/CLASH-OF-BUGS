using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CannonRotate : BaseMonobehavior
{
    [SerializeField]
    protected CircleCollider2D circleCollider2D;
    [SerializeField]
    protected float radiusCollider;
    private Vector3 direction;
    private GameObject enemyPos;
    private bool isCheckRotate = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCircleCollider2DRotate();
    }

    private void Update()
    {
        this.RotateGun();
    }

    protected virtual void LoadCircleCollider2DRotate()
    {
        if (this.circleCollider2D != null) return;
        this.circleCollider2D = GetComponent<CircleCollider2D>();
        this.circleCollider2D.isTrigger = true;
        this.circleCollider2D.radius = radiusCollider;
    }

    protected virtual void RotateGun()
    {
        if (this.isCheckRotate == false) return;
        //this.enemy = GameObject.FindGameObjectWithTag("Enemy");
        if(this.enemyPos != null)
        {
            this.direction = this.enemyPos.transform.position - transform.parent.position;

            float rotz = Mathf.Atan2(-this.direction.y, -this.direction.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rotz + 90);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            this.enemyPos = collision.gameObject;
            this.isCheckRotate = true;
        } 
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.enemyPos = null;
            this.isCheckRotate = false;
        }
    }
}
