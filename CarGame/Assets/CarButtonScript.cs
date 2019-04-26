using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarButtonScript : MonoBehaviour
{
    public bool carLocked = true;
    public int carNumber;

    public Sprite carLockedImage;
    public Sprite carUnlockedImage;

    private PlayerDataScript playerData;

    // Start is called before the first frame update
    void Start()
    {
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerDataScript>();

        if(playerData.carsOwned[carNumber] == true)
        {
            carLocked = false;
        }

        if (!carLocked)
        {
            GetComponent<Image>().sprite = carUnlockedImage;
        }
    }

    public void SetCar()
    {
        if(!carLocked)
        {
            playerData.activeCar = carNumber;
        }

    }

}
