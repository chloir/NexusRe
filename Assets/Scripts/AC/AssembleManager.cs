using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssembleManager : MonoBehaviour
{
    [SerializeField] private TextAsset assembleJson;
    private AssembleData _assembleData;
    
    void Start()
    {
        var jsonText = assembleJson.text;
        _assembleData = JsonUtility.FromJson<AssembleData>(jsonText);
        
        
    }

    void Update()
    {
        
    }
}
