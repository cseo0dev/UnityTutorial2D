using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteController : MonoBehaviour
{
    public GameObject videoScreen;

    public Button[] buttonUI;

    public VideoClip[] clips; // 영상 파일 배열
    public int currClipIndex = 0; // 현재 영상 Index

    private VideoPlayer videoPlayer;

    //public bool isOn = false;
    public bool isMute = false;

    void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[0]; // Default 영상 설정
    }

    void Start()
    {
        buttonUI[0].onClick.AddListener(OnScreenPower);
        buttonUI[1].onClick.AddListener(OnMute);
        buttonUI[2].onClick.AddListener(OnPrevChannel);
        buttonUI[3].onClick.AddListener(OnNextChannel);
    }

    public void OnScreenPower()
    {
        //if (!isOn)
        //{
        //    videoScreen.SetActive(true);
        //    isOn = true; // 현재 티비 On
        //}
        //else
        //{
        //    videoScreen.SetActive(false);
        //    isOn = false;
        //}

        // NOT을 활용해서 적은 방법
        //isOn = !isOn;
        //videoScreen.SetActive(isOn);

        // GameObject 속성을 활용한 방법
        videoScreen.SetActive(!videoScreen.activeSelf);
    }

    public void OnMute()
    {
        isMute = !isMute;
        videoScreen.GetComponent<VideoPlayer>().SetDirectAudioMute(0, isMute);

        // 현재 영상의 Mute 속성을 활용한 방법
        videoPlayer.SetDirectAudioMute(0, !videoPlayer.GetDirectAudioMute(0));
    }

    //public void OnChangeChannel(bool isNext)
    //{
    //    int value = isNext ? 1 : -1;
    //    currClipIndex += value;

    //    if (currClipIndex > clips.Length - 1)
    //        currClipIndex = 0;

    //    if (currClipIndex < 0)
    //        currClipIndex = clips.Length - 1;

    //    videoPlayer.clip = clips[currClipIndex];
    //    videoPlayer.Play();
    //}

    public void OnNextChannel() // 오른쪽 버튼
    {
        currClipIndex++;
        if (currClipIndex > clips.Length - 1)
            currClipIndex = 0;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }

    public void OnPrevChannel() // 왼쪽 버튼
    {
        currClipIndex--;
        if (currClipIndex < 0)
            currClipIndex = clips.Length - 1;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }
}