using UnityEngine;

// 네임 스페이스 설정
namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip jumpClip;
        public AudioClip bgmClip;

        private void Start()
        {
            SetBgmSound();
        }

        // 인스펙터뿐만 아니라 스크립트를 통해서도 오디오 설정 가능
        public void SetBgmSound()
        {
            audioSource.clip = bgmClip;
            audioSource.playOnAwake = true;
            audioSource.loop = true;
            audioSource.volume = 0.2f;

            audioSource.Play();
        }

        public void OnJumpSound()
        {
            // PlayOneShot = 한번만 실행
            audioSource.PlayOneShot(jumpClip);
        }
    }
}
