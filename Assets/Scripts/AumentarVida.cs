using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AumentarVida : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(PlayerHealth.cantVida <10)
            PlayerHealth.cantVida++;
            Destroy(gameObject);
        }
        
    }
}
