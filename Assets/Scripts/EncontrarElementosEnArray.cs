using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncontrarElementosEnArray : MonoBehaviour
{

    public GameObject[] arrayDeMesas;
    
    void Start()
    {
        arrayDeMesas = GameObject.FindGameObjectsWithTag("Mesa");
        AddMesaScriptAndSetDestructible();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            DestroyDestructible();
        }
    }

    public void DeactivateObjectsInArray()
    {
        for (int i = 0; i < arrayDeMesas.Length; i++)
        {
            arrayDeMesas[i].SetActive(false);
        }
    }
    
    void AddMesaScriptAndSetDestructible()
    {
        foreach (GameObject go in arrayDeMesas)
        {
            go.AddComponent<Mesa>();
            int rnd = Random.Range(0, 2);
            go.GetComponent<Mesa>().destructible = rnd == 0;
        }
    }

    void DestroyDestructible()
    {
        foreach (GameObject go in arrayDeMesas)
        {
            if (go.GetComponent<Mesa>().destructible)
            {
                Destroy(go);
            }
        }
    }
}
