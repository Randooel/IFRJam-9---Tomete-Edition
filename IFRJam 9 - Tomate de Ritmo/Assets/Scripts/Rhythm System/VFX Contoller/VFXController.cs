using UnityEngine;
using UnityEngine.VFX;

public class VFXController : MonoBehaviour
{
    [SerializeField] private GameObject beatVFXPrefab;
    [SerializeField] private GameObject hitVFXPrefab;
    [SerializeField] private GameObject missVFXPrefab;

    private VisualEffect beatVFX;
    private VisualEffect hitVFX;
    private VisualEffect missVFX;

    private void Start()
    {
        beatVFX = beatVFXPrefab.GetComponentInChildren<VisualEffect>();
        hitVFX = hitVFXPrefab.GetComponentInChildren<VisualEffect>();
        missVFX = missVFXPrefab.GetComponentInChildren<VisualEffect>();
    }

    public void PlayBeatVFX()
    {
        beatVFX.Play();
    }

    public void PlayHitVFX()
    {
        hitVFX.Play();
    }

    public void PlayMissVFX()
    {
        missVFX.Play();
    }
}
