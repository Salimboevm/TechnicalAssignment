using UnityEngine;

public class Death : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GamePlay.Instance.DecriseNumberOfLives();
        GamePlay.Instance.InitialSetAndStartGame();
    }
}