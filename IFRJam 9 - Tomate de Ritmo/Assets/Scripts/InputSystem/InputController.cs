using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private PlayerInput playerInput;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (playerInput.actions["LeftClick"].WasPressedThisFrame())
        {
            Debug.Log("Left Click");
        }
        if (playerInput.actions["RightClick"].WasPressedThisFrame())
        {
            Debug.Log("Right Click");
        }

    }
}
