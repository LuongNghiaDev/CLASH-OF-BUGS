using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootprintSpawner : BaseMonobehavior
{
    [SerializeField]
    protected Transform posOne;
    [SerializeField]
    protected Transform posTwo;
    [SerializeField]
    protected GameObject footPrint;
    private GameObject footPrintObj1;
    private GameObject footPrintObj2;
    [SerializeField]
    protected float shootDelay = 0.4f;
    private float shootTimer;
    [SerializeField]
    protected float timeDestroy = 5;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPosOneTransform();
        this.LoadPosTwoTransform();
    }

    private void FixedUpdate()
    {
        this.shootTimer -= Time.fixedDeltaTime;
        if (this.shootTimer > 0) return;
        this.shootTimer = this.shootDelay;

        this.footPrintObj1 = Instantiate(footPrint, posOne.position, Quaternion.identity);
        this.footPrintObj2 = Instantiate(footPrint, posTwo.position, Quaternion.identity);

        this.footPrintObj1.transform.parent = GameCtrl.Instance.HolderFootPrint;
        this.footPrintObj2.transform.parent = GameCtrl.Instance.HolderFootPrint;

        Destroy(footPrintObj1, timeDestroy);
        Destroy(footPrintObj2, timeDestroy);
    }

    protected virtual void LoadPosOneTransform()
    {
        if (this.posOne != null) return;

        this.posOne = transform.Find("posone");
    }

    protected virtual void LoadPosTwoTransform()
    {
        if (this.posTwo != null) return;

        this.posTwo = transform.Find("postwo");
    }
}
