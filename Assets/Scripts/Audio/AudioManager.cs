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

    [SerializeField, Header("SEに付けるためのAudiosource")]
    private AudioSource _seAudioSource;
    [SerializeField, Header("BGMに付けるためのAudiosource")]
    private AudioSource _bgmAudioSource;

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
    }
    /// <summary>
    /// 引数に使いたいSEの名前を指定して再生する
    /// </summary>
    /// <param name="name"></param>
    public void SEPlay(string name)
    {
        foreach (SoundClip clip in seList)
        {
            if (clip.Name == name)
            {
                Debug.Log($"{clip.Name}SEを再生中");
                _seAudioSource?.PlayOneShot(clip.Clip);
                break;
            }
        }
    }
    /// <summary>
    /// 引数に使いたいBGMの名前を指定して再生する
    /// </summary>
    /// <param name="name"></param>
    public void BGMPlay(string name)
    {
        foreach (SoundClip clip in bgmList)
        {
            if (clip.Name == name)
            {
                _bgmAudioSource.clip = clip.Clip;
                _bgmAudioSource.loop = true;
                _bgmAudioSource?.Play();
                break;
            }
        }
    }
    public void SEStop()
    {
        _seAudioSource.Stop();
    }
    public void SEPause()
    {
        _seAudioSource.Pause();
    }
    public void BGMStop()
    {
        _bgmAudioSource.Stop();
    }
    public void BGMPause()
    {
        _bgmAudioSource.Pause();
    }
}