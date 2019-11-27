using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsDataMaster : MonoBehaviour
{
    [SerializeField] private TextAsset partsMasterJson = null;
    private Dictionary<int, PartsData> _partsDataDictionary = new Dictionary<int, PartsData>();
    private static PartsDataMaster _instance;
    
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
        
        var partsList = JsonUtility.FromJson<PartsDataArray>(partsMasterJson.text);
        for (int i = 0; i < partsList.PartsDataList.Length; i++)
        {
            _partsDataDictionary.Add(partsList.PartsDataList[i].PartsId, partsList.PartsDataList[i]);
        }
    }
    
    public PartsData GetPartsData(int id)
    {
        var data = _partsDataDictionary[id];
        if (data == null)
            Debug.Log($"パーツIDが {id} のパーツは存在しません");

        return data;
    }

    public Dictionary<int, PartsData> GetMaster() => _partsDataDictionary;

    public static PartsDataMaster GetInstance() => _instance;
}
