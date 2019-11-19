using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PartsListManager : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Text partsName;
    [SerializeField] private Text partsSpec;
    [SerializeField] private Text categoryText;
    private PartsDataMaster _master;
    private int _currentCategory;
    
    void Start()
    {
        _master = PartsDataMaster.GetInstance();
        CreateList(0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            _currentCategory--;
            if (_currentCategory < 0)
                _currentCategory = 4;
            CreateList(_currentCategory);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            _currentCategory++;
            if (_currentCategory > 4)
                _currentCategory = 0;
            CreateList(_currentCategory);
        }
    }

    public void PartsButtonOnClick(int id)
    {
        var data = _master.GetPartsData(id);
        string partsCategory = GetCategory(id);
        
        partsName.text = $"{data.PartsName}";
        partsSpec.text = $"Category : {partsCategory}\n" +
                         $"NoneArmorPoint : {data.ArmorPoint}\n" +
                         $"Energy : {data.EnergyProduction}\n" +
                         $"MovementVelocity : {data.MovementVelocity}";
    }

    private void CreateList(int category)
    {
        // リスト初期化
        var objList = new List<GameObject>();
        
        for (int i = 0; i < content.transform.childCount; i++)
        {
            objList.Add(content.transform.GetChild(i).gameObject);
        }

        foreach (var obj in objList)
        {
            Destroy(obj);
        }

        // リスト作成
        _currentCategory = category;
        
        var dic = _master.GetMaster().Where(x => x.Value.PartsCategory == _currentCategory);
        foreach (var data in dic)
        {
            Instantiate(buttonPrefab, content.transform).GetComponent<PartsButtonController>()
                .InitializeButton(data.Value.PartsId, this);
        }

        var partsCategory = GetCategory(category);

        categoryText.text = $"Category:{partsCategory}";
    }

    private string GetCategory(int category)
    {
        string partsCategory = "";
        switch (_currentCategory)
        {
            case 0:
                partsCategory = "Head";
                break;
            case 1:
                partsCategory = "Body";
                break;
            case 2:
                partsCategory = "Arm";
                break;
            case 3:
                partsCategory = "Leg";
                break;
            case 4:
                partsCategory = "Generator";
                break;
            default:
                partsCategory = "None";
                break;
        }

        return partsCategory;
    }
}
