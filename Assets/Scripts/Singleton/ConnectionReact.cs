using UnityEngine;
using System.Runtime.InteropServices;

public class ConnectionReact : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ReceiveUnityMessage(string message);

    public static ConnectionReact Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(Instance);
        }
    }

    private void Start()
    {
        SendMessageToReact("Hola desde unity");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SendMessageToReact(string message)
    {
#if UNITY_WEBGL == true && UNITY_EDITOR == false
        ReceiveUnityMessage(message);
#endif
    }

}