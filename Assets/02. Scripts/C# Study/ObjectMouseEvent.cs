using UnityEngine;

public class ObjectMouseEvent : MonoBehaviour
{
    void OnMouseEnter()
    {
        Debug.Log("Mouse Enter");
    }

    void OnMouseOver()
    {
        Debug.Log("Mouse Over");
    }

    void OnMouseDown()
    {
        Debug.Log("Mouse Down");
    }

    void OnMouseDrag()
    {
        Debug.Log(Input.mousePosition);
        Debug.Log("Mouse Drag");
    }

    void OnMouseUp()
    {
        Debug.Log("Mouse Up");
    }

    void OnMouseUpAsButton()
    {
        Debug.Log("Mouse UpAsButton");
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse Exit");
    }
}

