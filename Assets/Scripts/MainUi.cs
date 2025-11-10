using UnityEditor;
using UnityEngine;

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


}
