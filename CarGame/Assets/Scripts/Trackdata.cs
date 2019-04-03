using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trackdata : MonoBehaviour
{
    public int trackNumber;

    public float lap1Record;
    public float lap2Record;
    public float lap3Record;
    public float totalRecord;

    public float star1Time = 5f;
    public float star2Time = 10f;
    public float star3Time = 15f;

    public PlayerDataScript playerData;

    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerDataScript>();
        GameObject.Find("GameManager").GetComponent<MyGameManager>().currentTrack = gameObject;

        switch (trackNumber)
        {
            case 3:
                totalRecord = playerData.track3Record;
                break;
            case 2:
                totalRecord = playerData.track2Record;
                break;
            case 1:
                totalRecord = playerData.track1Record;
                break;
        }
    }

    public void NewRecord(float record)
    {
        switch (trackNumber)
        {
            case 3:
                totalRecord = record;
                playerData.track3Record = totalRecord;
                break;
            case 2:
                totalRecord = record;
                playerData.track2Record = totalRecord;
                break;
            default:
                totalRecord = record;
                playerData.track1Record = totalRecord;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
