using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Cat
{
    public class UIManager : MonoBehaviour
    {
        public GameObject playObj;
        public GameObject introUI;

        public TMP_InputField inputField;
        public TextMeshProUGUI nameTextUI;

        public Button startButton;

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
                playObj.SetActive(true);
                introUI.SetActive(false);

                // startButton.interactable = true;
                Debug.Log($"{nameTextUI.text} �Է�");
                nameTextUI.text = inputField.text;
            }
        }
    }
}
