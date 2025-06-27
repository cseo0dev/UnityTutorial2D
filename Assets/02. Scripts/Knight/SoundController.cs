using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource bgmAudio;
    [SerializeField] private AudioSource eventAudio;

    [SerializeField] private AudioClip[] clips;

    [SerializeField] private Slider bgmVolume;
    [SerializeField] private Toggle bgmMute;

    [SerializeField] private Slider eventVolume;
    [SerializeField] private Toggle eventMute;

    void Awake()
    {
        bgmVolume.value = bgmAudio.volume;
        eventVolume.value = eventAudio.volume;

        bgmMute.isOn = bgmAudio.mute;
        eventMute.isOn = bgmAudio.mute;
    }

    void Start()
    {
        BgmSoundPlay("Town BGM");

        bgmVolume.onValueChanged.AddListener(OnBgmVolumeChanged);
        eventVolume.onValueChanged.AddListener(OnEventVolumeChanged);

        bgmMute.onValueChanged.AddListener(OnBgmMute);
        eventMute.onValueChanged.AddListener(OnEventMute);
    }

    // 음악
    public void BgmSoundPlay(string clipName)
    {
        foreach (var clip in clips)
        {
            if (clip.name == clipName)
            {
                bgmAudio.clip = clip;
                bgmAudio.Play();
                return; // 메서드 종료
            }
        }
        Debug.Log($"{clipName} 파일을 찾지 못하였습니다.");
    }

    // 효과음
    public void EventSoundPlay(string clipName)
    {
        foreach (var clip in clips)
        {
            if (clip.name == clipName)
            {
                // PlayOneShot은 한번 실행되면 제어 불가능
                eventAudio.PlayOneShot(clip);
                return; // 메서드 종료
            }
        }
        Debug.Log($"{clipName} 파일을 찾지 못하였습니다.");
    }

    public void OnBgmVolumeChanged(float volume)
    {
        bgmAudio.volume = volume;
    }
    
    public void OnEventVolumeChanged(float volume)
    {
        eventAudio.volume = volume;
    }
    
    public void OnBgmMute(bool isMute)
    {
        bgmAudio.mute = isMute;
    }

    public void OnEventMute(bool isMute)
    {
        eventAudio.mute = isMute;
    }
}