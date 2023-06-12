using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CannonOther : CannonParentShoot
{
    [SerializeField]
    protected CircleCollider2D circleCollider2D;
    [SerializeField]
    protected float radiusCnOther;
    private bool isCheckShoot = false;
    [SerializeField]
    protected GameObject effect;

    public float RadiusCnOther { get => radiusCnOther; }

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
        this.circleCollider2D.radius = this.radiusCnOther;
    }

    protected override void Shoot()
    {
        if (target.gameObject.activeInHierarchy == false)
        {
            this.isCheckShoot = false;
        }
        if (isCheckShoot == false) return;
        this.shootTimer -= Time.deltaTime;
        if (this.shootTimer > 0) return;
        this.shootTimer = this.shootDelay;
        for (int i = 0; i < this.firePos.Count; i++)
        {
            if(this.effect != null)
            {
                Instantiate(this.effect, this.firePos[i].position, Quaternion.identity);
            }
            GameObject bulletObj = Instantiate(this.bullet, this.firePos[i].position, Quaternion.identity);
            Rigidbody2D bulletRigidbody = bulletObj.GetComponent<Rigidbody2D>();
            Vector3 direction = target.transform.position - transform.position;
            bulletRigidbody.velocity = new Vector2(direction.x, direction.y).normalized * 10;
            float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
            bulletObj.transform.rotation = Quaternion.Euler(0f, 0f, rot + 90);
        }
    }

/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.isCheckShoot = true;
            this.target = collision.gameObject;
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.isCheckShoot = true;
            this.target = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.isCheckShoot = false;
            target = null;
        }
    }
}
