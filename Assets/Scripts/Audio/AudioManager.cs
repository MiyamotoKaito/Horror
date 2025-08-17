using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [System.Serializable]
    public class SoundClip
    {
        public string Name;
        public AudioClip Clip;
    }

    [SerializeField, Header("SEリスト")]
    private List<SoundClip> seList;

    [SerializeField, Header("BGMリスト")]
    private List<SoundClip> bgmList;

    private AudioSource _audioSourse;

    private void Awake()
    {
        if (!Instance)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        _audioSourse = GetComponent<AudioSource>();
    }
    public void SEPlay(string name)
    {
        foreach (SoundClip clip in seList)
        {
            if (clip.Name == name)
            {
                _audioSourse.PlayOneShot(clip.Clip);
                break;
            }
        }
    }
}
