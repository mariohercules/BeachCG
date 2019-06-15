using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    private GameObject gameMain;
    private GameObject gamePlayerInfo;
    private GameObject gameRanking;

    // Start is called before the first frame update
    void Start()
    {
        gameMain = GameObject.FindGameObjectWithTag("gameMain");
        gamePlayerInfo = GameObject.FindGameObjectWithTag("gamePlayerInfo");
        gameRanking = GameObject.FindGameObjectWithTag("gameRanking");

        if (Variables.first_run)
        {
            gameRanking.SetActive(false);
            gameMain.SetActive(false);
            gamePlayerInfo.SetActive(true);
        }
        else
        {
            gameRanking.SetActive(false);
            gameMain.SetActive(true);
            gamePlayerInfo.SetActive(false);
        }

    }


    public void buttonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }  

    public void saveClick()
    {
        SceneManager.LoadScene(0);
    }

    public void finishGame()
    {
        SceneManager.LoadScene(0);
    }

    public void showRanking()
    {
        Variables.ranking_run = true;

        gameMain.SetActive(false);
        gamePlayerInfo.SetActive(false);
        gameRanking.SetActive(true);

    }

    public void hideRanking()
    {
        Variables.ranking_run = false;

        gameMain.SetActive(true);
        gamePlayerInfo.SetActive(false);
        gameRanking.SetActive(false);

    }

    //void Update()
    //{
    //    if (!Variables.ranking_run)
    //    {
    //        if (Variables.first_run)
    //        {
    //            gameRanking.SetActive(false);
    //            gameMain.SetActive(false);
    //            gamePlayerInfo.SetActive(true);
    //        }
    //        else
    //        {
    //            gameRanking.SetActive(false);
    //            gameMain.SetActive(true);
    //            gamePlayerInfo.SetActive(false);
    //        }
    //    }

    //}

}