using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public Button restartButton;

    void Start()
    {
        if (restartButton == null)
        {
            restartButton = GetComponent<Button>();
        } else {
            restartButton.onClick.AddListener(RestartFromBeginning);
        }
    }
    public void RestartFromBeginning()
    {
        SceneManager.LoadScene(0);
    }
}