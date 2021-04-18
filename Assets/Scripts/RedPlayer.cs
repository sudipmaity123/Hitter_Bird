 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedPlayer : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private Transform MousePosition;

    [SerializeField]
    private float DragSpeed;

    [SerializeField]
    private float maxDragposition = 4.25f;

    [SerializeField]
    private float DelayTime;
    


    private Vector2 Startposition;

    private SpriteRenderer spriteRenderer;



    public bool IsDragging { get; private set; }


    void Awake()
    {
        Startposition = rb.position;

        rb = GetComponent<Rigidbody2D>();
        rb.isKinematic = true;

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        spriteRenderer.color = Color.red;

        IsDragging = true;
    }


    void OnMouseUp()
    {
        Vector2 currentPosition = rb.position;
        Vector2 Direction = Startposition - currentPosition;
        Direction.Normalize();

        rb.isKinematic = false;
        rb.AddForce(Direction * DragSpeed);


        spriteRenderer.color = Color.white;

        IsDragging = false;
    }

    void OnMouseDrag()
    {
        Vector2 MousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 Maxposition = MousePosition;
        float distnace = Vector2.Distance(Maxposition,Startposition);

        if(distnace > maxDragposition)
        {
            Vector2 direction = Maxposition - Startposition;
            direction.Normalize();
            Maxposition = Startposition + (direction * maxDragposition);
        }
        
        if(Maxposition.x > Startposition.x)
        {
            Maxposition.x = Startposition.x;
        }

        transform.position = Maxposition;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetPositionAfterDelay());
    }

    IEnumerator ResetPositionAfterDelay()
    {
        yield return new WaitForSeconds(DelayTime);
        rb.position = Startposition;
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
    }
}
