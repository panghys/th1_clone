using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    private CharacterController characterController;
    private InputAction moveAction;
    private InputAction shiftAction;
    private InputAction shootAction;
    private Player player;
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
        player = GetComponent<Player>();

    }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shiftAction = InputSystem.actions.FindAction("Shift");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    void Update()
    {
        Vector2 movewea = moveAction.ReadValue<Vector2>();
        player.Move(movewea);
        if (shiftAction.IsPressed())
        {
            player.isShifting = true;
            player.Shift();
        }
        else
        {
            player.isShifting = false;
        }
        if (shootAction.IsPressed() && player.shooter.canBeShot)
        {
            player.Shoot();
        }
    }

}
