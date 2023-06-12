using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCannon : BaseMonobehavior
{
    [SerializeField]
    protected Transform frameWhite;
    [SerializeField]
    protected Transform chooseCannon;
    [SerializeField]
    protected CannonCtrl cannonCtrl;
    [SerializeField]
    protected float scaleFrame = 0f;

    protected override void LoadComponents()
    {
        this.LoadChooseCannon();
        this.LoadFrame();
        this.LoadCannonCtrl();
    }

    protected virtual void LoadCannonCtrl()
    {
        if (this.cannonCtrl != null) return;
        this.cannonCtrl = gameObject.GetComponentInParent<CannonCtrl>();
    }

    protected virtual void LoadFrame()
    {
        if (this.frameWhite != null) return;
        this.frameWhite = transform.Find("Frame");
    }

    protected virtual void LoadChooseCannon()
    {
        if (this.chooseCannon != null) return;
        this.chooseCannon = transform.Find("ChooseCannon");
    }

    public virtual void ShowFrameWhite()
    {
        this.frameWhite.gameObject.SetActive(true);
        this.frameWhite.transform.localScale = new Vector3(scaleFrame + 2, scaleFrame + 2,
            scaleFrame + 2);
    }

    public virtual void ShowChooseCannon()
    {
        this.chooseCannon.gameObject.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Unlock"))
        {
            collision.gameObject.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Unlock"))
        {
            collision.gameObject.SetActive(true);
        }
    }
}
