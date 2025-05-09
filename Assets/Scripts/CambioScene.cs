using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CambioScene : MonoBehaviour
{
    static float _Timer;
    static bool Comenzar=false;
    static string scene;
    private void Update()
    {
        if (Comenzar == true)
        {
            print(_Timer);
            _Timer -= Time.deltaTime;
            if (_Timer <= 0)
            {
                if (scene != null)
                {
                    SceneManager.LoadScene(scene);
                    Comenzar = false;
                }
            }
        }
    }
    public void LoadScene(string sceneName, float Tiempo)
    {
       _Timer = Tiempo;
        Comenzar = true;
        scene = sceneName;
    }
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

}
