using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBugEnemy : BaseMonobehavior
{

    [SerializeField]
    protected Bug bugSO;
    [SerializeField]
    protected List<GameObject> bossList;
    private int rand;
    [SerializeField]
    protected float maxX;
    [SerializeField]
    protected float minX;
    [SerializeField]
    private float timeDelaySpawn;
    [SerializeField]
    private float timeDelaySpawnMax;
    private float timer;
    private int countBoss = 2;
    private int countDieBoss = 1;

    private float timeOpenPopup = 3f;

    protected override void Start()
    {
        base.Start();
        UIManager.Instance.Tabbar.TxtLevel.text = btnPlayGame.levelName;
        this.timeDelaySpawn = PlayerPrefs.GetFloat("TimeDelaySpawn");
        this.timeDelaySpawnMax = PlayerPrefs.GetFloat("TimeDelaySpawnMax");
    }

    private void FixedUpdate()
    {
        //spawn boss
        if(UIManager.Instance.PopupTimer.IsSpawnBoss == true)
        {
            if (this.countBoss > 0)
            {
                this.SpawnBossBug(5f);
            } else
            {
                UIManager.Instance.PopupTimer.IsSpawn = false;
                if (EnemyDamReceiver.dieBoss == true && EnemyDamReceiver.dieBoss2 == true)
                {
                    if (HouseDamReceiver.checkPerfect == true)
                    {
                        if (this.timeOpenPopup <= 0)
                        {
                            UIManager.Instance.Popup.PopupPerfect.gameObject.SetActive(true);
                            if (btnPlayGame.levelName == "NORMAL")
                            {
                                PlayerPrefs.SetInt("levelCompleteNormal", 1);
                            } else if (btnPlayGame.levelName == "INTERMEDIATE")
                            {
                                PlayerPrefs.SetInt("levelCompleteInter", 1);
                            } else if (btnPlayGame.levelName == "HARD")
                            {
                                PlayerPrefs.SetInt("levelCompleteHard", 1);
                            }
                        } else
                        {
                            this.timeOpenPopup -= Time.fixedDeltaTime;
                        }
                    }
                    else if (HouseDamReceiver.checkPerfect == false)
                    {
                        DetailHome.cardDetail = 1;
                        if (this.timeOpenPopup <= 0)
                        {
                            UIManager.Instance.Popup.PopupGameWin.gameObject.SetActive(true);
                            if (btnPlayGame.levelName == "NORMAL")
                            {
                                PlayerPrefs.SetInt("levelCompleteNormal", 1);
                            }
                            else if (btnPlayGame.levelName == "INTERMEDIATE")
                            {
                                PlayerPrefs.SetInt("levelCompleteInter", 1);
                            }
                            else if (btnPlayGame.levelName == "HARD")
                            {
                                PlayerPrefs.SetInt("levelCompleteHard", 1);
                            }
                        }
                        else
                        {
                            this.timeOpenPopup -= Time.fixedDeltaTime;
                        }
                    }
                    DetailHome.count = 1;
                    DetailHome.coinDetail = 100;
                }
            }
        }

        if (UIManager.Instance.PopupTimer.IsSpawnMax == true)
        {
            if (UIManager.Instance.PopupTimer.IsSpawn == true)
            {
                this.SpawnWeakBug(this.timeDelaySpawnMax);
                if (UIManager.Instance.PopupTimer.IsSpawnStrong == true)
                {
                    this.SpawnNormalBug(this.timeDelaySpawnMax);
                    this.SpawnStrongBug(this.timeDelaySpawnMax);
                }

            }
        }
        else if (UIManager.Instance.PopupTimer.IsSpawnMax == false)
        {
            if (UIManager.Instance.PopupTimer.IsSpawn == true)
            {
                this.SpawnWeakBug(this.timeDelaySpawn);
                if (UIManager.Instance.PopupTimer.IsSpawnStrong == true)
                {
                    this.SpawnNormalBug(this.timeDelaySpawn);
                    this.SpawnStrongBug(this.timeDelaySpawn);
                }

            }
        }
    }

    protected virtual void SpawnWeakBug(float timerMax)
    {
        if(UIManager.Instance.PopupTimer.IsSpawnRight == false)
        {
            this.timer -= Time.fixedDeltaTime;
            if (this.timer > 0) return;
            this.timer = timerMax;
            this.rand = Random.Range(0, this.bugSO.weakbugList.Count);
            Instantiate(this.bugSO.weakbugList[this.rand], new Vector2(Random.Range(minX, maxX), 15f), Quaternion.identity);
        } else if(UIManager.Instance.PopupTimer.IsSpawnRight == true)
        {
            var rand = Random.Range(0, 2);
            if (rand == 0)
            {
                this.timer -= Time.fixedDeltaTime;
                if (this.timer > 0) return;
                this.timer = timerMax;
                this.rand = Random.Range(0, this.bugSO.weakbugList.Count);
                Instantiate(this.bugSO.weakbugList[this.rand], new Vector2(Random.Range(minX, maxX), 15f), Quaternion.identity);
            }
            else if (rand == 1 || rand == 2)
            {
                this.timer -= Time.fixedDeltaTime;
                if (this.timer > 0) return;
                this.timer = timerMax;
                this.rand = Random.Range(0, this.bugSO.weakbugList.Count);
                Instantiate(this.bugSO.weakbugList[this.rand], new Vector2(23f, Random.Range(-12, 12)), Quaternion.identity);
            }
        }
    }

    protected virtual void SpawnNormalBug(float timerMax)
    {
        if (UIManager.Instance.PopupTimer.IsSpawnRight == false)
        {
            this.timer -= Time.fixedDeltaTime;
            if (this.timer > 0) return;
            this.timer = timerMax;
            this.rand = Random.Range(0, this.bugSO.weakbugList.Count);
            Instantiate(this.bugSO.normalbugList[this.rand], new Vector2(Random.Range(minX, maxX), 15f), Quaternion.identity);
        }
        else if (UIManager.Instance.PopupTimer.IsSpawnRight == true)
        {
            var rand = Random.Range(0, 2);
            if(rand == 0)
            {
                this.timer -= Time.fixedDeltaTime;
                if (this.timer > 0) return;
                this.timer = timerMax;
                this.rand = Random.Range(0, this.bugSO.weakbugList.Count);
                Instantiate(this.bugSO.normalbugList[this.rand], new Vector2(Random.Range(minX, maxX), 15f), Quaternion.identity);
            } else if(rand == 1 || rand == 2)
            {
                this.timer -= Time.fixedDeltaTime;
                if (this.timer > 0) return;
                this.timer = timerMax;
                this.rand = Random.Range(0, this.bugSO.weakbugList.Count);
                Instantiate(this.bugSO.normalbugList[this.rand], new Vector2(23f ,Random.Range(-12, 12)), Quaternion.identity);
            }
        }
    }

    protected virtual void SpawnStrongBug(float timerMax)
    {
        if (UIManager.Instance.PopupTimer.IsSpawnRight == false)
        {
            this.timer -= Time.fixedDeltaTime;
            if (this.timer > 0) return;
            this.timer = timerMax;
            this.rand = Random.Range(0, this.bugSO.weakbugList.Count);
            Instantiate(this.bugSO.strongbugList[this.rand], new Vector2(Random.Range(minX, maxX), 15f), Quaternion.identity);
        }
        else if (UIManager.Instance.PopupTimer.IsSpawnRight == true)
        {
            var rand = Random.Range(0, 2);
            if (rand == 0)
            {
                this.timer -= Time.fixedDeltaTime;
                if (this.timer > 0) return;
                this.timer = timerMax;
                this.rand = Random.Range(0, this.bugSO.weakbugList.Count);
                Instantiate(this.bugSO.strongbugList[this.rand], new Vector2(Random.Range(minX, maxX), 15f), Quaternion.identity);
            } else if(rand == 1 || rand == 2)
            {
                this.timer -= Time.fixedDeltaTime;
                if (this.timer > 0) return;
                this.timer = timerMax;
                this.rand = Random.Range(0, this.bugSO.weakbugList.Count);
                Instantiate(this.bugSO.strongbugList[this.rand], new Vector2(23f, Random.Range(-12, 12)), Quaternion.identity);
            }
        }
    }

    protected virtual void SpawnBossBug(float timerMax)
    {
        if (UIManager.Instance.PopupTimer.IsSpawnRight == false)
        {
            /*this.timer -= Time.fixedDeltaTime;
            if (this.timer > 0) return;
            this.timer = timerMax;
            this.rand = Random.Range(0, this.bossList.Count);
            Instantiate(this.bossList[this.rand], new Vector2(Random.Range(minX, maxX), 15f), Quaternion.identity);
            this.countBoss--;*/
            if(this.countDieBoss > 0)
            {
                this.timer -= Time.fixedDeltaTime;
                if (this.timer > 0) return;
                this.timer = timerMax;
                this.rand = Random.Range(0, this.bossList.Count);
                Instantiate(this.bossList[0], new Vector2(Random.Range(minX, maxX), 15f), Quaternion.identity);
                this.countBoss--;
                this.countDieBoss--;
            } else
            {
                this.timer -= Time.fixedDeltaTime;
                if (this.timer > 0) return;
                this.timer = timerMax;
                this.rand = Random.Range(0, this.bossList.Count);
                Instantiate(this.bossList[1], new Vector2(Random.Range(minX, maxX), 15f), Quaternion.identity);
                this.countBoss--;
            }

        }
        else if (UIManager.Instance.PopupTimer.IsSpawnRight == true)
        {
            /*var rand = Random.Range(0, 2);
            if (rand == 0)
            {
                this.timer -= Time.fixedDeltaTime;
                if (this.timer > 0) return;
                this.timer = timerMax;
                this.rand = Random.Range(0, this.bossList.Count);
                Instantiate(this.bossList[this.rand], new Vector2(Random.Range(minX, maxX), 15f), Quaternion.identity);
                this.countBoss--;
            }
            else if (rand == 1 || rand == 2)
            {
                this.timer -= Time.fixedDeltaTime;
                if (this.timer > 0) return;
                this.timer = timerMax;
                this.rand = Random.Range(0, this.bossList.Count);
                Instantiate(this.bossList[this.rand], new Vector2(23f, Random.Range(-12, 12)), Quaternion.identity);
                this.countBoss--;
            }*/
            if(this.countDieBoss > 0)
            {
                this.timer -= Time.fixedDeltaTime;
                if (this.timer > 0) return;
                this.timer = timerMax;
                this.rand = Random.Range(0, this.bossList.Count);
                Instantiate(this.bossList[0], new Vector2(Random.Range(minX, maxX), 15f), Quaternion.identity);
                this.countBoss--;
                this.countDieBoss--;
            } else
            {
                this.timer -= Time.fixedDeltaTime;
                if (this.timer > 0) return;
                this.timer = timerMax;
                this.rand = Random.Range(0, this.bossList.Count);
                Instantiate(this.bossList[1], new Vector2(Random.Range(minX, maxX), 15f), Quaternion.identity);
                this.countBoss--;
            }
        }
    }
}
