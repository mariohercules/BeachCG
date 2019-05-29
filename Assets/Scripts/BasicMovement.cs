using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public float maxSpeed = 3.5f;
    public float rootSpeed = 180f;
    // public float speed;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Quaternion rot = transform.rotation;
        float z = rot.eulerAngles.z;
        z -= Input.GetAxis("Horizontal") * rootSpeed * Time.deltaTime;
        rot = Quaternion.Euler(0, 0, z);
        transform.rotation = rot;


        Vector3 pos = transform.position;

        Vector3 velocity = new Vector3(0, Input.GetAxis("Vertical") * maxSpeed * Time.deltaTime, 0);

        pos += rot * velocity;

        transform.position = pos;
        //transform.Translate(-Input.GetAxis("Horizontal")* speed, 0, 0);
        //transform.Translate(0, Input.GetAxis("Vertical") * speed, 0);

        Vector3 position = transform.position;
        position.x = Mathf.Clamp(position.x, -21, 21);
        position.y = Mathf.Clamp(position.y, -12, 12);
        transform.position = position;
    }
}
