using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletPlane : BaseMonobehavior
{

    public Rigidbody2D rg;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody2D();
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
