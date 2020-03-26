using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 7f;
    public event System.Action OnPlayerDeath;

    float screenHalfWidthInWorldUnits;

    public Rigidbody2D myBody;
    
    // Start is called before the first frame update
    void Start()
    {
        float halfPlayerWidth = (transform.localScale.x / 2f);
        screenHalfWidthInWorldUnits = ((Camera.main.aspect * Camera.main.orthographicSize) + halfPlayerWidth);
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("Horizontal");
        float velocity = inputX * speed;
        transform.Translate(Vector2.right * velocity * Time.deltaTime);

        if (transform.position.x < -screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);//-    stop you from going in the walls
        }
        if (transform.position.x > screenHalfWidthInWorldUnits)
        {
            transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);//+    stop you from going in the walls
        }

    }
    
    public void Move(float horizontalInput)
    {
        Vector2 moveVel = myBody.velocity;
        moveVel.x = horizontalInput * speed;
        myBody.velocity = moveVel;
    }
    
    void OnTriggerEnter2D (Collider2D triggerCollider) // this method is called automatically by the unity 2D-Physics-Engine
    {
        if(triggerCollider.tag == "Falling Block")
        {
            if(OnPlayerDeath != null)
            {
                OnPlayerDeath();
            }
            Destroy(gameObject);
        }
    }

}
