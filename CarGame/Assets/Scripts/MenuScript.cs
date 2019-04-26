using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject mycarMenu;
    public GameObject myStatsMenu;
    public GameObject levelMenu;
    public GameObject levelMenuCloseButton;
    public GameObject carsMenuCloseButton;
    public GameObject levelPrompt1;
    public GameObject levelPrompt2;
    public GameObject levelPrompt3;

    public GameObject[] carSymbols;

    public Text playerNameText;
    public Text levelNameText;
    //public Text playerMoneyText;

    public PlayerDataScript playerData;

    public Animator fadeAnim;

    // Start is called before the first frame update
    void Start()
    {
        mycarMenu.SetActive(false);
        levelMenu.SetActive(false);
        levelMenuCloseButton.SetActive(false);
        carsMenuCloseButton.SetActive(false);
        levelPrompt1.SetActive(false);
        levelPrompt2.SetActive(false);
        levelPrompt3.SetActive(false);
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerDataScript>();
        //playerMoneyText.text = playerData.money.ToString();
        myStatsMenu.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuickRace(int levelNumber)
    {
        StartCoroutine(StartRace(levelNumber));
    }

    public void Cars()
    {
        if(!mycarMenu.activeSelf)
        {
            if(!myStatsMenu.activeSelf && !levelMenu.activeSelf)
            {
                mycarMenu.SetActive(true);
                carsMenuCloseButton.SetActive(true);
            }           
        }

        else if (mycarMenu.activeSelf)
        {
            mycarMenu.SetActive(false);
            carsMenuCloseButton.SetActive(false);
        }
    }

    public void Stats()
    {
        if(!myStatsMenu.activeSelf)
        {
            if(!mycarMenu.activeSelf && !levelMenu.activeSelf)
            {
                myStatsMenu.SetActive(true);
            }
            
        }

        else if (myStatsMenu.activeSelf)
        {
            myStatsMenu.SetActive(false);
            //playerMoneyText.text = playerData.money.ToString();
        }
    }

    public void Levels()
    {
        if (!levelMenu.activeSelf)
        {
            if(!myStatsMenu.activeSelf && !mycarMenu.activeSelf)
            {               
                levelMenu.SetActive(true);
                levelMenuCloseButton.SetActive(true);
            }           
        }

        else if (levelMenu.activeSelf)
        {
            levelMenu.SetActive(false);
            levelMenuCloseButton.SetActive(false);
        }
    }

    public void OpenLevel(int levelNumber)
    {
        if(levelNumber == 1)
        {
            if (!levelPrompt1.activeSelf)
            {
                levelPrompt1.SetActive(true);
                levelNameText.text = "PLAY ?";
            }

            else if (levelPrompt1.activeSelf)
            {
                levelPrompt1.SetActive(false);
            }
        }

        if (levelNumber == 2)
        {
            if (!levelPrompt2.activeSelf)
            {
                levelPrompt2.SetActive(true);
                levelNameText.text = "PLAY ?";
            }

            else if (levelPrompt2.activeSelf)
            {
                levelPrompt2.SetActive(false);
            }
        }

        if (levelNumber == 3)
        {
            if (!levelPrompt3.activeSelf)
            {
                levelPrompt3.SetActive(true);
                levelNameText.text = "PLAY ?";
            }

            else if (levelPrompt3.activeSelf)
            {
                levelPrompt3.SetActive(false);
            }
        }
    }

    public void ChangeName()
    {
        playerData.playerName = playerNameText.text;
    }

    public IEnumerator StartRace(int level)
    {
        fadeAnim.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
