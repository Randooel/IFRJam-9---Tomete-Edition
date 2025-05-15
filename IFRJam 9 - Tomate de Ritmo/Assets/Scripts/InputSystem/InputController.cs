using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    private PlayerInput playerInput;
<<<<<<< Updated upstream
=======
    public InputAction LeftClick => playerInput.actions["LeftClick"];
    public InputAction RightClick => playerInput.actions["RightClick"];

    [SerializeField] private Conductor conductor;

    [Range(0, 10)] public int minPerfectTime = 2;
    [Range(0, 10)] public int maxPerfectTime = 5;

    int PositionBeatsInClick = 0;
>>>>>>> Stashed changes
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
<<<<<<< Updated upstream
        if (playerInput.actions["LeftClick"].WasPressedThisFrame())
        {
            Debug.Log("Left Click");
        }
        if (playerInput.actions["RightClick"].WasPressedThisFrame())
        {
            Debug.Log("Right Click");
        }
=======
        // if (LeftClick.WasPressedThisFrame())
        // {
        //     // Debug.Log("Left Click");
        //     Debug.Log("Song Position: " + conductor.SongPositionInBeats);
        //     PositionBeatsInClick = PrimaryDecimal(conductor.SongPositionInBeats);
        //     CheckPerfectTiming();
        // }
        // Debug.Log(PositionBeatsInClick);

        // if (RightClick.WasPressedThisFrame())
        // {
        //     Debug.Log("Right Click");
        // }
>>>>>>> Stashed changes

    }

    // private void CheckPerfectTiming()
    // {
    //     if (PositionBeatsInClick >= minPerfectTime && PositionBeatsInClick <= maxPerfectTime)
    //     {
    //         Debug.Log("Perfect Timing!");
    //     }
    // }

    // private int PrimaryDecimal(float PositionInBeats)
    // {
    //     string numberString = PositionInBeats.ToString("F10");
    //     int indexPoint = numberString.IndexOf(',');

    //     if (indexPoint != -1 && indexPoint + 1 < numberString.Length)
    //     {
    //         char primeiroDecimal = numberString[indexPoint + 1];
    //         return int.Parse(primeiroDecimal.ToString());
    //     }
    //     return 0;
    // }

}
