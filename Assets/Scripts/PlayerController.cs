using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public SpriteRenderer spriteRenderer;
    public Sprite idleSprite;
    public Sprite moveRightSprite;
    public Sprite moveLeftSprite;
    public AudioClip moveSound;
    public AudioSource audioSource;

    private Vector2 movement;

    void Update()
    {
        movement = Vector2.zero;

        if (Input.GetKey(KeyCode.D))
        {
            movement.x = 1;
            spriteRenderer.sprite = moveRightSprite;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1;
            spriteRenderer.sprite = moveLeftSprite;
        }
        else
        {
            spriteRenderer.sprite = idleSprite;
        }

        if (movement != Vector2.zero && !audioSource.isPlaying)
        {
            audioSource.clip = moveSound;
            audioSource.Play();
        }
    }

    void FixedUpdate()
    {
        transform.Translate(movement * speed * Time.deltaTime);
    }
}
