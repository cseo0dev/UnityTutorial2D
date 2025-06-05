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
            // 유니티 인스펙터 창에서 넣지 않고 코드로 넣어주는 방법
            startButton.onClick.AddListener(OnStartButton);
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
                playObj.SetActive(true);
                introUI.SetActive(false);

                // startButton.interactable = true;
                Debug.Log($"{nameTextUI.text} 입력");
                nameTextUI.text = inputField.text;
            }
        }
    }
}
