using UnityEngine;

// ���� �����̽� ����
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

        // �ν����ͻӸ� �ƴ϶� ��ũ��Ʈ�� ���ؼ��� ����� ���� ����
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
            // PlayOneShot = �ѹ��� ����
            audioSource.PlayOneShot(jumpClip);
        }
    }
}
