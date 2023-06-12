using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MovementParent
{
    [SerializeField]
    protected Vector3 targetOrigin;
    [SerializeField]
    protected Vector3 targetHouse;
    [SerializeField]
    protected Rigidbody2D rg;
    [SerializeField]
    protected Transform foodPos;
    protected bool isTakeEnemy = false;
    [SerializeField]
    protected GameObject food1;
    [SerializeField]
    protected GameObject food2;
    private int rand = 0;
    private static int countCoin = 0;
    private int count = 2;

    protected override void Awake()
    {
        base.Awake();
        rg = GetComponentInParent<Rigidbody2D>();
        targetOrigin = FindObjectOfType<Origin>().transform.position;
        targetHouse = FindObjectOfType<EnemyHouse>().transform.position;
    }

    protected override void Move()
    {
        if (this.isTakeEnemy == false)
        {
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, targetOrigin, this.moveSpeed * Time.deltaTime);
            float rotz = Mathf.Atan2(-targetOrigin.y, -targetOrigin.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rotz);
        }
        else
        {
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, targetHouse, this.moveSpeed * Time.deltaTime);
            float rotz = Mathf.Atan2(-targetHouse.y, -targetHouse.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rotz + 140f);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("HouseEnemy"))
        {
            StartCoroutine(DelayDropFood());
            StopCoroutine(DelayDropFood());
        }
        else if (collision.CompareTag("Origin"))
        {
            this.count = 1;
            StartCoroutine(DelayTakePlayer());
            StopCoroutine(DelayTakePlayer());
        }
    }

    IEnumerator DelayTakePlayer()
    {
        yield return new WaitForSeconds(2f);
        this.isTakeEnemy = true;
        this.rand = Random.Range(0, 1);
        if (this.rand == 0)
        {
            this.food1.SetActive(true);
        }
        else if (this.rand == 1)
        {
            this.food2.SetActive(true);
        }
    }

    IEnumerator DelayDropFood()
    {
        yield return new WaitForSeconds(2f);
        if (this.food1.activeInHierarchy == true)
        {
            var txtCoin = UIManager.Instance.Tabbar.TxtCoin.text.Replace("g", "");
            countCoin = int.Parse(txtCoin.ToString());
            if (this.count == 1 && countCoin > 0)
            {
                countCoin -= 10;
                UIManager.Instance.Tabbar.coin = countCoin;
                this.count--;
            }
            this.isTakeEnemy = false;
            this.food1.SetActive(false);
        }
        else if (this.food2 == true)
        {
            var txtCoin = UIManager.Instance.Tabbar.TxtCoin.text.Replace("g", "");
            countCoin = int.Parse(txtCoin.ToString());
            if (this.count == 1 && countCoin > 0)
            {
                countCoin -= 10;
                UIManager.Instance.Tabbar.coin = countCoin;
                this.count--;
            }
            this.isTakeEnemy = false;
            this.food2.SetActive(false);
        }
    }
}
