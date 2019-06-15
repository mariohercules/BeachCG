using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void buttonClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void finishGame()
    {
        SceneManager.LoadScene(0);
    }
    // Start is called before the first frame update
    void Start()
    {

    }


}
