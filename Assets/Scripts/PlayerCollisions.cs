using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
    public int maxHits = 3;
    private int currentHits = 0;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("FallingObject"))
        {
            currentHits++;
            if (currentHits >= maxHits)
            {
                SceneManager.LoadScene("SampleScene");
                
            }
        }
    }
}

