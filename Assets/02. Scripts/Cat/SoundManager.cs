using UnityEngine;

// 네임 스페이스 설정
namespace Cat
{
    public class SoundManager : MonoBehaviour
    {
        public AudioSource audioSource;
        public AudioClip introBgmClip;
        public AudioClip jumpClip;
        public AudioClip bgmClip;
        public AudioClip colliderClip;

        public void SetBgmSound(string bgmName)
        {
            if (bgmName == "Intro")
            {
                audioSource.clip = introBgmClip;
            }
            else if (bgmName == "Play")
            {
                audioSource.clip = bgmClip;
            }

            audioSource.loop = true;
            audioSource.volume = 0.2f;
            audioSource.Play();
        }

        public void OnJumpSound()
        {
            // PlayOneShot = 한번만 실행
            audioSource.PlayOneShot(jumpClip);
        }

        // 충돌 사운드 구현
        public void OnColliderSound()
        {
            audioSource.PlayOneShot(colliderClip);
        }
    }
}
