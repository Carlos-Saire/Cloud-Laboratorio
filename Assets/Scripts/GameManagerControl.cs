using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

public class GameManagerControl : MonoBehaviour
{
    [HeaderAttribute("Hornillas")]
    public TablaControl[] Hornillas=new TablaControl[4];

    [HeaderAttribute("Mesas")]
    public TablaControl[] Mesas=new TablaControl[4];

    public TablaControl[] Emplado=new TablaControl[3];

    [HeaderAttribute("Ingredientes")]
    public GameObject[] Ingrediente;

    [HeaderAttribute("asdas")]
    bool[] QuantityIngredientes;
    private void Awake()
    {
        QuantityIngredientes=new bool[Ingrediente.Length];
    }
    private void Start()
    {
        Time.timeScale = 1.0f;
    }
    private void Update()
    {

        //Mesa 2
        Crafteo(Mesas, "Cuchillo", "PapaCruda", 0);
        Crafteo(Mesas, "Cuchillo", "Cebolla", 2);
        Crafteo(Mesas, "Cuchillo", "Aji amarillo", 3);
        Crafteo(Mesas, "Cuchillo", "Tomate", 4);
        Crafteo(Mesas, "Cuchillo", "Lomo fino crudo", 5);
        
        //Hornillas 2
        Crafteo(Hornillas, "Fondo oscuro carne", "Guarnicion aromatica", 1);
        Crafteo(Hornillas, "Arroz", "Olla", 6);
        Crafteo(Hornillas, "Papa en bastones", "Sarten", 7);

        //Hornillas 3
        Crafteo(Emplado, "Lomo Salteado", "arros graneado", "Papas fritas", 10);


        //Hornillas 4
        Crafteo(Hornillas, "Lomo fino en pedazos", "aji amarrillo en juliana", "Tomate en juliana", "cebolla en gajos", 8);
        Crafteo(Hornillas, "Lomo salteado con verduras", "Nage", "culantro","Premix", 9);


    }
    //Crafteos de 2
    void Crafteo(TablaControl[] tablas, string IngredienteA, string IngredienteB, sbyte Index)
    {
        for (int i = 0; i < tablas.Length; ++i)
        {
            for (int j = 0; j < tablas.Length; ++j)
            {
                if (tablas[i].Ingrediente != null && tablas[j].Ingrediente != null &&
                    tablas[i].Ingrediente.gameObject.tag == IngredienteA && tablas[j].Ingrediente.gameObject.tag == IngredienteB)
                {
                    Crear(tablas[i], tablas[j],Index);
                }
            }
        }
    }
    //Crafteos de 3
    void Crafteo(TablaControl[] tablas, string IngredienteA, string IngredienteB, string IngredienteC, sbyte Index)
    {
        for (int i = 0; i < tablas.Length ; ++i)
        {
            for (int j = 0; j < tablas.Length ; ++j)
            {
                for (int k = 0; k < tablas.Length; ++k)
                {

                    if (tablas[i].Ingrediente != null && tablas[j].Ingrediente != null && tablas[k].Ingrediente != null &&  
                       (tablas[i].Ingrediente.gameObject.tag == IngredienteA && tablas[j].Ingrediente.gameObject.tag == IngredienteB &&
                       tablas[k].Ingrediente.gameObject.tag == IngredienteC))
                    {
                        Crear(tablas[i], tablas[j], tablas[k], Index);
                    }
                }
            }
        }
    }
    //Crafteos de 4
    void Crafteo(TablaControl[] tablas , string IngredienteA, string IngredienteB, string IngredienteC, string IngredienteD,sbyte Index)
    {
        for (int i = 0; i < tablas.Length; ++i)
        {
            for (int j = 0; j < tablas.Length; ++j)
            {
                for (int k = 0; k < tablas.Length; ++k)
                {
                    for (int l = 0; l < tablas.Length; ++l)
                    {
                        if (tablas[i].Ingrediente != null && tablas[j].Ingrediente != null && tablas[k].Ingrediente != null && tablas[l].Ingrediente != null &&
                           (tablas[i].Ingrediente.gameObject.tag == IngredienteA && tablas[j].Ingrediente.gameObject.tag == IngredienteB &&
                           tablas[k].Ingrediente.gameObject.tag == IngredienteC && tablas[l].Ingrediente.gameObject.tag == IngredienteD))
                        {
                            Crear(tablas[i], tablas[j], tablas[k], tablas[l], Index);
                        }
                    }
                }
            }
        }
    }
    void Crear(TablaControl a, TablaControl b,sbyte Index)
    {
        if (QuantityIngredientes[Index] == false)
        {
            QuantityIngredientes[Index] = true;
            Ingrediente[Index].SetActive(true);
            a.Limpiar();
            b.Limpiar();
        }
        else
        {
            a.Limpiar();
            b.Limpiar();
        }
    }
    void Crear(TablaControl a, TablaControl b,TablaControl c,sbyte Index)
    {
        Crear(a,b,Index);
        if (QuantityIngredientes[Index] == false)
        {
            print("Entro");
            c.Limpiar();
        }
        else
        {
            c.Limpiar();
        }
    }
    void Crear(TablaControl a,TablaControl b,TablaControl c,TablaControl d,sbyte Index)
    {
        Crear(a, b,Index);
        Crear(c,d,Index);
    }
    public void Reanudar()
    {
        Time.timeScale = 1.0f;
    }
    public void Pause()
    {
        Time.timeScale = 0;
    }
    public void LimpiarTablas()
    {
        for(sbyte i = 0; i < Hornillas.Length; ++i)
        {
            Hornillas[i].Limpiar();
        }
        for(sbyte i = 0; i < Mesas.Length; ++i)
        {
            Mesas[i].Limpiar();
        }
        for(sbyte i = 0;i<Emplado.Length; ++i)
        {
            Emplado[i].Limpiar();
        }
    }
}
