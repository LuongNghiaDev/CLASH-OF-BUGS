using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CannonShoot : CannonParentShoot
{
    [SerializeField]
    protected CircleCollider2D circleCollider2D;
    [SerializeField]
    protected float radiusCollider;
    protected Vector3 direction;
    protected float force = 10;
    private bool isCheckCannonShoot = false;
    [SerializeField]
    protected GameObject effect;

    public float RadiusCollider { get => radiusCollider; }
    public bool IsCheckCannonShoot { get => isCheckCannonShoot; set => isCheckCannonShoot = value; }

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
        if(target.gameObject.activeInHierarchy == false)
        {
            this.isCheckCannonShoot = false;
        }
        if (isCheckCannonShoot == false) return;
        this.shootTimer -= Time.deltaTime;
        if (this.shootTimer > 0) return;
        this.shootTimer = this.shootDelay;
        if (this.target != null)
        {
            for (int i = 0; i < this.firePos.Count; i++)
            {
                Instantiate(this.effect, this.firePos[i].position, Quaternion.identity);
                GameObject bulletObj = Instantiate(this.bullet, this.firePos[i].position, Quaternion.identity);
                Rigidbody2D bulletRigidbody = bulletObj.GetComponent<Rigidbody2D>();
                Vector3 direction = this.target.transform.position - transform.position;
                bulletRigidbody.velocity = new Vector2(direction.x, direction.y).normalized * 10;
                float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
                bulletObj.transform.rotation = Quaternion.Euler(0f, 0f, rot + 90);

                AudioController.Instance.playSound(AudioController.Instance.WeaponSound);
            }
        }
    }

    /*    private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Enemy"))
            {
                this.isCheckCannonShoot = true;
                this.target = collision.gameObject;
            }
        }*/

    private void OnTriggerStay2D(Collider2D collision)
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
            target = null;
        }
    }
}
