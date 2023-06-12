using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class btnPlayGame : BaseButtonController
{

    [SerializeField]
    protected TypeNameOption nameOption;
    [SerializeField]
    protected GameObject unlock;
    public static string levelName = "";
    private int countPlay = 5;

    protected override void OnClick()
    {
        var totalCount = countPlay - 1;
        PlayerPrefs.SetInt("CountPlay", totalCount);
        if(PlayerPrefs.GetInt("CountPlay") == 0)
        {
            Debug.Log("No Play");
        } else
        {
            if (this.nameOption.ToString() == "easy")
            {
                PlayerPrefs.SetFloat("TimeDelaySpawn", 5);
                PlayerPrefs.SetFloat("TimeDelaySpawnMax", 3);

                levelName = "EASY";
                SceneManager.LoadScene("SampleScene");
            }
            else if (this.nameOption.ToString() == "normal")
            {
                PlayerPrefs.SetFloat("TimeDelaySpawn", 6);
                PlayerPrefs.SetFloat("TimeDelaySpawnMax", 5);

                levelName = "NORMAL";
                SceneManager.LoadScene("SampleScene");
            }
            else if (this.nameOption.ToString() == "intermediate")
            {
                if (this.unlock.activeInHierarchy)
                {
                    UIManager.Instance.Popup.PopupNotiUnlock.gameObject.SetActive(true);
                    UIManager.Instance.Popup.PopupNotiUnlock.Txt.text = "You need to play win Normal mode to unlock";
                }
                else
                {
                    PlayerPrefs.SetFloat("TimeDelaySpawn", 5);
                    PlayerPrefs.SetFloat("TimeDelaySpawnMax", 4);

                    levelName = "INTERMEDIATE";
                    SceneManager.LoadScene("SampleScene");
                }
            }
            else if (this.nameOption.ToString() == "hard")
            {
                if (this.unlock.activeInHierarchy)
                {
                    UIManager.Instance.Popup.PopupNotiUnlock.gameObject.SetActive(true);
                    UIManager.Instance.Popup.PopupNotiUnlock.Txt.text = "You need to play win Intermediate mode to unlock";
                }
                else
                {
                    PlayerPrefs.SetFloat("TimeDelaySpawn", 3);
                    PlayerPrefs.SetFloat("TimeDelaySpawnMax", 2);

                    levelName = "HARD";
                    SceneManager.LoadScene("SampleScene");
                }
            }
            else if (this.nameOption.ToString() == "extreme")
            {
                if (this.unlock.activeInHierarchy)
                {
                    UIManager.Instance.Popup.PopupNotiUnlock.gameObject.SetActive(true);
                    UIManager.Instance.Popup.PopupNotiUnlock.Txt.text = "You need to play win Hard mode to unlock";
                }
                else
                {
                    PlayerPrefs.SetFloat("TimeDelaySpawn", 2);
                    PlayerPrefs.SetFloat("TimeDelaySpawnMax", 1);

                    levelName = "EXTREME";
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }    
    }
}

public enum TypeNameOption { 
    easy,
    normal,
    intermediate,
    hard,
    extreme
}

