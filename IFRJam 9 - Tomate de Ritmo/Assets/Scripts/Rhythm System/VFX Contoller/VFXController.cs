using System.Collections;
using UnityEngine;
using UnityEngine.VFX;

public class VFXController : MonoBehaviour
{
    [SerializeField] private GameObject beatVFXPrefab;
    [SerializeField] private GameObject hitVFXPrefab;
    [SerializeField] private GameObject missVFXPrefab;

    [SerializeField] private Transform vfxPosition;

    //private VisualEffect beatVFX;
    //private VisualEffect hitVFX;
    //private VisualEffect missVFX;

    private void Awake()
    {
        //beatVFX = Instantiate(beatVFXPrefab).GetComponentInChildren<VisualEffect>();
        //hitVFX  = Instantiate(hitVFXPrefab).GetComponentInChildren<VisualEffect>();
        //missVFX = Instantiate(missVFXPrefab).GetComponentInChildren<VisualEffect>();
    }

    public void PlayBeatVFX()
    {
        GameObject beatVFX = ObjectPoolManager.SpawnObject(beatVFXPrefab, vfxPosition.position, Quaternion.identity, PoolType.VFX);
        beatVFX.GetComponentInChildren<VisualEffect>().Play();
        StartCoroutine(ReleaseCoroutine(beatVFX));
    }

    public void PlayHitVFX()
    {
        GameObject hitVFX = ObjectPoolManager.SpawnObject(hitVFXPrefab, vfxPosition.position, Quaternion.identity, PoolType.VFX);
        hitVFX.GetComponentInChildren<VisualEffect>().Play();
        StartCoroutine(ReleaseCoroutine(hitVFX));
    }

    public void PlayMissVFX()
    {
        GameObject missVFX = ObjectPoolManager.SpawnObject(missVFXPrefab, vfxPosition.position, Quaternion.identity, PoolType.VFX);
        missVFX.GetComponentInChildren<VisualEffect>().Play();
        StartCoroutine(ReleaseCoroutine(missVFX));
    }

    private IEnumerator ReleaseCoroutine(GameObject VFX)
    {
        yield return new WaitForSeconds(0.6f);
        ObjectPoolManager.ReturnObjectToPool(VFX, PoolType.VFX);
    }
}
