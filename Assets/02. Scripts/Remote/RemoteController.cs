using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.Video;

public class RemoteController : MonoBehaviour
{
    public GameObject videoScreen;

    public Button[] buttonUI;

    public VideoClip[] clips; // ���� ���� �迭
    public int currClipIndex = 0; // ���� ���� Index

    private VideoPlayer videoPlayer;

    //public bool isOn = false;
    public bool isMute = false;

    void Awake()
    {
        videoPlayer = videoScreen.GetComponent<VideoPlayer>();
        videoPlayer.clip = clips[0]; // Default ���� ����
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
        //    isOn = true; // ���� Ƽ�� On
        //}
        //else
        //{
        //    videoScreen.SetActive(false);
        //    isOn = false;
        //}

        // NOT�� Ȱ���ؼ� ���� ���
        //isOn = !isOn;
        //videoScreen.SetActive(isOn);

        // GameObject �Ӽ��� Ȱ���� ���
        videoScreen.SetActive(!videoScreen.activeSelf);
    }

    public void OnMute()
    {
        isMute = !isMute;
        videoScreen.GetComponent<VideoPlayer>().SetDirectAudioMute(0, isMute);

        // ���� ������ Mute �Ӽ��� Ȱ���� ���
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

    public void OnNextChannel() // ������ ��ư
    {
        currClipIndex++;
        if (currClipIndex > clips.Length - 1)
            currClipIndex = 0;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }

    public void OnPrevChannel() // ���� ��ư
    {
        currClipIndex--;
        if (currClipIndex < 0)
            currClipIndex = clips.Length - 1;

        videoPlayer.clip = clips[currClipIndex];
        videoPlayer.Play();
    }
}