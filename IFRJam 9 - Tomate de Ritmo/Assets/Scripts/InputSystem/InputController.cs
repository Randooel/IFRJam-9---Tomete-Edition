using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private PlayerInput playerInput;

    public InputAction LeftClick => playerInput.actions["LeftClick"];
    public InputAction RightClick => playerInput.actions["RightClick"];

    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }


}
