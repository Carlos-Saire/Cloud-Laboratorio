using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerIntroduccion : MonoBehaviour
{
    public CuyMovie Cuy;
    public PlayerControler Player;
    public sbyte index = 0;
    public GameObject Buton;
    private void Start()
    {
        Cuy.SetActiveCaminata();
        Player.Dialogo(0);
    }
    private void Update()
    {
        if (Cuy.Confirmar==true)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                ++index;
                if (index % 2 == 0)
                {
                    Cuy.CuyDialogo(index);
                }
                else
                {
                    Player.Dialogo(index);
                }
            }
        }
        if (Cuy.Confirmar == false&&index>0)
        {
            Buton.SetActive(true);
        }
    }
}
