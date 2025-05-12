using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorController : MonoBehaviour
{
    private Image image;
    private Button button;
    [SerializeField] private GameObject player;
    private void Awake()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();
        button.onClick.AddListener(() => Onclick());
    }
    private void Onclick()
    {
        player.GetComponent<SpriteRenderer>().color=image.color;
    }
    private void IntercalateButton(bool a)
    {
        print("evento");
        button.interactable = a;
    }
    private void OnEnable()
    {
        PlayerController.buttonIntercalate += IntercalateButton;
    }
    private void OnDisable()
    {
        PlayerController.buttonIntercalate -= IntercalateButton;
    }
}
