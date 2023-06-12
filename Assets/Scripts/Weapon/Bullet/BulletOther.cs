using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class BulletOther : BulletParentFly
{

    [SerializeField]
    protected float timeDelay;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody2D();
    }

    protected override void RemoveBulletNoFly()
    {
        Destroy(this.gameObject, timeDelay);
    }

    protected virtual void LoadRigidbody2D()
    {
        if (this.rg != null) return;
        this.rg = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limit"))
        {
            gameObject.SetActive(false);
        }
    }
}
