using UnityEngine;

public class ProximoNivel : MonoBehaviour
{
    public string proximoNivel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(proximoNivel);
        }
}
}
