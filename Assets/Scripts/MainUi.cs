using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUi : MonoBehaviour
{

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        Debug.Log("Exit Button Clicked!");
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


}
