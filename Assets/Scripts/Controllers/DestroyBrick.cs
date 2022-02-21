using UnityEngine;

public class DestroyBrick : MonoBehaviour
{   
    private void OnCollisionEnter2D(Collision2D other)
    {
        ScoreManager.Instance.AddScore();
        Destroy(gameObject);
    }
}