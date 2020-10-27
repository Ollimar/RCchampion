using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject logo;
    public GameObject settingsMenu;
    public GameObject mycarMenu;
    public GameObject myStatsMenu;
    public GameObject levelMenu;
    public string[]   levelNames;
    public GameObject levelMenuCloseButton;
    public GameObject carsMenuCloseButton;
    public GameObject levelPrompt1;
    public GameObject levelPrompt2;
    public GameObject levelPrompt3;
    public GameObject levelPrompt4;

    public Image      levelLocked4Image;

    public GameObject[] carSymbols;

    public Text playerNameText;
    public Text levelNameText;
    public Text levelNameText2;
    public Text levelNameText3;
    public bool levelLocked1 = false, levelLocked2 = false, levelLocked3 = false, levelLocked4 = true;
    //public Text playerMoneyText;

    public PlayerDataScript playerData;

    public Animator fadeAnim;

    // Button sounds
    public  AudioSource myAudio;
    public  AudioClip   buttonSound1;
    public  AudioClip   buttonCancel;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        settingsMenu.SetActive(false);
        mycarMenu.SetActive(false);
        levelMenu.SetActive(false);
        levelMenuCloseButton.SetActive(false);
        carsMenuCloseButton.SetActive(false);
        levelPrompt1.SetActive(false);
        levelPrompt2.SetActive(false);
        levelPrompt3.SetActive(false);
        levelPrompt4.SetActive(false);
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerDataScript>();
        //playerMoneyText.text = playerData.money.ToString();
        myStatsMenu.SetActive(false);
        myAudio = GetComponent<AudioSource>();

        if(playerData.stars >= 6)
        {
            levelLocked4 = false;
            levelLocked4Image.gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuickRace(int levelNumber)
    {
        StartCoroutine(StartRace(levelNumber));
    }

    public void Settings()
    {
        if(!settingsMenu.activeSelf && !mycarMenu.activeSelf && !myStatsMenu.activeSelf && !levelMenu.activeSelf)
        {
            myAudio.PlayOneShot(buttonSound1);
            logo.SetActive(false);
            settingsMenu.SetActive(true);
        }

        else if (settingsMenu.activeSelf)
        {
            logo.SetActive(true);
            settingsMenu.SetActive(false);
        }
    }

    public void Cars()
    {
        if(!settingsMenu.activeSelf && !mycarMenu.activeSelf && !myStatsMenu.activeSelf && !levelMenu.activeSelf)
        {
            if(!myStatsMenu.activeSelf && !levelMenu.activeSelf)
            {
                myAudio.PlayOneShot(buttonSound1);
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
        if(!settingsMenu.activeSelf && !mycarMenu.activeSelf && !myStatsMenu.activeSelf && !levelMenu.activeSelf)
        {
            if(!mycarMenu.activeSelf && !levelMenu.activeSelf)
            {
                myAudio.PlayOneShot(buttonSound1);
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
        if (!settingsMenu.activeSelf && !mycarMenu.activeSelf && !myStatsMenu.activeSelf && !levelMenu.activeSelf)
        {
            if(!myStatsMenu.activeSelf && !mycarMenu.activeSelf)
            {
                myAudio.PlayOneShot(buttonSound1);
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
        if(levelNumber == 1 && !levelLocked1 && !levelPrompt2.activeSelf && !levelPrompt3.activeSelf && !levelPrompt4.activeSelf)
        {
            if (!levelPrompt1.activeSelf)
            {
                myAudio.PlayOneShot(buttonSound1);
                levelPrompt1.SetActive(true);
                levelNameText.text = "PLAY "+ levelNames[0]+"?";
            }

            else if (levelPrompt1.activeSelf)
            {
                myAudio.PlayOneShot(buttonCancel);
                levelPrompt1.SetActive(false);
            }
        }

        if (levelNumber == 2 && !levelLocked2 && !levelPrompt1.activeSelf && !levelPrompt3.activeSelf && !levelPrompt4.activeSelf)
        {
            if (!levelPrompt2.activeSelf)
            {
                myAudio.PlayOneShot(buttonSound1);
                levelPrompt2.SetActive(true);
                levelNameText2.text = "PLAY " + levelNames[1] + "?";
            }

            else if (levelPrompt2.activeSelf)
            {
                myAudio.PlayOneShot(buttonCancel);
                levelPrompt2.SetActive(false);
            }
        }

        if (levelNumber == 3 && !levelLocked3 && !levelPrompt1.activeSelf && !levelPrompt2.activeSelf && !levelPrompt4.activeSelf)
        {
            if (!levelPrompt3.activeSelf)
            {
                myAudio.PlayOneShot(buttonSound1);
                levelPrompt3.SetActive(true);
                levelNameText3.text = "PLAY " + levelNames[2] + "?";
            }

            else if (levelPrompt3.activeSelf)
            {
                myAudio.PlayOneShot(buttonCancel);
                levelPrompt3.SetActive(false);
            }
        }

        if (levelNumber == 4 && !levelLocked4 && !levelPrompt1.activeSelf && !levelPrompt2.activeSelf && !levelPrompt3.activeSelf)
        {
            if (!levelPrompt4.activeSelf)
            {
                myAudio.PlayOneShot(buttonSound1);
                levelPrompt4.SetActive(true);
                levelNameText3.text = "PLAY " + levelNames[4] + "?";
            }

            else if (levelPrompt4.activeSelf)
            {
                myAudio.PlayOneShot(buttonCancel);
                levelPrompt4.SetActive(false);
            }
        }
    }

    public void ChangeName()
    {
        playerData.playerName = playerNameText.text;
    }

    public IEnumerator StartRace(int level)
    {
        myAudio.PlayOneShot(buttonSound1);
        fadeAnim.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
