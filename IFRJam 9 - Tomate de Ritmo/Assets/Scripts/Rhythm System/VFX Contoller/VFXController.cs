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

    private void Awake()
    {
        beatVFX = Instantiate(beatVFXPrefab).GetComponentInChildren<VisualEffect>();
        hitVFX  = Instantiate(hitVFXPrefab).GetComponentInChildren<VisualEffect>();
        missVFX = Instantiate(missVFXPrefab).GetComponentInChildren<VisualEffect>();
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
