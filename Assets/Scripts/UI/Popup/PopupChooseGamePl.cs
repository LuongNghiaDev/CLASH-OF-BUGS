using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PopupChooseGamePl : BaseMonobehavior
{
    [SerializeField]
    protected GameObject unlockHard;
    [SerializeField]
    protected GameObject unlockInter;
    [SerializeField]
    protected GameObject unlockExtreme;

    private void Update()
    {
        if (PlayerPrefs.GetInt("levelCompleteNormal") == 1)
        {
            this.unlockHard.SetActive(false);
        } else if(PlayerPrefs.GetInt("levelCompleteInter") == 1)
        {
            this.unlockInter.SetActive(false);
        } else if (PlayerPrefs.GetInt("levelCompleteHard") == 1)
        {
            this.unlockExtreme.SetActive(false);
        }
    }
}
