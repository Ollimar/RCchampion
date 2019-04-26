using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptGashapon : MonoBehaviour
{

    public GameObject[]     cars;

    public Vector3 carsOriginalPosition;

    public int              newCarID;
    public GameObject       newCar;

    public Text             newCarText;
    public Text             coinsText;
    public GameObject       newCarWindow;
    public GameObject       noMoneyWindow;
    public GameObject       accepCarButton;
    public GameObject       buyCarButton;

    private PlayerDataScript playerData;


    void Awake()
    {
        
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerDataScript>();
        //cars = GameObject.FindGameObjectsWithTag("Player");
        carsOriginalPosition = cars[0].transform.position;

        for(int i=0; i< cars.Length; i++)
        {
            cars[i].SetActive(false);
        }
        buyCarButton.SetActive(true);
        noMoneyWindow.SetActive(false);
        newCarWindow.SetActive(false);
        accepCarButton.SetActive(false);
        coinsText.text = "Coins: " + playerData.money;
    }

    // Update is called once per frame
    void Update()
    {
        if(newCar.activeSelf)
        {
            newCar.transform.Rotate(Vector3.up * 10f * Time.deltaTime);
        }
    }

    public void CloseWindow()
    {
        if(newCarWindow.activeSelf)
        {
            newCarWindow.SetActive(false);
            accepCarButton.SetActive(false);
            newCar.transform.position = carsOriginalPosition;
            newCar.SetActive(false);
            buyCarButton.SetActive(true);
        }
        else if(noMoneyWindow.activeSelf)
        {
            accepCarButton.SetActive(false);
            noMoneyWindow.SetActive(false);
            buyCarButton.SetActive(true);
        }

    }

    public void Buy()
    {
        if(playerData.money >= 1)
        {
            StartCoroutine("BuyCar");
            playerData.money--;
            coinsText.text = "Coins: " + playerData.money;
        }
        else
        {
            buyCarButton.SetActive(false);
            accepCarButton.SetActive(true);
            noMoneyWindow.SetActive(true);
        }
        
    }

    public IEnumerator BuyCar()
    {
        buyCarButton.SetActive(false);
        yield return new WaitForSeconds(1f);
        newCarID = Random.Range(0, cars.Length);
        newCar = cars[newCarID];
        cars[newCarID].SetActive(true);
        yield return new WaitForSeconds(1f);
        newCarWindow.SetActive(true);
        accepCarButton.SetActive(true);
        newCarText.text = "You got "+cars[newCarID].name.ToString()+"!";
        playerData.carsOwned[newCarID] = true;
    }
}
