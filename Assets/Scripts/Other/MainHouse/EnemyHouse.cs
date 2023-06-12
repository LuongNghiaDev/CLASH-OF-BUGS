using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHouse : HouseParent
{
    [SerializeField]
    protected Transform posSpawn;
    [SerializeField]
    protected GameObject antRed;
    //timer
    public int gameTime = 0;
    [SerializeField]
    protected float timeDelaySpawn;
    private float timerSpawn = 0;

    private void Update()
    {
        if (this.gameTime >= 16)
        {
            this.SpawnAntRed();
        }
    }

    protected virtual void SpawnAntRed()
    {
        this.timerSpawn -= Time.deltaTime;
        if (this.timerSpawn > 0) return;
        Instantiate(antRed, posSpawn.position, Quaternion.identity);
        this.timerSpawn = this.timeDelaySpawn;
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(CountGameTime());
    }
    
    IEnumerator CountGameTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            gameTime += 1;
        }
    }

}
