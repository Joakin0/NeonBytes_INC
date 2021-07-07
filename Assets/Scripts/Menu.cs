using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{

    public void Salir()
    {
        Application.Quit();
    }
    public void SeleccionarNivel1()
    {
        SceneManager.LoadScene(2);
    }
    public void SeleccionarNivel2()
    {
        SceneManager.LoadScene(3);
    }
    public void SeleccionarNivel3()
    {
        SceneManager.LoadScene(4);
    }
    public void Creditos()
    {
        SceneManager.LoadScene(5);
    }
    public void SeleccionarNivel()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }
}
