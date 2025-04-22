using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerController : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float horizontal;
    [SerializeField] GameObject alma;
    [SerializeField] private float Speed;
    [SerializeField] private float Jump;
    [SerializeField] private int vidas;
    public CamaraControl camara;
    bool confirs;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public Fade fade;
    AudioSource source;
    [Header("Jump")]
    public float jumpForce;
    bool isJump;
    public LayerMask groundLayer; // Capa que representa el suelo

    private bool isGrounded;
    public bool Fixed=true;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();
    }
    private void Start()
    {
        transform.localScale = new Vector2(1 * 0.28f, -1 * 0.28f);
    }
    private void Update()
    {
        Salto();
        Debug.Log(transform.localScale);
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0)
        {
            Debug.Log("Entre");
            animator.SetBool("Run", true);
        }
        else
        {
            animator.SetBool("Run", false);
        }
        if (horizontal < 0)
        {
            transform.localScale = new Vector2(-0.28f, 1);
            spriteRenderer.flipX = true;

        }
        else if (horizontal > 0)
        {
            transform.localScale = new Vector2(0.28f, 1);
            spriteRenderer.flipX = false;

        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            alma.SetActive(true);
            alma.GetComponent<AlmaController>().SalirAlma();
            animator.SetBool("Run", false);
            animator.SetBool("Jump", false);
            animator.SetBool("Idle", true);
            camara.Jugador = alma.gameObject;
            Fixed = false;
            enabled = false;
        }
    }
    private void Salto()
    {
        if (Physics2D.Raycast(transform.position, Vector3.down, 1.03f, groundLayer))
        {
            if (isJump)
            {
                rigidbody2D.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
            }
        }
        isJump = Input.GetButtonDown("Jump");
    }
    private void FixedUpdate()
    {
        if (Fixed == true)
        {
            rigidbody2D.linearVelocity = new Vector2(horizontal * Speed, rigidbody2D.linearVelocity.y);

        }
        else
        {
            rigidbody2D.linearVelocity = new Vector2(0, 0);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy") && vidas >= 0)
        {
            GameManagerController.instante.Vidas[vidas].gameObject.SetActive(false);
            --vidas;
            if (vidas < 0)
            {
                GameManagerController.instante.Vidas[0].gameObject.SetActive(false);
                Fade.onDeath?.Invoke();
                Time.timeScale = 0;
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Limite"))
        {
            Fade.onDeath?.Invoke();
            Time.timeScale = 0;
        }
        if (collision.gameObject.CompareTag("Optener"))
        {
            ++GameManagerController.instante.Bullet;
            Destroy(collision.gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Termino"))
        {
            SceneManager.LoadScene("Final");
        }
    }
}
