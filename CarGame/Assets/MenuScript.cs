using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public GameObject mycarMenu;
    public GameObject myStatsMenu;
    public GameObject levelMenu;
    public GameObject levelPrompt;

    public Text playerName;

    public PlayerDataScript playerData;

    public Animator fadeAnim;

    // Start is called before the first frame update
    void Start()
    {
        mycarMenu.SetActive(false);
        myStatsMenu.SetActive(false);
        levelMenu.SetActive(false);
        levelPrompt.SetActive(false);
        playerData = GameObject.Find("PlayerData").GetComponent<PlayerDataScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void QuickRace(int levelNumber)
    {
        StartCoroutine(StartRace(levelNumber));
    }


    public void Cars()
    {
        if(!mycarMenu.activeSelf)
        {
            mycarMenu.SetActive(true);
        }

        else if (mycarMenu.activeSelf)
        {
            mycarMenu.SetActive(false);
        }
    }

    public void Stats()
    {
        if(!myStatsMenu.activeSelf)
        {
            myStatsMenu.SetActive(true);
        }

        else if (myStatsMenu.activeSelf)
        {
            myStatsMenu.SetActive(false);
        }
    }

    public void Levels()
    {
        if (!levelMenu.activeSelf)
        {
            levelMenu.SetActive(true);
        }

        else if (levelMenu.activeSelf)
        {
            levelMenu.SetActive(false);
        }
    }

    public void OpenLevel()
    {
        if (!levelPrompt.activeSelf)
        {
            levelPrompt.SetActive(true);
        }

        else if (levelPrompt.activeSelf)
        {
            levelPrompt.SetActive(false);
        }
    }

    public void ChangeName()
    {
        playerData.playerName = playerName.text;
    }

    public IEnumerator StartRace(int level)
    {
        fadeAnim.SetTrigger("Fade");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(level);
    }
}
