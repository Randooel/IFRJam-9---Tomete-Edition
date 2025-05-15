using System;
using UnityEngine;

public class RhythmVerifier : MonoBehaviour
{
    [SerializeField] private InputController inputController;
    [SerializeField] private Vector2 regularHitOffset;
    [SerializeField] private Vector2 perfectHitOffset;
    private Conductor conductor;
    private VFXController VFXController;

    public event Action OnHit;
    public event Action OnPerfectHit;
    public event Action OnMiss;
    private void Start()
    {
        VFXController = GetComponentInChildren<VFXController>();
        conductor = Conductor.Instance;

        OnHit += VFXController.PlayHitVFX;
        OnPerfectHit += VFXController.PlayHitVFX;
        OnMiss += VFXController.PlayMissVFX;
    }

    private void Update()
    {
        VerifyRhythmAccuracy();
    }

    private void VerifyRhythmAccuracy()
    {
        
    }

    private void OnDisable()
    {
        OnHit -= VFXController.PlayHitVFX;
        OnPerfectHit -= VFXController.PlayHitVFX;
        OnMiss -= VFXController.PlayMissVFX;
    }
}
