using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    
    public Image[] images;
    
    public Text points;

    void Start()
    {
       //images = GameObject.Find("Canvas")
    }

    public void UpdateLife()
    {
        if(Variables.life >= 0 && Variables.life < 3)
        {
            images[Variables.life].enabled = false;
        }
        if(Variables.life < 0)
        {
            GenerateTrash.stop = true;
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
    }


}
