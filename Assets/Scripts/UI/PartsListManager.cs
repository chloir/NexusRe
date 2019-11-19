using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PartsListManager : MonoBehaviour
{
    [SerializeField] private GameObject content;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private Text partsName;
    [SerializeField] private Text partsSpec;
    [SerializeField] private Text categoryText;
    [SerializeField] private Text savedText;
    private PartsDataMaster _master;
    private AssembleManager _assembleManager;
    private int _currentCategory;
    private int _selectedPartsId;
    
    void Start()
    {
        _master = PartsDataMaster.GetInstance();
        _assembleManager = AssembleManager.GetInstance();
        savedText.enabled = false;
        CreateList(0);
        PartsButtonOnClick(0);
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
                         $"ArmorPoint : {data.ArmorPoint}\n" +
                         $"Energy : {data.EnergyProduction}\n" +
                         $"MovementVelocity : {data.MovementVelocity}";

        _selectedPartsId = id;
    }

    public void RequireButtonOnClick()
    {
        _assembleManager.UpdateAssemble(_currentCategory, _selectedPartsId);
        StartCoroutine(ShowSavedText());
    }

    public void ExitButtonOnClick()
    {
        SceneManager.LoadScene("CentralMenu");
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

    IEnumerator ShowSavedText()
    {
        savedText.enabled = true;
        var count = 120;
        var textColor = Color.black;
        for (int i = 0; i < count; i++)
        {
            textColor.a -= 0.008f;
            savedText.color = textColor;
            yield return null;
        }

        savedText.enabled = false;
    }
}
