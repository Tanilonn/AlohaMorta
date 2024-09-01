using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    private float width;
    private SpriteRenderer spriteRenderer;
    public Transform target;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        width = spriteRenderer.sprite.bounds.size.x * transform.localScale.x;
        if(transform.position.x == 0) 
        {
            Instantiate(this, new Vector2(transform.position.x + width, transform.position.y), Quaternion.identity, transform.parent);
        }
    }

    private void Update()
    {
        //if the player can't see this background anymore, so if the distance is bigger than the width
        if (target.position.x - transform.position.x > width)
        {
            LoopForward();
        }

        if (target.position.x - transform.position.x < -width)
        {
            LoopBackwards();
        }
    }

    private void LoopForward()
    {
        Vector2 toFront = new Vector2(width * 2f, 0);

        transform.position = (Vector2)transform.position + toFront;
    }

    private void LoopBackwards()
    {
        Vector2 toBack = new Vector2(width * -2f, 0);

        transform.position = (Vector2)transform.position + toBack;
    }
}