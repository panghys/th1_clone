using System;
using UnityEngine;
using UnityEngine.InputSystem;
using PrimeTween;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private GameObject hurtbox;
    [SerializeField] public Shooter shooter;
    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] public bool isShifting = false;
    [SerializeField] private Melee melee;
    public bool isMeleeActive = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(!isShifting) movementSpeed = 8f;
        hurtbox.gameObject.GetComponent<SpriteRenderer>().enabled = false;
    }
    void FixedUpdate()
    {
        rb.linearVelocity = movement * movementSpeed;
    }
    public void Move(Vector2 vector)
    {
        movement = vector;
    }
    public void Shift()
    {
        movementSpeed = 3f;
        hurtbox.gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }
    public void Shoot()
    {
        shooter.ShootBullet();
    }

    public void Melee()
    {
        melee.gameObject.SetActive(true);
        isMeleeActive = true;
        Tween.Delay(0.6f, () => {melee.gameObject.SetActive(false);isMeleeActive = false;});
    }
}


