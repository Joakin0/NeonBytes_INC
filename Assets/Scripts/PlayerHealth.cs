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
        if (other.CompareTag("Enemy"))
        {
            Destroy(myCanvas.transform.GetChild(cantVida + 1).gameObject);
            cantVida -= 1;
            if (cantVida <=0)
            {
                Destroy(gameObject);
            }
            
        }
    }

}
