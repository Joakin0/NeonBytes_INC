using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health;

    public GameObject botiquinModel;
    public void TakeDamage (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
        DropBotiquin();
    }

    void DropBotiquin()
    {
        Vector3 position = transform.position;
        GameObject botiquin = Instantiate(botiquinModel, position, Quaternion.identity);
        botiquin.SetActive(true);
        Destroy(botiquin, 5f);
    }
}
