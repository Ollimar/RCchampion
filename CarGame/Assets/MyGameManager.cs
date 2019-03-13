using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
    private CarScript racer;

    public int lap = 0;

    public bool[] checkPoints;

    public float startCountDown = 3f;
    public float timer;
    public int seconds;
    public int minutes;

    public float currentLapTime;
    public float[] lapTime;

    public bool raceOn = false;
    public bool resultsOn = true;

    // variables for UI Elements
    public Text startCountDownText;
    public Text raceTimeText;
    public Text lapNumberText;
    public GameObject finishPanel;
    public GameObject playerDataPanel;
    public Text lap1TimeText;
    public Text lap2TimeText;
    public Text lap3TimeText;
    public Image playerExpMeter;

    public PersistentItems playerData;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        raceTimeText = GameObject.Find("LapTimeText").GetComponent<Text>();
        lapNumberText = GameObject.Find("LapText").GetComponent<Text>();
        racer = GameObject.Find("Player1").GetComponent<CarScript>();
        finishPanel = GameObject.Find("FinishPanel");
        lap1TimeText = GameObject.Find("Lap1TimeText").GetComponent<Text>();
        lap2TimeText = GameObject.Find("Lap2TimeText").GetComponent<Text>();
        lap3TimeText = GameObject.Find("Lap3TimeText").GetComponent<Text>();
        playerExpMeter = GameObject.Find("PlayerExpMeter").GetComponent<Image>();
        playerDataPanel = GameObject.Find("PlayerDataUpdatePanel");
        playerDataPanel.SetActive(false);
        finishPanel.SetActive(false);
        startCountDown = 3f;
        raceOn = false;
        playerData = GameObject.Find("PlayerData").GetComponent<PersistentItems>();
    }

    // Update is called once per frame
    void Update()
    {

        startCountDown -= Time.deltaTime;

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
        SceneManager.LoadScene("TestLevel");
    }

    public void Quit()
    {
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
            playerData.playerExp += 10f;
            playerExpMeter.fillAmount = playerData.playerExp/100f;
        }

    }
}
