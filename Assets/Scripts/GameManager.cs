using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static public GameManager instance;
    [SerializeField] private TMP_Text text;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void InputWep(string value)
    {
        value = value.ToLower();

        if (value == "true")
        {
            WebGLInput.captureAllKeyboardInput = true;
        }
        else if (value == "false")
        {
            WebGLInput.captureAllKeyboardInput = false;
        }
        else
        {
            Debug.LogWarning("InputWep recibió un valor no válido: " + value);
        }
    }
    public void GetInputFiel(string value)
    {
        text.text = value;
    }
}