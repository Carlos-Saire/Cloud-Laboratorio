using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLoadScene : MonoBehaviour
{
    public CambioScene CambiarScene;
    public ControlerBarrido Barrido;
    public string Scena;
    Button _button;
    private void Awake()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(() => CuandoCliqueo());
    }
    void CuandoCliqueo()
    {
        Barrido.SetActiveAnimationSalida();
        CambiarScene.LoadScene(Scena,1);
    }
    
}
