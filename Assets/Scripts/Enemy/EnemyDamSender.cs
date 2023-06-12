using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamSender : DamageSender
{
    [SerializeField]
    protected float timeDelay;
    private float timer;
    [SerializeField]
    protected TypeNameBug nameBug;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Weapon"))
        {
            if (this.nameBug.ToString() == "strongbug")
            {
                this.timer -= Time.deltaTime;
                if (this.timer > 0) return;
                this.timer = this.timeDelay;
                this.Send(collision.transform);
            }
        }
        else if (collision.CompareTag("Player"))
        {
            if (this.nameBug.ToString() == "weakbug")
            {
                this.timer -= Time.deltaTime;
                if (this.timer > 0) return;
                this.timer = this.timeDelay;
                this.Send(collision.transform);
            }
            else if (this.nameBug.ToString() == "strongbug")
            {
                this.timer -= Time.deltaTime;
                if (this.timer > 0) return;
                this.timer = this.timeDelay;
                this.Send(collision.transform);
            }
        }
        else if (collision.CompareTag("HousePlayer"))
        {
            if (this.nameBug.ToString() == "weakbug")
            {
                this.timer -= Time.deltaTime;
                if (this.timer > 0) return;
                this.timer = this.timeDelay;
                this.Send(collision.transform);
            }
            else if (this.nameBug.ToString() == "strongbug")
            {
                this.timer -= Time.deltaTime;
                if (this.timer > 0) return;
                this.timer = this.timeDelay;
                this.Send(collision.transform);
            }
            else if (this.nameBug.ToString() == "normalbug")
            {
                this.timer -= Time.deltaTime;
                if (this.timer > 0) return;
                this.timer = this.timeDelay;
                this.Send(collision.transform);
            }
        }
        //totem
        else if (collision.CompareTag("Totem"))
        {
            if (this.nameBug.ToString() == "weakbug")
            {
                this.timer -= Time.deltaTime;
                if (this.timer > 0) return;
                this.timer = this.timeDelay;
                this.Send(collision.transform);
            }
            else if (this.nameBug.ToString() == "strongbug")
            {
                this.timer -= Time.deltaTime;
                if (this.timer > 0) return;
                this.timer = this.timeDelay;
                this.Send(collision.transform);
            }
            else if (this.nameBug.ToString() == "normalbug")
            {
                this.timer -= Time.deltaTime;
                if (this.timer > 0) return;
                this.timer = this.timeDelay;
                this.Send(collision.transform);
            }
        }
    }
}
