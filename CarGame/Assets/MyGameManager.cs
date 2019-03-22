using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
    private CarScript racer;

    public GameObject currentTrack;

    public int lap = 0;

    public bool[] checkPoints;

    public bool countDownOn = false;
    public float startCountDown = 3f;
    public float timer;
    public int seconds;
    public int minutes;

    public float currentLapTime;
    public float[] lapTime;

    public bool raceOn = false;
    public bool resultsOn = true;
    public bool levelChangeOn = false;

    // variables for UI Elements
    public Text startCountDownText;
    public Text raceTimeText;
    public Text lapNumberText;
    public GameObject finishPanel;
    public GameObject playerDataPanel;
    public GameObject playerLevelUpText;
    public Text playerLVLDataPanel;
    public Text playerNameText;
    public Text lap1TimeText;
    public Text lap2TimeText;
    public Text lap3TimeText;
    public GameObject playerExpMeter;
    public GameObject[] stars;

    // Player Data that persists between scenes
    public PlayerDataScript playerData;

    // Track specific data for records
    public Trackdata trackDataScript;

    // Start is called before the first frame update
    void Start()
    {       
        timer                   = 0f;
        raceTimeText            = GameObject.Find("LapTimeText").GetComponent<Text>();
        lapNumberText           = GameObject.Find("LapText").GetComponent<Text>();
        racer                   = GameObject.Find("Player1").GetComponent<CarScript>();
        finishPanel             = GameObject.Find("FinishPanel");
        lap1TimeText            = GameObject.Find("Lap1TimeText").GetComponent<Text>();
        lap2TimeText            = GameObject.Find("Lap2TimeText").GetComponent<Text>();
        lap3TimeText            = GameObject.Find("Lap3TimeText").GetComponent<Text>();
        playerExpMeter          = GameObject.Find("PlayerExpMeter");
        playerLevelUpText       = GameObject.Find("TextLevelUp");
        playerDataPanel         = GameObject.Find("PlayerDataUpdatePanel");
        

        for (int i = 0; i<stars.Length;i++)
        {
            stars[i].SetActive(false);
        }

        startCountDown = 3f;
        raceOn = false;
        levelChangeOn = false;


        playerLevelUpText.SetActive(false);
        playerDataPanel.SetActive(false);
        finishPanel.SetActive(false);
        startCountDownText.gameObject.SetActive(false);
        playerExpMeter.SetActive(false);
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerDataScript>();
        playerNameText.text = playerData.playerName;
        StartCoroutine("StartRace");
    }

    // Update is called once per frame
    void Update()
    {
        if(playerExpMeter.activeSelf)
        {
            playerLVLDataPanel.text = "LEVEL: "+playerData.playerLevel.ToString();
            if (playerExpMeter.GetComponent<Image>().fillAmount < playerData.playerExp / 100f)
            {
                playerExpMeter.GetComponent<Image>().fillAmount += 0.5f * Time.deltaTime;
            }

            if (playerExpMeter.GetComponent<Image>().fillAmount >= 1f)
            {
                if(!levelChangeOn)
                {
                    playerLevelUpText.SetActive(true);
                    playerData.playerLevel += 1;
                    playerLVLDataPanel.text = "LEVEL: " + playerData.playerLevel.ToString();
                    levelChangeOn = true;
                }
            }
        }
        else if(!playerExpMeter.activeSelf)
        {
            playerExpMeter.GetComponent<Image>().fillAmount = playerData.playerExp / 100f;
        }

        if(levelChangeOn)
        {
            playerData.playerExp = 0;
            playerExpMeter.GetComponent<Image>().fillAmount = 0f;
        }

        if (countDownOn)
        {
            startCountDown -= Time.deltaTime;
        }

        if(startCountDown>0f)
        {
            startCountDownText.GetComponent<Text>().text = startCountDown.ToString("f0");
        }

        else if (startCountDown <= 0f)
        {
            startCountDownText.GetComponent<Text>().text = "GO!";
            StartCoroutine("CountDownOff");
        }

        if (timer >=59)
        {
            minutes++;
            timer = 0f;
        }

        if(lap > 0 && lap <4)
        {
            //racer.canDrive = true;
            lapNumberText.GetComponent<Text>().text = lap.ToString() + "/3";
        }

        else if(lap >= 3)
        {
            raceOn = false;
        }

        raceTimeText.GetComponent<Text>().text = timer.ToString("f2");
        
        if (raceOn)
        {
            timer += Time.deltaTime;
            currentLapTime += Time.deltaTime;
        }

        else if(raceOn == false && lap >3 && resultsOn)
        {
            finishPanel.SetActive(true);

            lap1TimeText.GetComponent<Text>().text = "LAP1: "+ lapTime[0].ToString();
            lap2TimeText.GetComponent<Text>().text = "LAP2: "+ lapTime[1].ToString();
            lap3TimeText.GetComponent<Text>().text = "LAP3: "+ lapTime[2].ToString();

            if(timer < currentTrack.GetComponent<Trackdata>().star3Time)
            {
                StartCoroutine("StarGet3");
            }

            else if (timer < currentTrack.GetComponent<Trackdata>().star2Time)
            {
                StartCoroutine("StarGet2");
            }

            else if (timer < currentTrack.GetComponent<Trackdata>().star1Time)
            {
                StartCoroutine("StarGet1");
            }

            if(SceneManager.GetActiveScene() != SceneManager.GetSceneByName("MenuLevel"))
            {
                if (timer < trackDataScript.totalRecord)
                {
                    currentTrack.GetComponent<Trackdata>().NewRecord(timer);
                }
            }

        }
    }

    public void CloseResults()
    {
        resultsOn = false;
        finishPanel.SetActive(false);
        StartCoroutine("ActivatePlayerData");
    }

    public void Retry()
    {
        if (playerExpMeter.GetComponent<Image>().fillAmount >= 1f)
        {
            playerExpMeter.GetComponent<Image>().fillAmount = 0f;
            //playerData.playerExp = 0f;
        }
        SceneManager.LoadScene("TestLevel");
    }

    public void Quit()
    {
        if (playerExpMeter.GetComponent<Image>().fillAmount >= 1f)
        {
            playerExpMeter.GetComponent<Image>().fillAmount = 0f;
            //playerData.playerExp = 0f;
        }
        SceneManager.LoadScene("MenuLevel");
    }

    public IEnumerator CountDownOff()
    {
        yield return new WaitForSeconds(1f);
        startCountDownText.gameObject.SetActive(false);
        raceOn = true;
    }

    public IEnumerator ActivatePlayerData()
    {
        if(!playerDataPanel.gameObject.activeSelf)
        {
            yield return new WaitForSeconds(1f);
            playerDataPanel.gameObject.SetActive(true);
            playerExpMeter.SetActive(true);
            yield return new WaitForSeconds(1.5f);

            if(timer < currentTrack.GetComponent<Trackdata>().star3Time)
            {
                playerData.playerExp += 30f-playerData.playerLevel*0.05f;
            }

            else if (timer < currentTrack.GetComponent<Trackdata>().star2Time)
            {
                playerData.playerExp += 20f - playerData.playerLevel * 0.05f;
            }

            else if (timer < currentTrack.GetComponent<Trackdata>().star1Time)
            {
                playerData.playerExp += 10f - playerData.playerLevel * 0.05f;
            }
        }
    }

    public IEnumerator StartRace()
    {
        yield return new WaitForSeconds(2f);
        startCountDownText.gameObject.SetActive(true);
        countDownOn = true;
    }

    public IEnumerator StarGet1()
    {
        yield return new WaitForSeconds(1f);
        stars[0].SetActive(true);
    }

    public IEnumerator StarGet2()
    {
        yield return new WaitForSeconds(0.3f);
        stars[0].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        stars[1].SetActive(true);
    }

    public IEnumerator StarGet3()
    {
        yield return new WaitForSeconds(0.3f);
        stars[0].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        stars[1].SetActive(true);
        yield return new WaitForSeconds(0.3f);
        stars[2].SetActive(true);
    }
}
