using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleSea : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject[] mares;
    void Start()
    {
        mares[0].SetActive(true);
        mares[1].SetActive(false);
        mares[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Variables.life == 3)
        {
            mares[0].SetActive(true);
            mares[1].SetActive(false);
            mares[2].SetActive(false);
        }
        else if (Variables.life == 2)
        {
            mares[0].SetActive(false);
            mares[1].SetActive(true);
            mares[2].SetActive(false);
        }
        else
        {
            mares[0].SetActive(false);
            mares[1].SetActive(false);
            mares[2].SetActive(true);
        }
    }
}
