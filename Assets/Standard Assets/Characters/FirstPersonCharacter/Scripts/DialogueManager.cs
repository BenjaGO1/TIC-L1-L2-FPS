using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject dialogoUI;
    [SerializeField] TextMeshProUGUI textoDelDialogo;
    [SerializeField] string[] frasesDialogo;
    [SerializeField] int posicionFrase;
    [SerializeField] bool hasTalked = false;
    public FirstPersonController fpc;
    public GameObject OBJ;

    // Start is called before the first frame update
    void Start()
    {
        dialogoUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && hasTalked == false)
        {
            NextFrase();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            dialogoUI.SetActive(true);

            if (hasTalked == false)
            {
                
                textoDelDialogo.text = "Pulsa F para continuar";
                
            }
            if(fpc.contador == 4)
            {
                textoDelDialogo.text = "Bien hecho, ahora dejame acomodarlos a todos";
                OBJ.SetActive(true);
            }

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("NPC"))
        {
            //al entrar desactiva la UI de dialogo
            dialogoUI.SetActive(false);
        }
        hasTalked = true;
    }

    void NextFrase()
    {
        if (posicionFrase < frasesDialogo.Length)
        {
            textoDelDialogo.text = frasesDialogo[posicionFrase];
            posicionFrase++;
        }

        else
        {
            dialogoUI.SetActive(false);
            
        }

    }
}
