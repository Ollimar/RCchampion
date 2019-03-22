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

    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("GameManager").GetComponent<MyGameManager>().currentTrack = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
