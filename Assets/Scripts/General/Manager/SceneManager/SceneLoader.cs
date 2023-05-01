using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] 
    private SceneReference _sceneToLoad;

    [SerializeField] private bool PreservePreviousBGM;

    public void LoadScene()
    {
        if (PreservePreviousBGM)
        {
            DontDestroyOnLoad(GameObject.FindWithTag("Music"));
        }
        else
        {
            SceneManager.MoveGameObjectToScene(GameObject.FindWithTag("Music"), SceneManager.GetActiveScene());
        }
        SceneManager.LoadScene(_sceneToLoad);
    }

    public void LoadSceneNoPreserveBGM()
    {
        BGM.PreservePrevious = false;
        PreservePreviousBGM = false;
        LoadScene();
    }

    public void LoadScenePreserveBGM()
    {
        BGM.PreservePrevious = true;
        PreservePreviousBGM = true;
        LoadScene();
    }
}
