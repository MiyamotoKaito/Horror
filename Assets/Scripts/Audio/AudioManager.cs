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
    public void SEPlay(string name, AudioSource audioSource)
    {
        foreach (SoundClip clip in seList)
        {
            if (clip.Name == name)
            {
                Debug.Log($"{clip.Name}SEを再生中");
                audioSource?.PlayOneShot(clip.Clip);
                break;
            }
        }
    }
    /// <summary>
    /// 引数に使いたいBGMの名前を指定して再生する
    /// </summary>
    /// <param name="name"></param>
    public void BGMPlay(string name, AudioSource AudioSource)
    {
        foreach (SoundClip clip in bgmList)
        {
            if (clip.Name == name)
            {
                Debug.Log($"{clip.Name}を再生中");
                AudioSource.clip = clip.Clip;
                AudioSource.loop = true;
                AudioSource?.Play();
                break;
            }
        }
    }
    public void SEStop(AudioSource audioSource)
    {
        Debug.Log($"SEの終了");
        audioSource?.Stop();
    }
    public void SEPause(AudioSource audioSource)
    {
        audioSource?.Pause();
    }
    public void SEReStart(AudioSource audioSource)
    {
        audioSource?.UnPause();
    }
    public void BGMStop(AudioSource audioSource)
    {
        audioSource?.Stop();
    }
    public void BGMPause(AudioSource audioSource)
    {
        audioSource?.Pause();
    }
    public void BGMReStart(AudioSource audioSource)
    {
        audioSource.UnPause();
    }
}