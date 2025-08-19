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
                Debug.Log($"{clip.Name}BGMを再生中");
                AudioSource.clip = clip.Clip;
                AudioSource.loop = true;
                AudioSource?.Play();
                break;
            }
        }
    }
    public void StopAudio(AudioSource audioSource)
    {
        Debug.Log($"音源の再生を終了");
        audioSource?.Stop();
    }
    public void PauseAudio(AudioSource audioSource)
    {
        Debug.Log("一時停止");
        audioSource?.Pause();
    }
    public void ReStartAudio(AudioSource audioSource)
    {
        Debug.Log("再開");
        audioSource?.UnPause();
    }
}