using Unity.VisualScripting;
using UnityEngine;
using PrimeTween;
using System.Collections.Generic;

public class Bullet : MonoBehaviour
{
    private float timer = 0.7f;
    private Rigidbody2D rb;
    [SerializeField] private Ball ball;
    public BoxCollider2D leftBox;
    public BoxCollider2D middleBox;
    public BoxCollider2D rightBox;
    public List<BoxCollider2D> hitboxes;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        rb.linearVelocity = new Vector2(0,25);
        //Tween.Delay(0.7f,() => {Destroy(gameObject);});
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            Destroy(gameObject);
            timer = 0.7f;
        }
    }

    public void Choque(Collider2D hit, Rigidbody2D rb)
    {
        if(hit == leftBox)
        {
            rb.linearVelocity = new Vector2(-7f,7f);
        }
        else if(hit == rightBox)
        {
            rb.linearVelocity = new Vector2(7f,7f);
        }
        else
        {
            rb.linearVelocity = new Vector2(0,7f);
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }

}
