using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicRoot : MonoBehaviour
{
    private static MusicRoot _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
        
        AudioSource source = GetComponent<AudioSource>();
        
        if (!source.isPlaying && source.clip != null)
            source.Play();
    }
}
