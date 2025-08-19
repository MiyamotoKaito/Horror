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
    public void SEPlay(string name, AudioSource seAudioSource)
    {
        foreach (SoundClip clip in seList)
        {
            if (clip.Name == name)
            {
                Debug.Log($"{clip.Name}SEを再生中");
                seAudioSource?.PlayOneShot(clip.Clip);
                break;
            }
        }
    }
    /// <summary>
    /// 引数に使いたいBGMの名前を指定して再生する
    /// </summary>
    /// <param name="name"></param>
    public void BGMPlay(string name, AudioSource bgmAudioSource)
    {
        foreach (SoundClip clip in bgmList)
        {
            if (clip.Name == name)
            {
                Debug.Log($"{clip.Name}BGMを再生中");
                bgmAudioSource.clip = clip.Clip;
                bgmAudioSource.loop = true;
                bgmAudioSource?.Play();
                break;
            }
        }
    }
    public void SEStop(AudioSource se)
    {
        Debug.Log($"SEの終了");
        se?.Stop();
    }
    public void SEPause(AudioSource se)
    {
        se?.Pause();
    }
    public void SEReStart(AudioSource se)
    {
        se?.UnPause();
    }
    public void BGMStop(AudioSource bgm)
    {
        bgm?.Stop();
    }
    public void BGMPause(AudioSource bgm)
    {
        bgm?.Pause();
    }
    public void BGMReStart(AudioSource bgm)
    {
        bgm.UnPause();
    }
}