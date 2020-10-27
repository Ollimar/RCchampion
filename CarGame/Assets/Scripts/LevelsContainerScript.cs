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

    public Image[] starsLevel1;
    public Image[] starsLevel2;
    public Image[] starsLevel3;

    public PlayerDataScript playerdata;

    // Start is called before the first frame update
    void Start()
    {
        playerdata = GameObject.Find("PlayerData").GetComponent<PlayerDataScript>();
        playerdata.stars = 0;

        playerdata.track1RecordText = track1RecordText;
        track1RecordText.text = "BEST TIME: " + playerdata.track1Record.ToString("f2");
        playerdata.track2RecordText = track2RecordText;
        track2RecordText.text = "BEST TIME: " + playerdata.track2Record.ToString("f2");
        playerdata.track3RecordText = track3RecordText;
        track3RecordText.text = "BEST TIME: " + playerdata.track3Record.ToString("f2");

        for(int i=0; i<starsLevel1.Length; i++)
        {
            starsLevel1[i].GetComponent<Image>().enabled = false;
        }

        for (int i = 0; i < starsLevel2.Length; i++)
        {
            starsLevel2[i].GetComponent<Image>().enabled = false;
        }

        for (int i = 0; i < starsLevel3.Length; i++)
        {
            starsLevel3[i].GetComponent<Image>().enabled = false;
        }

        //Level 1 Stars

        if(playerdata.track1Record < 12f)
        {
            starsLevel1[0].GetComponent<Image>().enabled = true;
            starsLevel1[1].GetComponent<Image>().enabled = true;
            starsLevel1[2].GetComponent<Image>().enabled = true;
            playerdata.stars += 3;
        }
        else if (playerdata.track1Record < 20f)
        {
            starsLevel1[0].GetComponent<Image>().enabled = true;
            starsLevel1[1].GetComponent<Image>().enabled = true;
            playerdata.stars += 2;
        }

        else if (playerdata.track1Record < 25f)
        {
            starsLevel1[0].GetComponent<Image>().enabled = true;
            playerdata.stars += 1;
        }

        //Level 2 Stars

        if (playerdata.track2Record < 20f)
        {
            starsLevel2[0].GetComponent<Image>().enabled = true;
            starsLevel2[1].GetComponent<Image>().enabled = true;
            starsLevel2[2].GetComponent<Image>().enabled = true;
            playerdata.stars += 3;
        }
        else if (playerdata.track2Record < 25f)
        {
            starsLevel2[0].GetComponent<Image>().enabled = true;
            starsLevel2[1].GetComponent<Image>().enabled = true;
            playerdata.stars += 2;
        }

        else if (playerdata.track2Record < 40f)
        {
            starsLevel2[0].GetComponent<Image>().enabled = true;
            playerdata.stars += 1;
        }

        //Level 3 Stars

        if (playerdata.track3Record < 25f)
        {
            starsLevel3[0].GetComponent<Image>().enabled = true;
            starsLevel3[1].GetComponent<Image>().enabled = true;
            starsLevel3[2].GetComponent<Image>().enabled = true;
            playerdata.stars += 3;
        }
        else if (playerdata.track3Record < 35f)
        {
            starsLevel3[0].GetComponent<Image>().enabled = true;
            starsLevel3[1].GetComponent<Image>().enabled = true;
            playerdata.stars += 2;
        }

        else if (playerdata.track3Record < 40f)
        {
            starsLevel3[0].GetComponent<Image>().enabled = true;
            playerdata.stars += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
