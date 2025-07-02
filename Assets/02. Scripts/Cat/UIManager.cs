using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public SoundManager SoundManager;

        public GameObject playObj;
        public GameObject introUI;
        public GameObject playUI;
        public GameObject videoPanel;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;
        public Button reStartButton;

        void Awake()
        {
            playObj.SetActive(false);
            introUI.SetActive(true);
            playUI.SetActive(false);
        }

        void Start()
        {
            // 유니티 인스펙터 창에서 넣지 않고 코드로 넣어주는 방법
            startButton.onClick.AddListener(OnStartButton);
            reStartButton.onClick.AddListener(OnRestartButton);
        }

        public void OnStartButton()
        {
            bool isNoText = inputField.text == "";

            if (isNoText)
            {
                Debug.Log("입력된 텍스트 없음");
                // startButton.interactable = false;
            }
            else
            {
                nameTextUI.text = inputField.text;
                SoundManager.SetBgmSound("Play");

                // GameManager.isPlay = true; // true가 되면 타이머 시작

                //playObj.SetActive(true);
                //playUI.SetActive(true);
                //introUI.SetActive(false);

                introUI.SetActive(false);
                StartCoroutine(PlayStartWithTutorial());
            }
        }

        public GameObject tutorialUI;
        public TutorialTextTyper tutorialTyper;

        IEnumerator PlayStartWithTutorial()
        {
            tutorialUI.SetActive(true);
            yield return StartCoroutine(tutorialTyper.StartTyping());
            tutorialUI.SetActive(false);
            playObj.SetActive(true);
            playUI.SetActive(true);
            GameManager.isPlay = true;
        }


        public void OnRestartButton()
        {
            GameManager.ResetPlayUI();
            playObj.SetActive(true);
            videoPanel.SetActive(false);
        }
    }
}