using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image vida;
    public static int cantVida;
    public RectTransform posPrimeraVida;
    public int offset;
    public Canvas myCanvas;
    public Transform lastVida;

    public LayerMask item;

    private void Start()
    {
        cantVida = 10;
        for (int i = 0; i < cantVida; i++)
        {
            Image nuevaVida = Instantiate(vida, posPrimeraVida.position, Quaternion.identity);
            nuevaVida.transform.parent = myCanvas.transform;
            posPrimeraVida.position = new Vector2(posPrimeraVida.position.x, posPrimeraVida.position.y + offset);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            
            Destroy(myCanvas.transform.GetChild(cantVida + 1).gameObject);
            cantVida -= 1;
            Debug.Log(cantVida);
            
            if (cantVida <=0)
            {
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
            
        }
        if (other.CompareTag("Botiquin") && cantVida < 10)
        {
            
            cantVida++;
            posPrimeraVida.position = new Vector2(myCanvas.transform.GetChild(cantVida-1).position.x, myCanvas.transform.GetChild(cantVida - 1).position.y + offset);
            Image nuevaVida = Instantiate(vida, posPrimeraVida.position, Quaternion.identity);
            nuevaVida.transform.parent = myCanvas.transform;
            Debug.Log(cantVida);
        }
    }

}
