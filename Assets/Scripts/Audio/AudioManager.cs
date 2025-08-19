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
    /// SEの名前と再生に使用するAudioSourceを指定する
    /// </summary>
    /// <param name="name"></param>
    /// <param name="audioSource"></param>
    public void PlaySE(string name, AudioSource audioSource)
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
    /// BGMの名前と再生に使用するAudioSourceを指定する
    /// </summary>
    /// <param name="name"></param>
    /// <param name="AudioSource"></param>
    public void PlayBGM(string name, AudioSource AudioSource)
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
    public void StopSE(AudioSource audioSource)
    {
        Debug.Log($"SEの終了");
        audioSource?.Stop();
    }
    public void PauseSE(AudioSource audioSource)
    {
        audioSource?.Pause();
    }
    public void ReStartSE(AudioSource audioSource)
    {
        audioSource?.UnPause();
    }
    public void StopBGM(AudioSource audioSource)
    {
        audioSource?.Stop();
    }
    public void PauseBGM(AudioSource audioSource)
    {
        audioSource?.Pause();
    }
    public void ReStartBGM(AudioSource audioSource)
    {
        audioSource.UnPause();
    }
}