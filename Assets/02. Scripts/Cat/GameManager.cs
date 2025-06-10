using TMPro;
using UnityEngine;

namespace Cat
{
    public class GameManager : MonoBehaviour
    {
        public SoundManager soundManager;

        public TextMeshProUGUI playTimeUI;
        public TextMeshProUGUI scoreUI;

        private float timer;
        public static int score;
        public static bool isPlay;

        void Start()
        {
            soundManager.SetBgmSound("Intro");
        }

        void Update()
        {
            // 게임 시작 전에는 update문 실행X
            if (!isPlay) return;


            timer += Time.deltaTime;

            playTimeUI.text = string.Format("플레이 시간 : {0:F1}초", timer);
            scoreUI.text = $"X {score}";
        }
    }
}