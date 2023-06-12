using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonCtrl : BaseMonobehavior
{
    [SerializeField]
    protected CannonShoot cannonShoot;
    [SerializeField]
    protected CannonRocket cannonRocket;
    [SerializeField]
    protected CannonMultiRay cannonMultiRay;
    [SerializeField]
    protected CannonOther cannonOther;
    [SerializeField]
    private CannonParentShoot cannonParentShoot;

    public CannonShoot CannonShoot { get => cannonShoot; }
    public CannonRocket CannonRocket { get => cannonRocket; }
    public CannonMultiRay CannonMultiRay { get => cannonMultiRay; }
    public CannonOther CannonOther { get => cannonOther; }
    public CannonParentShoot CannonParentShoot { get => cannonParentShoot; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCannonShoot();
        this.LoadCannonMultiRay();
        this.LoadCannonRocket();
        this.LoadCannonOther();
        this.LoadCannonParentShoot();
    }

    protected virtual void LoadCannonShoot()
    {
        if (this.cannonShoot != null) return;
        this.cannonShoot = gameObject.GetComponentInChildren<CannonShoot>();
    }

    protected virtual void LoadCannonMultiRay()
    {
        if (this.cannonMultiRay != null) return;
        this.cannonMultiRay = gameObject.GetComponentInChildren<CannonMultiRay>();
    }

    protected virtual void LoadCannonRocket()
    {
        if (this.cannonRocket != null) return;
        this.cannonRocket = gameObject.GetComponentInChildren<CannonRocket>();
    }

    protected virtual void LoadCannonOther()
    {
        if (this.cannonOther != null) return;
        this.cannonOther = gameObject.GetComponentInChildren<CannonOther>();
    }

    protected virtual void LoadCannonParentShoot()
    {
        if (this.cannonParentShoot != null) return;
        this.cannonParentShoot = gameObject.GetComponentInChildren<CannonParentShoot>();
    }
}
