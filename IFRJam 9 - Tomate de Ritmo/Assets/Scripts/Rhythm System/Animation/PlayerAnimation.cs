using UnityEngine;
using DG.Tweening;

public class PlayerMovementBeatSync : MonoBehaviour
{
    private Conductor _conductor;

    [Header("Target")]
    [SerializeField] private Transform target;

    [Header("Movement Settings")]
    [SerializeField] private float moveAmount = 0.5f;
    [SerializeField] private float moveDuration = 0.2f;

    private Vector3 originalPosition;
    private Tween currentTween;
    private int lastBeat = -1;

    void Start()
    {
        _conductor = FindObjectOfType<Conductor>();
        originalPosition = target.position;
    }

    void Update()
    {
        int currentBeat = Mathf.FloorToInt(_conductor.SongPositionInBeats);

        if (currentBeat != lastBeat)
        {
            lastBeat = currentBeat;
            PlayMoveAnimation();
        }
    }

    void PlayMoveAnimation()
    {
        currentTween?.Kill();

        float beatDuration = _conductor.SecondsPerBeat;

        Vector3 targetPosition = originalPosition + Vector3.up * moveAmount;

        currentTween = target.DOMoveY(targetPosition.y, beatDuration / 2f)
                             .SetEase(Ease.OutSine)
                             .OnComplete(() =>
                             {
                                 target.DOMoveY(originalPosition.y, beatDuration / 2f)
                                       .SetEase(Ease.InSine);
                             });
    }
}
