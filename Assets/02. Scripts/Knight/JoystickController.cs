using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private KnightController_Joystick knightController;

    [SerializeField] private GameObject backgroundUI;
    [SerializeField] private GameObject handlerUI;

    private Vector2 startPos, currPos;

    void Start()
    {
        backgroundUI.SetActive(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        backgroundUI.SetActive(true);
        backgroundUI.transform.position = eventData.position;
        startPos = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // 조이스틱 구현
        currPos = eventData.position;
        Vector2 dragDir = currPos - startPos;

        float maxDist = Mathf.Min(dragDir.magnitude, 75f);
        handlerUI.transform.position = startPos + dragDir.normalized * maxDist;

        // 조이스틱 값 플레이어 컨트롤러에 전달
        knightController.InputJoystick(dragDir.x, dragDir.y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        knightController.InputJoystick(0, 0);
        handlerUI.transform.localPosition = Vector2.zero; // 핸들러의 위치가 이상한 걸 잡음
        backgroundUI?.SetActive(false);
    }
}