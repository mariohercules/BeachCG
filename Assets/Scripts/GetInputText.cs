using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GetInputText : MonoBehaviour
{
 
    public InputField name;
    public string playerName;

    private GameObject gameMain;
    private GameObject gamePlayerInfo;

    public void setget()
    {
        playerName = name.text;
        Variables.player_name = playerName;
        Variables.first_run = false;
    }
}
