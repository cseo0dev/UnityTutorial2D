using UnityEngine;

// ���� �����̽� ����
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
            // PlayOneShot = �ѹ��� ����
            audioSource.PlayOneShot(jumpClip);
        }

        // �浹 ���� ����
        public void OnColliderSound()
        {
            audioSource.PlayOneShot(colliderClip);
        }
    }
}
