using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class InputHandler : MonoBehaviour
{
    private InputAction moveAction;
    private InputAction shiftAction;
    private InputAction shootAction;
    private InputAction meleeAction;
    private Player player;
    public Vector2 movewea;
    void Awake()
    {
        player = GetComponent<Player>();

    }

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shiftAction = InputSystem.actions.FindAction("Shift");
        shootAction = InputSystem.actions.FindAction("Shoot");
        meleeAction = InputSystem.actions.FindAction("Melee");
    }

    void Update()
    {
        movewea = moveAction.ReadValue<Vector2>();
        player.Move(movewea);
        if(movewea == Vector2.zero)
        {
            player.isMoving = false;
        }
        else
        {
            player.isMoving = true;
        }

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
        if (meleeAction.WasPerformedThisFrame() && !player.isMeleeActive && !player.isMoving)
        {
            player.Melee();
        }
        if(meleeAction.WasPerformedThisFrame() && player.isMoving && !player.isMeleeActive)
        {
            player.MeleeDash(movewea);
        }
    }

}
