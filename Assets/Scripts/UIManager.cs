using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PubNubAPI;

public class UIManager : MonoBehaviour
{
    
    public Image[] images;
    
    public Text points;

    private GameObject gameOverText;

    private BasicMovement basicMovement;

    public static PubNub pubnub;

    void Start()
    {
        gameOverText = GameObject.FindGameObjectWithTag("gameOverText");
        gameOverText.SetActive(false);
        basicMovement = GameObject.FindGameObjectWithTag("boat").GetComponent<BasicMovement>();

    }

    public void UpdateLife()
    {
        if(Variables.life >= 0 && Variables.life < 3)
        {
            images[Variables.life].enabled = false;
        }
        if(Variables.life < 0)
        {
            Variables.stop = true;
            gameOverText.SetActive(true);
            basicMovement.enabled = false;
            CriarRanking();
            GameObject[] trashes = GameObject.FindGameObjectsWithTag("trash");
            for(int i=0; i < trashes.Length; i++)
            {
                Destroy(trashes[i]);
            }

        }

    }
     

    public void GetMoreLife()
    { 
        if (Variables.life < 3 && Variables.life > -1)
        {
            images[Variables.life].enabled = true;
            Variables.life += 1;
        }

    }
     
    public void AddPoint()
    {
        Variables.points += 1;
        points.text = "" + Variables.points;
        basicMovement.PlaySound();
    }


    void CriarRanking()
    {
        //var usernametext = FieldUsername.text;
        //var scoretext = FieldScore.text;

        MyClass myObject = new MyClass();
        myObject.username = Variables.player_name;
        myObject.score = Variables.points.ToString();
        string json = JsonUtility.ToJson(myObject);

        // Use this for initialization
        PNConfiguration pnConfiguration = new PNConfiguration();
        pnConfiguration.PublishKey = "pub-c-552fdd0f-5c19-4557-baa4-1f8c2263b4ed";
        pnConfiguration.SubscribeKey = "sub-c-b55b4074-8312-11e9-84b9-2e401b25e788";

        pnConfiguration.LogVerbosity = PNLogVerbosity.BODY;
        pnConfiguration.UUID = Random.Range(0f, 999999f).ToString();

        pubnub = new PubNub(pnConfiguration);

        pubnub.Publish()
            .Channel("beach_cg_channel")
            .Message(json)
            .Async((result, status) => {
                if (!status.Error)
                {
                    Debug.Log(string.Format("Publish Timetoken: {0}", result.Timetoken));
                }
                else
                {
                    Debug.Log(status.Error);
                    Debug.Log(status.ErrorData.Info);
                }
            });
        //Output this to console when the Button is clicked
        Debug.Log("You have clicked the button!");
    }

}
