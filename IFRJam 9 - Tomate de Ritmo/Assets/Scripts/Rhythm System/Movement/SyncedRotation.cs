using UnityEngine;
using static UnityEditor.PlayerSettings;

public class SyncedRotation : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, Mathf.Lerp(0, 360, Conductor.Instance.LoopPositionInAnalog));
    }
}
