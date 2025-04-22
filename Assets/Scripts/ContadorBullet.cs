using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ContadorBullet : MonoBehaviour
{
    [SerializeField] TMP_Text text; 
    private void Awake()
    {
        text = GetComponent<TMP_Text>();
    }
    public void Contador(float bullet)
    {
        text.text = "X " + bullet;
    }
}