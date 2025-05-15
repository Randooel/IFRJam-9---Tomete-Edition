using UnityEngine;

public class Conductor : MonoBehaviour
{
    [field: SerializeField] public float SongBpm { get; private set; }
    [field: SerializeField] public float BeatsPerLoop { get; private set; }
    public float SecondsPerBeat { get; private set; }
    public float SongPosition { get; private set; }
    public float FirstBeatOffset { get; private set; }
    public float SongPositionInBeats { get; private set; }
    public int CompletedLoops { get; private set; } = 0;
    public float LoopPositionInBeats { get; private set; }
    public float ElapsedSongTime { get; private set; }
    public AudioSource AudioSource { get; private set; }
    public float LoopPositionInAnalog { get; private set; }

    //Conductor instance
    public static Conductor Instance { get; private set; }


    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        AudioSource = GetComponent<AudioSource>();
        SecondsPerBeat = 60f / SongBpm;
        ElapsedSongTime = (float)AudioSettings.dspTime;

        PlaySong();
    }

    void Update()
    {
        SongPosition = (float)(AudioSettings.dspTime - ElapsedSongTime - FirstBeatOffset);

        SongPositionInBeats = SongPosition / SecondsPerBeat;

        if (SongPositionInBeats >= (CompletedLoops + 1) * BeatsPerLoop) CompletedLoops++;

        LoopPositionInBeats = SongPositionInBeats - CompletedLoops * BeatsPerLoop;
        LoopPositionInAnalog = LoopPositionInBeats / BeatsPerLoop;
    }

    public void PlaySong()
    {
        AudioSource.Play();
    }
}
