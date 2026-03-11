using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private CharacterController characterController;
    [SerializeField] private float movementSpeed = 8f;
    [SerializeField] public bool isShifting = false;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        if(!isShifting) movementSpeed = 8f;
    }
    public void Move(Vector2 vector)
    {
        Vector2 movement = transform.right * vector.x;
        movement = movement * Time.deltaTime * movementSpeed;
        characterController.Move(movement);
    }
    public void Shift()
    {
        movementSpeed = 3f;
    }
}


