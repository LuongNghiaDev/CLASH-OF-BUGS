using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PlaneShooting : PlaneParentShoot
{
    [SerializeField]
    protected CircleCollider2D circleCollider2D;
    [SerializeField]
    protected float radiusCollider;
    private bool isCheckCannonShoot = false;
    [SerializeField]
    protected GameObject effect;

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
        this.circleCollider2D.radius = this.radiusCollider;
    }

    protected override void Shoot()
    {
        if (isCheckCannonShoot == false) return;
        this.shootTimer -= Time.deltaTime;
        if (this.shootTimer > 0) return;
        this.shootTimer = this.shootDelay;
        if (this.target != null)
        {
            for (int i = 0; i < this.firePos.Count; i++)
            {
                GameObject bulletPool = PoolObjectBullet.Instance.GetPoolObjectPlane();
                if(bulletPool != null)
                {
                    bulletPool.SetActive(true);
                    bulletPool.transform.position = this.firePos[i].position;
                    Instantiate(this.effect, this.firePos[i].position, Quaternion.identity);

                    Rigidbody2D bulletRigidbody = bulletPool.GetComponent<Rigidbody2D>();
                    Vector3 direction = this.target.transform.position - transform.position;
                    bulletRigidbody.velocity = new Vector2(direction.x, direction.y).normalized * 10;
                    float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
                    bulletPool.transform.rotation = Quaternion.Euler(0f, 0f, rot);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.isCheckCannonShoot = true;
            this.target = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.isCheckCannonShoot = false;
        }
    }
}
