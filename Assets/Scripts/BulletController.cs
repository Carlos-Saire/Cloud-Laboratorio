using UnityEngine;

public class BulletController : MonoBehaviour
{

    Rigidbody2D rb2d;
    [SerializeField] private float Speed;
    public float Xdirection;
    AudioSource audioclip;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        audioclip = GetComponent<AudioSource>();
    }
    private void Start()
    {
        audioclip.Play();
    }
    private void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(Speed * Xdirection, 0);
    }
}