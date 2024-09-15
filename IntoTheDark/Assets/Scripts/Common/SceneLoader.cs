using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Title,
    InGame,
    MAX
}

public class SceneLoader : SingletonBehaviour<SceneLoader>
{
    public void SceneLoadSync(SceneType _sceneType)
    {
        Logger.Instance.Log($"Load Scene: {_sceneType}");

        Time.timeScale = 1f;
        SceneManager.LoadScene((int)_sceneType);
    }

    public void ReloadScene()
    {
        Logger.Instance.Log($"Reloading Scene: {SceneManager.GetActiveScene().name}");

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public AsyncOperation SceneLoadAsync(SceneType _sceneType)
    {
        Logger.Instance.Log($"LoadAsync Scene: {_sceneType}");

        return SceneManager.LoadSceneAsync((int)_sceneType);
    }
}
