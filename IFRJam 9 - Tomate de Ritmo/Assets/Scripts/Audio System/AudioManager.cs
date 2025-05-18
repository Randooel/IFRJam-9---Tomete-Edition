using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioClip mainAudioClip;
    private GameObject audioPrefab;

    private void Awake()
    {
        audioPrefab = new GameObject("Audio Source");
        audioPrefab.AddComponent<AudioSource>();
        audioPrefab.transform.SetParent(transform);
        audioPrefab.SetActive(false);

        //PlayMainAudioClip();
    }
    public void PlayAudio(AudioClip clip, bool loop = false)
    {
        GameObject audioSourcePrefab = ObjectPoolManager.SpawnObject(audioPrefab, Vector3.zero, Quaternion.identity, PoolType.SFX);
        AudioSource audioSource = audioSourcePrefab.GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.loop = loop;
        audioSource.Play();
    }

    public void PlayMainAudioClip()
    {
        PlayAudio(mainAudioClip, true);
    }

    
}
