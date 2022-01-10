using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 movement;
    private float screenWidth;

    public float speed;
    public SpriteRenderer backgroundSprite;
    public Transform background;

    private void Awake()
    {
        screenWidth = (backgroundSprite.sprite.bounds.size.x * background.localScale.x)/2;
    }

    void Update()
    {
        //check that player doesn't go off screen   
        if (transform.position.x > -screenWidth && transform.position.x < screenWidth)
        {
            Move();
        }
        //if too far left only allow right input
        else if (transform.position.x < -screenWidth && Input.GetAxis("Mouse X") > 0)
        {
            Move();
        }
        //if too far right only allow left input
        else if (transform.position.x > screenWidth && Input.GetAxis("Mouse X") < 0)
        {
            Move();
        }

    }

    private void Move()
    {
        movement = new Vector2(Input.GetAxisRaw("Mouse X"), 0);
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
