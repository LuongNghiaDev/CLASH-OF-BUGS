using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombImpart : WeaponDamSender
{

    [SerializeField]
    protected GameObject effectBomb;
    private int count = 1;

    //delay effect spawn
    [SerializeField]
    private float timeDelay = 0.8f;
    private float timer;

    protected override void Start()
    {
        base.Start();
        this.timer = this.timeDelay;
    }

    private void Update()
    {
        this.DestroyBullet();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.Send(collision.transform);
        }
    }

    protected virtual void DestroyBullet()
    {
        if (this.count > 0 && this.effectBomb != null)
        {
            this.timer -= Time.deltaTime;
            if (this.timer > 0) return;
            Destroy(this.gameObject);
            Instantiate(this.effectBomb, transform.position, Quaternion.identity);
            this.count--;
            this.timer = this.timeDelay;
        }
    }
}
