using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class AssembleManager : MonoBehaviour
{
    [SerializeField] private TextAsset assembleJson;
    [SerializeField] private TextAsset partsMasterJson;
    private AssembleData _assembleData;
    private Dictionary<int, PartsData> _partsMaster = new Dictionary<int, PartsData>();

    private int _armorPoint;
    private float _movementVelocity;

    private static AssembleManager _instance;

    private void Awake()
    {
        _instance = this;
        
        _assembleData = JsonUtility.FromJson<AssembleData>(assembleJson.text);

        PartsDataArray partsarr = JsonUtility.FromJson<PartsDataArray>(partsMasterJson.text);
        for (int i = 0; i < partsarr.PartsDataList.Length; i++)
        {
            _partsMaster.Add(partsarr.PartsDataList[i].PartsId, partsarr.PartsDataList[i]);
            Debug.Log(_partsMaster[partsarr.PartsDataList[i].PartsId].PartsName);
        }

        _armorPoint = _partsMaster[_assembleData.armPartsId].ArmorPoint +
                      _partsMaster[_assembleData.bodyPartsId].ArmorPoint +
                      _partsMaster[_assembleData.headPartsId].ArmorPoint +
                      _partsMaster[_assembleData.legPartsId].ArmorPoint;

        _movementVelocity = _partsMaster[_assembleData.legPartsId].MovementVelocity;
    }

    public void UpdateAssemble(int category, int partsid)
    {
        switch (category)
        {
            case 0:
                _assembleData.headPartsId = partsid;
                break;
            case 1:
                _assembleData.bodyPartsId = partsid;
                break;
            case 2:
                _assembleData.armPartsId = partsid;
                break;
            case 3:
                _assembleData.legPartsId = partsid;
                break;
            case 4:
                _assembleData.generatorPartsId = partsid;
                break;
            default:
                Debug.Log("カテゴリーが存在しません");
                break;
        }

        var json = JsonUtility.ToJson(_assembleData, true);
        var filepath = Application.dataPath + "/DataResources/AssembleTemplate.json";
        var sw = new StreamWriter(filepath, false);
        sw.WriteLine(json);
        sw.Flush();
        sw.Close();
    }
    
    public int GetAssembledArmorPoint() => _armorPoint;

    public float GetAssembledMovementVelocity() => _movementVelocity;

    public (int primary, int secondary) GetWeaponId() =>
        (_assembleData.primaryWeaponId, _assembleData.secondaryWeaponId);

    public AssembleData GetAssemble() => _assembleData;

    public static AssembleManager GetInstance() => _instance;
}