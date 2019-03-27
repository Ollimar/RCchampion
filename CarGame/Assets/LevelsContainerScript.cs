using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// This script exists to pass track record texts to Playerdata script

public class LevelsContainerScript : MonoBehaviour
{
    public Text track1RecordText;
    public Text track2RecordText;
    public Text track3RecordText;

    public PlayerDataScript playerdata;

    // Start is called before the first frame update
    void Start()
    {
        playerdata = GameObject.Find("PlayerData").GetComponent<PlayerDataScript>();

        playerdata.track1RecordText = track1RecordText;
        track1RecordText.text = "BEST TIME: " + playerdata.track1Record.ToString("f2");
        playerdata.track2RecordText = track2RecordText;
        track2RecordText.text = "BEST TIME: " + playerdata.track2Record.ToString("f2");
        playerdata.track3RecordText = track3RecordText;
        track3RecordText.text = "BEST TIME: " + playerdata.track3Record.ToString("f2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
