using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamReceiver : DamageReceiver
{

    [SerializeField]
    protected PlayerCtrl playerCtrl;
    [SerializeField]
    protected GameObject bloodObj;

    public PlayerCtrl PlayerCtrl { get => playerCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }

    protected override void OnDead()
    {
        this.playerCtrl.gameObject.SetActive(false);
        Instantiate(bloodObj, transform.position, Quaternion.identity);
        if (this.playerCtrl.FootprintSpawner != null)
        {
            this.playerCtrl.FootprintSpawner.gameObject.SetActive(false);
        }
    }
}
