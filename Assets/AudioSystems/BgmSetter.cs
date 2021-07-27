using UnityEngine;

public class BgmSetter : MonoBehaviour
{
    int v;
    AudioSource output;

    [SerializeField]
    AudioClip[] SongData;

    void Start()
    {
        v = -1;
        output = gameObject.AddComponent<AudioSource>();
    }

    void Update()
    {
        if (!output.isPlaying)
        {
            v++;
            if (SongData.Length == v) v = 0;
            output.clip = SongData[v];
            output.Play();
        }
    }
}
