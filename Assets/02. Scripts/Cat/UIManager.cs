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

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

        void Awake()
        {
            playObj.SetActive(false);
            introUI.SetActive(true);
            playUI.SetActive(false);
        }

        void Start()
        {
            // ����Ƽ �ν����� â���� ���� �ʰ� �ڵ�� �־��ִ� ���
            startButton.onClick.AddListener(OnStartButton);
        }

        public void OnStartButton()
        {
            bool isNoText = inputField.text == "";

            if (isNoText)
            {
                Debug.Log("�Էµ� �ؽ�Ʈ ����");
                // startButton.interactable = false;
            }
            else
            {
                nameTextUI.text = inputField.text;
                SoundManager.SetBgmSound("Play");

                GameManager.isPlay = true; // true�� �Ǹ� Ÿ�̸� ����

                playObj.SetActive(true);
                playUI.SetActive(true);
                introUI.SetActive(false);
            }
        }
    }
}
