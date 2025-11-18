using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CollectiblesManager : MonoBehaviour
{
    public static CollectiblesManager Instance;
    public TextMeshProUGUI counterText;
    
    public DoorController door;
    
    private int totalCollectibles;
    private int remainingCollectibles;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {
        totalCollectibles = GameObject.FindGameObjectsWithTag("Collectible").Length;
        remainingCollectibles = totalCollectibles;
        UpdateUI();
    }
    
    public void CollectItem()
    {
        remainingCollectibles--;
        UpdateUI();
        
        if (remainingCollectibles <= 0)
        {
            if (door != null)
            {
                door.UnlockDoor();
            }
        }
    }
    
    private void UpdateUI()
    {
        counterText.text = "Items: " + remainingCollectibles;
    }
}