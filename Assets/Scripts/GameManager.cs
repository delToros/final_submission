using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 1. Static reference to the singleton instance
    // ENCAPSULATION
    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // 2. Check if an instance already exists
        if (Instance != null && Instance != this)
        {
            // Destroy this object if another instance already exists
            Destroy(gameObject);
        }
        else
        {
            // Set this instance as the singleton
            Instance = this;

            // Keep the manager alive between scene loads
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinGame");
    }
}
