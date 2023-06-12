using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamReceiver : DamageReceiver
{
    [SerializeField]
    protected CannonCtrl cannonCtrl;

    public CannonCtrl CannonCtrl { get => cannonCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadcannonCtrl();
    }

    protected virtual void LoadcannonCtrl()
    {
        if (this.cannonCtrl != null) return;
        this.cannonCtrl = GetComponentInParent<CannonCtrl>();
    }

    protected override void OnDead()
    {
        this.cannonCtrl.gameObject.SetActive(false);
    }

}
