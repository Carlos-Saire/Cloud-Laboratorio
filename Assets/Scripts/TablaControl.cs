using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TablaControl : MonoBehaviour
{
    public GameObject Ingrediente;
    public void Guardar(GameObject food)
    {
        if (Ingrediente == null)
        {
            
            Ingrediente = food;
        }
        else
        {
            Destroy(food);
        }
    }
    public void Limpiar()
    {
        if (Ingrediente != null)
        {
            Destroy(Ingrediente);
            Ingrediente = null;
        }
    }
}
