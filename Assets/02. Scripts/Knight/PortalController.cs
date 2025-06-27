using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PortalController : MonoBehaviour
{
    public PlatformFade fade;

    public GameObject portalEffect;
    public GameObject loadingImage;

    public Image progressBar;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PortalRoutine());
        }
    }

    IEnumerator PortalRoutine()
    {
        portalEffect.SetActive(true);

        // Fade 코루틴이 끝날 때 까지 대기
        yield return StartCoroutine(fade.Fade(3f, Color.white, true));

        // 씬 변경
        loadingImage.SetActive(true);
        yield return StartCoroutine(fade.Fade(3f, Color.white, false));

        while (progressBar.fillAmount < 1f) // 로딩 페이크
        {
            progressBar.fillAmount += Time.deltaTime * 0.3f;
            yield return null;
        }

        SceneManager.LoadScene(1);
    }
}
