using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemDamReceiver : DamageReceiver
{

    protected override void OnDead()
    {
        GameObject parentObject = transform.parent.gameObject;
        parentObject.SetActive(false);
    }
}
