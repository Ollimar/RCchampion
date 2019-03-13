using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentItems : MonoBehaviour
{
    public static int money = 0;
    public static int playerLevel = 1;
    public float playerExp = 0f;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
