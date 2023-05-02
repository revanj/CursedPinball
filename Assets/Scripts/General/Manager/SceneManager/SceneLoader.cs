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
            BGM.PreservePrevious = true;
            GameObject.FindWithTag("Music").transform.parent = null;
            DontDestroyOnLoad(GameObject.FindWithTag("Music"));
        }
        else
        {
            BGM.PreservePrevious = false;
            GameObject.FindWithTag("Music").transform.parent = null;
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
