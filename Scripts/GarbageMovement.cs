using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageMovement : MonoBehaviour
{

    private float velocity = 0.1f;
    private float positionX = 0; 
    private float positionY = 0;
    private GameObject gameOverText;


    private Camera mainCamera;

    private UIManager uIManager;

    private string objectName;

    

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
        //this.positionX = transform.position.x;
        //this.positionY = transform.position.y;
        uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        //gameOverText = GameObject.FindGameObjectWithTag("gameOverText");
        //gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        objectName = gameObject.name;

        if(objectName == "recycle_items_0") {
            this.positionX += Variables.dificulty;
        }
        else {
            

            this.positionY -= Variables.dificulty;
        }

        Vector2 directionMovement = new Vector2(this.positionX, this.positionY);
        transform.Translate(directionMovement * velocity * Time.deltaTime);

        
        //Logica de sair da camera
        Vector2 screenPosition = mainCamera.WorldToScreenPoint(transform.position);
        if (screenPosition.y < this.positionY) {
            //Se não for o coração, perde ponto
            if (objectName != "recycle_items_0(Clone)")
            {
                Variables.life -= 1;
                uIManager.UpdateLife();

                if(Variables.life < 0)
                {
                    Variables.stop = true;
                    //gameOverText.SetActive(true);

                }
            }
            Destroy(gameObject);
        }

    }

    void OnCollisionEnter2D(Collision2D collision){



        if (collision.gameObject.tag == "boat")
        {
            if (objectName == "recycle_items_0(Clone)")
            {

                Debug.Log("Life in: " + Variables.life);
                Debug.Log("objectname: " + objectName);



                uIManager.GetMoreLife();

                Destroy(gameObject);
            }

            uIManager.AddPoint();
            if (Variables.points % 5 == 0)
            {
                Variables.dificulty += 0.05f;
            }
            Destroy(gameObject);

             
        }

      
    


    }

    void OnBecameInvisible()
    {
       
    }

}
