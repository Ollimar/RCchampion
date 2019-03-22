using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoPanelScript : MonoBehaviour
{
    public PlayerDataScript playerData;

    public Text textPlayerName;
    public Text textplayerLevel;
    public Text textPlayerMoney;
    public Image playerEXPbar;

    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerDataScript>();
        textPlayerName = GameObject.Find("PlayerNametext").GetComponent<Text>();
        textplayerLevel = GameObject.Find("LevelText").GetComponent<Text>();
        textPlayerMoney = GameObject.Find("TextMoney").GetComponent<Text>();
        textPlayerMoney = GameObject.Find("TextMoney").GetComponent<Text>();
        playerEXPbar = GameObject.Find("PlayerExpBar").GetComponent<Image>(); ;
        playerEXPbar.fillAmount = playerData.playerExp / 100f;
        textPlayerName.text  =             playerData.playerName;
        textplayerLevel.text = "Level: " + playerData.playerLevel.ToString();
        textPlayerMoney.text = "Coins: " + playerData.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
