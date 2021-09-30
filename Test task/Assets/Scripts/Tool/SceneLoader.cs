using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public string NameOfScene;

    public SceneLoader(string nameOfScene)
    {
        NameOfScene = nameOfScene;
    }

    public void SceneLoad()
    {
        SceneManager.LoadScene(NameOfScene);
    }
}
