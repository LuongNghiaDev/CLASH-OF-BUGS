using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugEnemyMovement : BugMovement
{

    [SerializeField]
    protected Rigidbody2D rg;
    [SerializeField]
    protected BugCtrl bugCtrl;
    [SerializeField]
    protected TypeNameBug nameBug;

    protected override void Awake()
    {
        base.Awake();
        rg = GetComponentInParent<Rigidbody2D>();
        this.targetHouse = FindObjectOfType<MainHouse>().transform.position;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBugCtrl();
    }

    protected override void Move()
    {
        transform.parent.position = Vector2.MoveTowards(transform.parent.position, this.targetHouse,
                this.moveSpeed * Time.deltaTime);

        var diff = this.targetHouse - this.transform.parent.position;
        float rotz = Mathf.Atan2(-diff.y, -diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(0f, 0f, rotz);
    }

    protected virtual void LoadBugCtrl()
    {
        if (this.bugCtrl != null) return;
        this.bugCtrl = GetComponentInChildren<BugCtrl>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Weapon"))
        {
            if(this.nameBug.ToString() == "strongbug")
            {
                this.targetHouse = collision.gameObject.transform.position;
            }
        }
        else if (collision.CompareTag("Player"))
        {
            if (this.nameBug.ToString() == "weakbug")
            {
                this.targetHouse = collision.gameObject.transform.position;
            } else if (this.nameBug.ToString() == "strongbug")
            {
                this.targetHouse = collision.gameObject.transform.position;
            }
        }
        else if (collision.CompareTag("Totem"))
        {
            if (this.nameBug.ToString() == "weakbug")
            {
                this.targetHouse = collision.gameObject.transform.position;
            }
            else if (this.nameBug.ToString() == "strongbug")
            {
                this.targetHouse = collision.gameObject.transform.position;
            }
            else if (this.nameBug.ToString() == "normalbug")
            {
                this.targetHouse = collision.gameObject.transform.position;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            if (this.nameBug.ToString() == "strongbug")
            {
                this.targetHouse = FindObjectOfType<MainHouse>().transform.position;
            }
        }
        else if (collision.CompareTag("Player"))
        {
            if (this.nameBug.ToString() == "weakbug")
            {
                this.targetHouse = FindObjectOfType<MainHouse>().transform.position;
            } else if (this.nameBug.ToString() == "strongbug")
            {
                this.targetHouse = FindObjectOfType<MainHouse>().transform.position;
            }
        }
        else if (collision.CompareTag("Totem"))
        {
            if (this.nameBug.ToString() == "weakbug")
            {
                this.targetHouse = FindObjectOfType<MainHouse>().transform.position;
            }
            else if (this.nameBug.ToString() == "strongbug")
            {
                this.targetHouse = FindObjectOfType<MainHouse>().transform.position;
            }
            else if (this.nameBug.ToString() == "normalbug")
            {
                this.targetHouse = FindObjectOfType<MainHouse>().transform.position;
            }
        }
    }

    /*    protected virtual void PushBack(Transform pushObj)
        {
            Vector2 pushDirection = new Vector2(0, (pushObj.position.y - transform.position.y)).normalized;
            pushDirection *= this.force;
            Rigidbody2D rgPush = pushObj.gameObject.GetComponentInParent<Rigidbody2D>();
            rgPush.velocity = Vector2.zero;
            rg.AddForce(pushDirection, ForceMode2D.Impulse);
        }*/
}
