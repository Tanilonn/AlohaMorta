using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private float screenWidth;

    public float speed;
    public SpriteRenderer backgroundSprite;
    private readonly float scale = 1.3f;

    private void Awake()
    {
        var halfCam = Camera.main.orthographicSize * Screen.width / Screen.height;
        screenWidth = (backgroundSprite.sprite.bounds.size.x * scale / 2) - halfCam;
    }

    void Update()
    {
        //check that player doesn't go off screen   
        if (transform.position.x > -screenWidth && transform.position.x < screenWidth)
        {
            Move();
        }
        //if too far left only allow right input
        else if (transform.position.x <= -screenWidth)
        {
            if (Input.GetAxis("Mouse X") > 0)
            {
                Move();
            }
        }
        //if too far right only allow left input
        else if (transform.position.x >= screenWidth)
        {
            if (Input.GetAxis("Mouse X") < 0)
            {
                Move();
            }
        }

    }

    private void Move()
    {
        movement = new Vector2(Input.GetAxisRaw("Mouse X"), 0);
        //only allow movement if it doesn't take you off screen
        if(transform.position.x + movement.x <= screenWidth && transform.position.x + movement.x >= -screenWidth)
        {
            transform.Translate(movement * (Mathf.Abs(Input.GetAxisRaw("Mouse X")) * speed) * Time.deltaTime);
        }
    }
}
