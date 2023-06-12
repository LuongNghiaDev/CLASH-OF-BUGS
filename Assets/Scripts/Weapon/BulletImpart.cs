using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpart : WeaponDamSender
{

    [SerializeField]
    protected GameObject effect;
    private int count = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.Send(collision.transform);
            this.DestroyBullet();
        }
    }

    protected virtual void DestroyBullet()
    {
        gameObject.SetActive(false);
        if (this.count > 0 && this.effect != null)
        {
            Instantiate(this.effect, transform.position, Quaternion.identity);
            this.count--;
        }
    }
}
