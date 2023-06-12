using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : BaseMonobehavior
{

    [SerializeField]
    protected float speed;
    private static PlaneMovement instance;
    [SerializeField]
    protected GameObject pointFlag;

    public static PlaneMovement Instance { get => instance; set => instance = value; }
    public GameObject PointFlag { get => pointFlag; set => pointFlag = value; }

    protected override void Awake()
    {
        base.Awake();
        if (instance == null)
            instance = this;
    }

    private void Update()
    {
        this.Move();
    }

    protected virtual void Move()
    {
        if(ClickMouse.Instance.IsFly == true)
        {
            transform.parent.position = Vector2.MoveTowards(transform.parent.position, this.pointFlag.transform.position,
    this.speed * Time.deltaTime);

            var diff = this.pointFlag.transform.position - transform.parent.position;
            float rotz = Mathf.Atan2(-diff.y, -diff.x) * Mathf.Rad2Deg;
            transform.parent.rotation = Quaternion.Euler(0f, 0f, rotz);
        } 
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Point"))
        {
            Destroy(collision.gameObject);
            this.pointFlag = ClickMouse.Instance.limitPlane;
        } else if(collision.CompareTag("LimitPlane"))
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
