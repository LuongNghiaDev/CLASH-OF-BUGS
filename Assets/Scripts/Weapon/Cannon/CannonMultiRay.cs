using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class CannonMultiRay : CannonParentShoot
{

    [SerializeField]
    protected CircleCollider2D circleCollider2D;
    [SerializeField]
    protected float radiusCnMultiRay;
    private bool isCheckShoot = false;
    [SerializeField]
    protected GameObject effect;

    public float RadiusCnMultiRay { get => radiusCnMultiRay; }

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
        this.circleCollider2D.radius = this.radiusCnMultiRay;
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
        if (target != null)
        {
            StartCoroutine(DelayShoot());
        }
    }
    IEnumerator DelayShoot()
    {
        for (int i = 0; i < this.firePos.Count; i++)
        {
            yield return null;

            GameObject bulletPool = PoolObjectBullet.Instance.GetPoolObjectBullet();
            if(bulletPool != null)
            {
                bulletPool.SetActive(true);
                bulletPool.transform.position = this.firePos[i].position;
                Instantiate(this.effect, this.firePos[i].position, Quaternion.identity);

                //add velocity
                Rigidbody2D bulletRigidbody = bulletPool.GetComponent<Rigidbody2D>();
                Vector3 direction = target.transform.position - transform.position;
                bulletRigidbody.velocity = new Vector2(direction.x, direction.y).normalized * 10;
                float rot = Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg;
                bulletPool.transform.rotation = Quaternion.Euler(0f, 0f, rot + 90);

                AudioController.Instance.playSound(AudioController.Instance.WeaponSound1);
            }
        }
    }

/*    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.isCheckShoot = true;
            target = collision.gameObject;
        }
    }*/

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.isCheckShoot = true;
            target = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.isCheckShoot = false;
            target = null;
            StopCoroutine(DelayShoot());
        }
    }
}
