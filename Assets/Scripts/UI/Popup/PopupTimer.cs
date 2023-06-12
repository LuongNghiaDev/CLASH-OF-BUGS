using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupTimer : BaseMonobehavior
{
    [SerializeField]
    protected Slider sliderTimer;
    [SerializeField]
    protected Image point1;
    [SerializeField]
    protected Image pointReplay1;
    [SerializeField]
    protected Image point2;
    [SerializeField]
    protected Image pointReplay2;
    [SerializeField]
    protected int maxTimer;
    private int timer = 0;

    private bool isSpawn = false;
    private bool isSpawnStrong = false;
    private bool isSpawnMax = false;
    private bool isSpawnBoss = false;
    private bool isSpawnRight = false;

    //timer
    public int gameTime = 0;
    private int count = 1;

    public bool IsSpawnStrong { get => isSpawnStrong; }
    public bool IsSpawnMax { get => isSpawnMax; }
    public bool IsSpawnBoss { get => isSpawnBoss; }
    public bool IsSpawnRight { get => isSpawnRight;  }
    public bool IsSpawn { get => isSpawn; set => isSpawn = value; }

    protected override void Awake()
    {
        base.Awake();
        this.sliderTimer.maxValue = this.maxTimer;
        this.sliderTimer.value = this.timer;
    }

    protected override void Start()
    {
        base.Start();
        StartCoroutine(CountGameTime());
    }

    private void Update()
    {
        //beta

        //spawn boss
        if (this.sliderTimer.value == 399)
        {
            if(this.count > 0)
            {
                this.isSpawnBoss = true;
                this.isSpawnMax = true;
                //open waring
                UIManager.Instance.PopupWarning.PanelWarningBoss.SetActive(true);
                this.count--;
            } 
        }

        if (this.sliderTimer.value >= this.maxTimer) return;
        this.sliderTimer.value = this.gameTime;
        //spawn max
        if(this.sliderTimer.value ==  130)
        {
            this.isSpawnMax = true;
            this.point1.gameObject.SetActive(false);
            this.pointReplay1.gameObject.SetActive(true);

            //open waring
            UIManager.Instance.PopupWarning.PanelWarning.SetActive(true);
        }
        //spawn max
        else if(this.sliderTimer.value == 270)
        {
            this.isSpawnMax = true;
            this.point2.gameObject.SetActive(false);
            this.pointReplay2.gameObject.SetActive(true);

            //open waring
            UIManager.Instance.PopupWarning.PanelWarning.SetActive(true);
        } else if(this.sliderTimer.value == 60)
        {
            this.isSpawn = true;
        }
        else if (this.sliderTimer.value == 200)
        {
            this.isSpawnStrong = true;
            this.isSpawnRight = true;
        }
        //end spawn max enemy
        else if (this.sliderTimer.value == 290)
        {
            this.isSpawnMax = false;
        }
        else if (this.sliderTimer.value == 150)
        {
            this.isSpawnMax = false;
        }
    }

    IEnumerator CountGameTime()
    {
        do
        {
            yield return new WaitForSeconds(1f);
            this.gameTime += 1;
        } while (this.gameTime <= 400);
    }

}
