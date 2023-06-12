using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawImpart : CuttingDamSender
{

    [SerializeField]
    protected float timeDelay;
    private float timer;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            this.timer -= Time.deltaTime;
            if (this.timer > 0) return;
            this.timer = this.timeDelay;
            this.Send(collision.transform);
        }
    }
}
