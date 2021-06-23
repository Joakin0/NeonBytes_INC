using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Transform transToDig;
    public Transform transToSim;
    public Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }
}
