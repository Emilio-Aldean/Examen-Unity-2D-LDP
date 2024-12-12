using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private Transform player;
    private float fallSpeed;
    private float lifetime;

    public void Initialize(Transform playerTarget, float speed, float objectLifetime)
    {
        player = playerTarget;
        fallSpeed = speed;
        lifetime = objectLifetime;
        Destroy(gameObject, lifetime); 
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized; 
        transform.position += new Vector3(direction.x, -1, 0) * fallSpeed * Time.deltaTime; 
    }
}

