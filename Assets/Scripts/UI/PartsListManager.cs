using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartsListManager : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Text partsSpec;
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PartsButtonOnClick(int id)
    {
        partsSpec.text = $"";
    }
}
