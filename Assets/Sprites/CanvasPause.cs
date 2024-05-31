using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasPause : MonoBehaviour
{
    public GameObject Hud;
    public GameObject menuPausa;
    //public GameObject Hud;
    //public GameObject menuPausa;
    // Start is called before the first frame update
    void Start()
    {
        Hud.SetActive(true);
        menuPausa.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            pausa();

        }
        

    }

    public void Reanudar()
    {
        Time.timeScale = 1f;
        Hud.SetActive(true);
        menuPausa.SetActive(false);
    }

    public void pausa()
    {
        Time.timeScale = 0f;
        Hud.SetActive(false);
        menuPausa.SetActive(true);
    }

    public void reiniciar()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void salirMenu()
    {
        SceneManager.LoadScene("EscenaMenu");
    }

}
