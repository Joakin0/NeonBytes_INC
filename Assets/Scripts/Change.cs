using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Change : MonoBehaviour
{

    public GameObject imagen1;
    public GameObject imagen2;

    private void Start()
    {
        imagen1.GetComponent<Image>().enabled = false;
        imagen2.GetComponent<Image>().enabled = true;
    }
    public void ActivarImagen()
    {
        imagen1.GetComponent<Image>().enabled = true;
        imagen2.GetComponent<Image>().enabled = false;
        Debug.Log("activada");
    }

    public void DesactivarImagen()
    {
        imagen1.GetComponent<Image>().enabled = false;
        imagen2.GetComponent<Image>().enabled = true;
        Debug.Log("desactivada");
    }
}
