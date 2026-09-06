using UnityEngine;

public class fireball : MonoBehaviour
{
    public float speed = 8f;
    public float lifeTime = 3f;

    private Vector3 direction = Vector3.right;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    public void Launch(Vector3 newDirection)
    {
        direction = newDirection.normalized;

        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = direction.x < 0;
        }
    }

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}