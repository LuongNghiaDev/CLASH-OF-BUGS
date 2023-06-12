using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MovementParent
{
    [SerializeField]
    protected Vector3 targetOrigin;
    [SerializeField]
    protected Vector3 targetHouse;
    [SerializeField]
    protected Rigidbody2D rg;
    [SerializeField]
    protected Transform foodPos;
    [SerializeField]
    protected GameObject food1;
    [SerializeField]
    protected GameObject food2;
    private int rand = 0;
    private static int countCoin = 0;
    private int count = 2;

    protected bool isTakePlayer = false;

    protected override void Awake()
    {
        base.Awake();
        rg = GetComponentInParent<Rigidbody2D>();
        targetOrigin = FindObjectOfType<Origin>().transform.position;
        targetHouse = GameCtrl.Instance.limitAnt.position;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadFoodPos();
    }

    protected virtual void LoadFoodPos()
    {
        if (this.foodPos != null) return;
        this.foodPos = transform.parent.Find("foodPos");
    }

    protected override void Move()
    {
        if (isTakePlayer == false)
        {
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, targetOrigin, this.moveSpeed * Time.deltaTime);
            float rotz = Mathf.Atan2(-targetOrigin.y, -targetOrigin.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rotz);
        } else if(isTakePlayer == true)
        {
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, targetHouse, this.moveSpeed * Time.deltaTime);
            float rotz = Mathf.Atan2(-targetHouse.y, -targetHouse.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rotz - 30);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("HousePlayer"))
        {
            StartCoroutine(DelayDropFood());
            StopCoroutine(DelayDropFood());
        }
        else if(collision.CompareTag("Origin"))
        {
            this.count = 1;
            StartCoroutine(DelayTakePlayer());
            StopCoroutine(DelayTakePlayer());
        }
        else if (collision.CompareTag("LimitAnt"))
        {
            this.targetHouse = FindObjectOfType<MainHouse>().transform.position;
        }
    }

    IEnumerator DelayTakePlayer()
    {
        yield return new WaitForSeconds(2f);
        this.isTakePlayer = true;
        this.rand = Random.Range(0, 1);
        if(this.rand == 0)
        {
            this.food1.SetActive(true);
        }
        else if(this.rand == 1)
        {
            this.food2.SetActive(true);
        }
    }

    IEnumerator DelayDropFood()
    {
        yield return new WaitForSeconds(2f);
        if (this.food1.activeInHierarchy == true)
        {
            if(this.count == 1)
            {
                var txtCoin = UIManager.Instance.Tabbar.TxtCoin.text.Replace("g", "");
                countCoin = int.Parse(txtCoin.ToString());
                countCoin += 50;
                UIManager.Instance.Tabbar.coin = countCoin;
                this.count--;
            }
            this.isTakePlayer = false;
            this.food1.SetActive(false);
        }
        else if (this.food2 == true)
        {
            if (this.count == 1)
            {
                var txtCoin = UIManager.Instance.Tabbar.TxtCoin.text.Replace("g", "");
                countCoin = int.Parse(txtCoin.ToString());
                countCoin += 50;
                UIManager.Instance.Tabbar.coin = countCoin;
                this.count--;
            }
            this.isTakePlayer = false;
            this.food2.SetActive(false);
        }
    }

}
