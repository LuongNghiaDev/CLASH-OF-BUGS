using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletImpartNoFly : WeaponDamSender
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.Send(collision.transform);
        }
    }
}
