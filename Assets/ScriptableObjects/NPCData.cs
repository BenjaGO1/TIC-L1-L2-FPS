using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ItemDataSO", menuName ="NPCData")]
public class NPCData : ScriptableObject
{
    public string[] dialogo;
    public bool AHablado;
}
