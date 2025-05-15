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

    void Update()
    {
        if (LeftClick.WasPressedThisFrame())
        {
            Debug.Log("Left Click");
        }
        if (RightClick.WasPressedThisFrame())
        {
            Debug.Log("Right Click");
        }

    }
}
