using UnityEngine;

public class DoorEvent2 : MonoBehaviour
{
    private Animator animator;

    // µµ¾î¶ô
    public GameObject doorLockUI;

    public string openKey;
    public string closeKey;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorLockUI.SetActive(true);
            // animator.SetTrigger(openKey);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            doorLockUI.SetActive(false);
            // animator.SetTrigger(closeKey);
        }
    }
}
