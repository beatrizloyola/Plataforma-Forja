using UnityEngine;
using UnityEngine.SceneManagement;
public class DoorController : MonoBehaviour
{
    public Color lockedColor = Color.red;
    public Color unlockedColor = Color.green;
    public bool startUnlocked = false;
    private bool isUnlocked = false;
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (startUnlocked || SceneManager.GetActiveScene().buildIndex == 0)
        {
            isUnlocked = true;
            spriteRenderer.color = unlockedColor;
        }
        else
        {
            spriteRenderer.color = lockedColor;
        }
    }
    
    public void UnlockDoor()
    {
        isUnlocked = true;
        spriteRenderer.color = unlockedColor;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isUnlocked)
            {
                int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
                int nextSceneIndex = currentSceneIndex + 1;
                
                if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
                {
                    SceneManager.LoadScene(nextSceneIndex);
                }
            }
        }
    }
}