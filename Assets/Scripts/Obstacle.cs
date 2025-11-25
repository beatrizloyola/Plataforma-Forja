using UnityEngine;
using UnityEngine.SceneManagement;

public class Obstacle : MonoBehaviour
{

    public float deathAnimationDuration = 0.55f;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            
            if (player != null)
            {
                player.StartDeathAnimation();
                
                Invoke("ReloadLevel", deathAnimationDuration);
            }
        }
    }

    void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}