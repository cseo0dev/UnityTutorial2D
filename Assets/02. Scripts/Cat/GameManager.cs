using TMPro;
using UnityEngine;

namespace Cat
{
    public class GameManager : MonoBehaviour
    {
        public SoundManager soundManager;

        public TextMeshProUGUI playTimeUI;
        public TextMeshProUGUI scoreUI;

        private static float timer;
        public static int score;
        public static bool isPlay;

        void Start()
        {
            soundManager.SetBgmSound("Intro");
        }

        void Update()
        {
            // ���� ���� ������ update�� ����X
            if (!isPlay) return;


            timer += Time.deltaTime;

            playTimeUI.text = string.Format("�÷��� �ð� : {0:F1}��", timer);
            scoreUI.text = $"X {score}";
        }

        public static void ResetPlayUI()
        {
            timer = 0f;
            score = 0;
        }
    }
}