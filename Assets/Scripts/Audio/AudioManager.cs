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

    private AudioSource _seAudioSourse;
    private AudioSource _bgmAudioSourse;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }

        _seAudioSourse = GetComponent<AudioSource>();
        _bgmAudioSourse = GetComponent <AudioSource>();
    }
    /// <summary>
    /// SEを再生する
    /// </summary>
    /// <param name="name"></param>
    public void SEPlay(string name)
    {
        foreach (SoundClip clip in seList)
        {
            if (clip.Name == name)
            {
                Debug.Log($"{clip.Name}を再生中");
                _seAudioSourse?.PlayOneShot(clip.Clip);
                break;
            }
        }
    }
    /// <summary>
    /// BGMを再生する
    /// </summary>
    /// <param name="name"></param>
    public void BGMPlay(string name)
    {
        foreach (SoundClip clip in bgmList)
        {
            if (clip.Name == name)
            {
                _bgmAudioSourse?.Play();
                break;
            }
        }
    }
    public void SEStop()
    {
        _seAudioSourse.Stop();
    }
    public void BGMStop()
    {
        _bgmAudioSourse.Stop();
    }
}
