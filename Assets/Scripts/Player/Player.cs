using System;
using UnityEngine;
using UnityEngine.InputSystem;
using PrimeTween;
using System.Runtime.CompilerServices;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 movement;
    public bool isMoving = false;
    public bool isShifting = false;
    public bool canMove = true;
    public bool isMeleeActive = false;
    [SerializeField] private GameObject hurtbox;
    [SerializeField] public Shooter shooter;
    [SerializeField] private Melee melee;
    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] private float dashSpeed;
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
       if(canMove) movement = vector;
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
        canMove = false;
        Tween.Delay(0.6f, () => {melee.gameObject.SetActive(false);isMeleeActive = false; canMove = true;});
    }

    public void MeleeDash(Vector2 direction)
    {
        melee.gameObject.SetActive(true);
        isMeleeActive = true;
        rb.linearVelocity = direction * dashSpeed;
        canMove = false;
        Tween.Delay(0.6f, () => {melee.gameObject.SetActive(false);isMeleeActive = false; canMove = true;});
    }
}


