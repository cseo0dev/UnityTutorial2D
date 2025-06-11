using UnityEngine;
using Cat;
using UnityEngine.Video;
using System.Collections;

public class CatController : MonoBehaviour
{
    public SoundManager soundManager;
    public VideoManager videoManager;

    public GameObject gameOverUI;
    public GameObject fadeUI;
    public GameObject playUI;

    private Rigidbody2D catRb;
    private Animator catAnim;

    public float jumpPower = 10f;
    public int jumpCount = 0;
    public float limitPower = 9f;

    void Start()
    {
        catRb = GetComponent<Rigidbody2D>();
        catAnim = GetComponent<Animator>();
    }

    void Update()
    {
        // 점프 횟수 제한
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 10)
        {
            catAnim.SetTrigger("Jump");
            catAnim.SetBool("IsGround", false);

            catRb.AddForceY(jumpPower, ForceMode2D.Impulse);
            jumpCount++;

            soundManager.OnJumpSound();

            // 점프 속도(높이) 제한
            if(catRb.linearVelocityY > limitPower)
                catRb.linearVelocityY = limitPower;
        }

        // 고양이 회전 구현
        var catRotation = transform.eulerAngles;
        catRotation.z = catRb.linearVelocity.y * 5f;
        transform.eulerAngles = catRotation;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Fruit"))
        {
            // 과일을 먹으면 해당 과일은 화면에서 나타나지 않아야 하므로
            other.gameObject.SetActive(false);

            // Fruit의 부모 오브젝트로 접근해서 부모의 다른 자식인 particle에 접근 후 활성화
            other.transform.parent.GetComponent<ItemEvent>().particle.SetActive(true);

            GameManager.score++;

            // 게임 성공
            if (GameManager.score == 5)
            {
                fadeUI.SetActive(true);
                fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.white);

                this.GetComponent<CircleCollider2D>().enabled = false;
                StartCoroutine(EndigRoutine(true));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // 게임 오버 Game Over (Outro)
        if (other.gameObject.CompareTag("Pipe"))
        {
            soundManager.OnColliderSound();
            
            gameOverUI.SetActive(true);
            fadeUI.SetActive(true);
            fadeUI.GetComponent<FadePanel>().OnFade(3f, Color.black);

            this.GetComponent<CircleCollider2D>().enabled = false;
            StartCoroutine(EndigRoutine(false));
        }

        if (other.gameObject.CompareTag("Ground"))
        {
            // 점프 중일 때 계속 점프 애니메이션이 작동되도록
            catAnim.SetBool("IsGround", true);
            jumpCount = 0;
        }
    } 

    IEnumerator EndigRoutine(bool isHappy)
    {
        yield return new WaitForSeconds(3.5f);
        videoManager.VideoPlay(isHappy);

        // bool 값이 true가 될 때까지 대기
        // yield return new WaitUntil(() => videoManager.vPlayer.isPlaying);

        fadeUI.SetActive(false);
        gameOverUI.SetActive(false);
        soundManager.audioSource.mute = true;
    }
}
