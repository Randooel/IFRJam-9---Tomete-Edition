using System;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class RhythmVerifier : MonoBehaviour
{
    [SerializeField] private InputController inputController;
    [SerializeField] private Vector2 regularHitOffset;
    [SerializeField] private Vector2 perfectHitOffset;
    private Conductor conductor;
    private VFXController VFXController;
    private bool rhythmLimiter;

    public event Action OnHit;
    public event Action OnPerfectHit;
    public event Action OnMiss;


    int PositionBeatsInClick = 0;

    private void Start()
    {
        VFXController = GetComponentInChildren<VFXController>();
        conductor = Conductor.Instance;

        OnHit += VFXController.PlayBeatVFX;
        OnPerfectHit += VFXController.PlayHitVFX;
        OnMiss += VFXController.PlayMissVFX;

        EnableRhythmLimiter();
    }

    private void Update()
    {
        VerifyRhythmAccuracy();
    }


    private void VerifyRhythmAccuracy()
    {
        if (inputController.LeftClick.WasPressedThisFrame())
        {
            
            if (!TimingAcordingLimit()) return;

            PositionBeatsInClick = PrimaryDecimal(conductor.SongPositionInBeats);
            CheckRegularTiming();
        }
    }

    public void DisableRhythmLimiter()
    {
        rhythmLimiter = false;
    }

    public void EnableRhythmLimiter()
    {
        rhythmLimiter = false;
    }

    private bool TimingAcordingLimit()
    {
        if (!rhythmLimiter) return true;

        if ((int)conductor.SongPositionInBeats % 2 == 0)
        {
            return true;
        }

        else return false;
    }

    private void CheckRegularTiming()
    {
        if (PositionBeatsInClick >= regularHitOffset.x && PositionBeatsInClick <= regularHitOffset.y)
        {
            if (CheckPerfectTiming()) return;
            Debug.LogWarning("Regular Timing!");
            OnHit?.Invoke();
        }
        else
        {
            Debug.LogError("Missed Timing!");
            OnMiss?.Invoke();
        }
    }

    private bool CheckPerfectTiming()
    {
        if (PositionBeatsInClick >= perfectHitOffset.x && PositionBeatsInClick <= perfectHitOffset.y)
        {
            Debug.Log("Perfect Timing!");
            OnPerfectHit?.Invoke();
            return true;
        }
        return false;
    }

    private int PrimaryDecimal(float PositionInBeats)
    {
        string numberString = PositionInBeats.ToString("F10");
        int indexPoint = numberString.IndexOf(',');

        if (indexPoint != -1 && indexPoint + 1 < numberString.Length)
        {
            char primeiroDecimal = numberString[indexPoint + 1];
            return int.Parse(primeiroDecimal.ToString());
        }

        return 0;
    }

    private void OnDisable()
    {
        OnHit -= VFXController.PlayBeatVFX;
        OnPerfectHit -= VFXController.PlayHitVFX;
        OnMiss -= VFXController.PlayMissVFX;
    }
}
