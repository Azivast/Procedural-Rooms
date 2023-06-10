using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[ExecuteInEditMode]
public class CellBehavior : MonoBehaviour
{
    public GameObject[] walls; // indexed as north, south, west, east

    public bool[] testState;
    
    void Start()
    {
        UpdateCell(testState);
    }
    
    void UpdateCell(bool[] state)
    {
        for (int i = 0; i < state.Length; i++)
        {
            walls[i].SetActive(!state[i]); // true = wall, false = no wall
        }
    }
}
