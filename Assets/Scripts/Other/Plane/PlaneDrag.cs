using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class PlaneDrag : BaseMonobehavior
{
    [SerializeField]
    protected GameObject bomb;
    [SerializeField]
    protected List<Transform> firePos;
    [SerializeField]
    protected float dragDelay = 1f;
    [SerializeField]
    protected float dragTimer = 0f;
    [SerializeField]
    protected CircleCollider2D circleCollider2D;
    [SerializeField]
    protected float radiusCollider;
    private bool isCheckDragBomb = false;

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

    private void Update()
    {
        this.DragBomb();
    }

    protected virtual void DragBomb()
    {
        if (this.isCheckDragBomb == false) return;
        this.dragTimer -= Time.deltaTime;
        if (this.dragTimer > 0) return;
        this.dragTimer = this.dragDelay;

        Instantiate(this.bomb, this.firePos[0].position, Quaternion.identity);
        Instantiate(this.bomb, this.firePos[1].position, Quaternion.identity);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.isCheckDragBomb = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.isCheckDragBomb = false;
        }
    }
}
