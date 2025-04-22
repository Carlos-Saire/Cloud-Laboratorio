using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade : MonoBehaviour
{
    public Animator animator;
    public static Action onDeath;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnEnable()
    {
        onDeath += EstasMueto;
    }
    private void OnDisable()
    {
        onDeath -= EstasMueto;
    }
    // Update is called once per frame
    void Update()
    {
    }
    public void BtnReintentar()
    {
        animator.SetBool("FadeOut", false);
        animator.SetBool("FadeIn", true);
        SceneManager.LoadScene("Game");
    }
    public void EstasMueto()
    {
        Debug.Log("Mori");
        animator.SetBool("FadeOut", true);
        animator.SetBool("FadeIn", false);
    }
}
