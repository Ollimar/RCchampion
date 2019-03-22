using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDataScript : MonoBehaviour
{
    public static GameObject playerData;

    public int          money = 0;
    public int          playerLevel = 1;
    public float        playerExp = 0f;

    public string       playerName;

    public float track1Record = 60f;
    public float track2Record = 60f;
    public float track3Record = 60f;

    public Text track1RecordText;
    public Text track2RecordText;
    public Text track3RecordText;

    // Start is called before the first frame update
    void Start()
    {
        if(playerData == null)
        {
            DontDestroyOnLoad(gameObject);
            playerData = gameObject;
            track1RecordText = GameObject.Find("TextRecordTimeLevel1").GetComponent<Text>();
            track1RecordText.text = "BEST TIME: "+track1Record.ToString();
            track2RecordText = GameObject.Find("TextRecordTimeLevel2").GetComponent<Text>();
            track2RecordText.text = "BEST TIME: " + track2Record.ToString();
            track3RecordText = GameObject.Find("TextRecordTimeLevel3").GetComponent<Text>();
            track3RecordText.text = "BEST TIME: " + track3Record.ToString();
        }
        else if(playerData != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //print(playerExp);
    }
}
