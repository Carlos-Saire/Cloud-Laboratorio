using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneController : MonoBehaviour
{
    private void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    private void OnEnable()
    {

        ButtonLoadScene.EventLoadScene += LoadScene;
    }
    private void OnDisable()
    {
        ButtonLoadScene.EventLoadScene -= LoadScene;
    }
    public  void ExitApplicaion()
    {
        Application.Quit();
    }
}
