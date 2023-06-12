using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNoFly : BulletParentFly
{

    [SerializeField]
    protected float timeDelay;
    [SerializeField]
    protected GameObject effectRocket;
    private int count = 1;

    protected override void RemoveBulletNoFly()
    {
        Destroy(this.gameObject, timeDelay);
        if (this.count > 0)
        {
            Instantiate(this.effectRocket, transform.position, Quaternion.identity);
            this.count--;
        }
    }

}
