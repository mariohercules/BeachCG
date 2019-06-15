using UnityEngine;
using System.Collections;

public class NewMonoBehaviour : MonoBehaviour
{

    public AudioSource garbage;

    // Use this for initialization
    void Start()
    {
        garbage = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "boat")
        {
            garbage.Play();
            Destroy(collision.gameObject);
        }
    }
}
