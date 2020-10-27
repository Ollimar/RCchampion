using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDataScript : MonoBehaviour
{
    public static GameObject playerData;

    public int          money = 0;
    public int          newMoney = 0;       // This is a new money amount for making a money add effect tot the money counter after finishing the race
    public int          playerLevel = 1;
    public float        playerExp = 0f;

    public string       playerName;

    public float        track1Record = 60f;
    public float        track2Record = 60f;
    public float        track3Record = 60f;

    // The number of stars player has collected
    public int          stars;

    public Text         track1RecordText;
    public Text         track2RecordText;
    public Text         track3RecordText;

    public bool[]       carsOwned;

    public int          activeCar;

    public float musicVolume = 0.5f;
    public Slider musicVolumeSlider;


    // Start is called before the first frame update
    void Start()
    {
        if(playerData == null)
        {
            DontDestroyOnLoad(gameObject);
            playerData = gameObject;
            if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MenuLevel"))
            {
                track1RecordText = GameObject.Find("TextRecordTimeLevel1").GetComponent<Text>();
                track1RecordText.text = "BEST TIME: " + track1Record.ToString();
                track2RecordText = GameObject.Find("TextRecordTimeLevel2").GetComponent<Text>();
                track2RecordText.text = "BEST TIME: " + track2Record.ToString();
                track3RecordText = GameObject.Find("TextRecordTimeLevel3").GetComponent<Text>();
                track3RecordText.text = "BEST TIME: " + track3Record.ToString();
            }
        }

        else if(playerData != this)
        {
            Destroy(gameObject);
        }
    }

    public void MusicVolume(float musicVolume)
    {
        playerData.GetComponent<AudioSource>().volume = musicVolumeSlider.value;
    }

    // Update is called once per frame
    void Update()
    {
        //print(playerExp);
    }
}
