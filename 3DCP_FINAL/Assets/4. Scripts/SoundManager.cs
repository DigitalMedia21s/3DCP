using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AudioClips
{
    public string name; //이름
    public AudioClip clip; // 오디오 클립
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    [SerializeField] AudioSource[] audioSources = new AudioSource[System.Enum.GetValues(typeof(SoundType)).Length]; // 사운드의 종류만큼 AudioSources를 가짐
    [SerializeField] private List<AudioClips> BgmClip; // BGM
    [SerializeField] private List<AudioClips> EffectClip; // 효과음

    public void Awake()
    {
        // BGM loop 설정
        audioSources[(int)SoundType.BGM].loop = true;
        instance = this;
    }

    public void Clear() 
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
    }

    public AudioClip GetAudioClip(string name, SoundType type = SoundType.EFFECT)
    {
        List<AudioClips> currentClipList = null;

        // SoundType 확인해서 오디오클립 리스트 선택
        if (type == SoundType.BGM)
        {
            currentClipList = BgmClip;
        }
        else if (type == SoundType.EFFECT)
        {
            currentClipList = EffectClip;
        }
        else
        {
            Debug.LogWarning("오디오클립 선택 오류!!!");
        }

        AudioClip currentClip = currentClipList.Find(x => x.name.Equals(name)).clip; 
        return currentClip;
    }

    public void Play(string name, SoundType type = SoundType.EFFECT, float volume = 0.5f)
    {
        Debug.Log("Play : " + name);
        AudioClip audioClip;
        try
        {
            audioClip = GetAudioClip(name, type);
        }
        catch
        {
            Debug.LogError("can not get audio clip");
            return;
        }

        // BGM
        if (type == SoundType.BGM)
        {
            AudioSource audioSource = audioSources[(int)SoundType.BGM];
            Debug.LogError(audioSource);
            if (audioSource.isPlaying) audioSource.Stop();

            audioSource.volume = volume;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        // Effect
        else if (type == SoundType.EFFECT)
        {
            AudioSource audioSource = audioSources[(int)SoundType.EFFECT];
            audioSource.volume = volume;
            audioSource.PlayOneShot(audioClip);
        }
    }
}
