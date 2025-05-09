using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSalir : MonoBehaviour
{
    Button _Buton;
    private void Awake()
    {
        _Buton = GetComponent<Button>();
        _Buton.onClick.AddListener(()=>Cuando_Cliqueo());
    }
    void Cuando_Cliqueo()
    {
        print("Entro");
        Application.Quit();
    }

}
