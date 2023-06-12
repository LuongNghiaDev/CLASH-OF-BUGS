using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailHome : BaseMonobehavior
{
    [SerializeField]
    private Text txtCoin;
    [SerializeField]
    private Text txtCountPlay;
    [SerializeField]
    private Text txtTimerCount;
    [SerializeField]
    private Text txtCard;
    public float totalTime = 30 * 60; 
    private float timeRemaining;
    public static int coinDetail = 0;
    public static int count = 1;
    public static int cardDetail = 0;

    public Text TxtCoin { get => txtCoin; set => txtCoin = value; }
    public Text TxtCountPlay { get => txtCountPlay; set => txtCountPlay = value; }
    public Text TxtTimerCount { get => txtTimerCount; set => txtTimerCount = value; }
    public Text TxtCard { get => txtCard; set => txtCard = value; }

    protected override void Start()
    {
        base.Start();
        PlayerPrefs.SetInt("CountCard", 2);
        if (PlayerPrefs.GetInt("CountPlay") >= 0)
        {
            txtCountPlay.text = "x" + (PlayerPrefs.GetInt("CountPlay")).ToString();
        }
        if (PlayerPrefs.GetInt("CountCard") >= 0)
        {
            txtCard.text = "x" + (PlayerPrefs.GetInt("CountCard")).ToString();
        }
        timeRemaining = totalTime;
    }

    private void Update()
    {
        if(int.Parse(txtCountPlay.text.Replace('x', ' ')) < 5)
        {
            var countSpawn = int.Parse(txtCountPlay.text.Replace('x', ' '));
            timeRemaining -= Time.deltaTime;

            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            string timerText = string.Format("{0:00}:{1:00}", minutes, seconds);
            txtTimerCount.text = timerText;

            if (timeRemaining <= 0f)
            {
                countSpawn += 1;
                PlayerPrefs.SetInt("CountPlay", countSpawn);
            }
        } else
        {
            timeRemaining = totalTime;
        }
        if(count > 0)
        {
            var coin = int.Parse(txtCoin.text.Replace('g', ' ')) + coinDetail;
            txtCoin.text = coin.ToString() + "g";
            var card = int.Parse(txtCard.text.Replace('x', ' ')) + cardDetail;
            txtCard.text = "x"+card.ToString();
            count--;
        }
    }
}
