using UnityEngine;

public class SyncedAnimation : MonoBehaviour
{
    private Animator animator;
    private AnimatorStateInfo animatorStateInfo;
    private int currentAnimatorState;

    void Start()
    {
        animator = GetComponent<Animator>();
        animatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);

        currentAnimatorState = animatorStateInfo.fullPathHash;
    }

    void Update()
    {
        animator.Play(currentAnimatorState, -1, (Conductor.Instance.LoopPositionInAnalog));
        animator.speed = 0;
    }
}
