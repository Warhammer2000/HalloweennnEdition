using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsQualityController : MonoBehaviour
{
    [SerializeField] private Dropdown qualityDropdown;
    [SerializeField] private Text qualityText;

    private void Start()
    {
        qualityDropdown = GetComponent<Dropdown>();
        qualityText = transform.GetChild(0).GetComponent<Text>();
        SetQualitySettings();
    }
    private void SetQualitySettings()
    {
        qualityDropdown.ClearOptions();
        qualityDropdown.AddOptions(QualitySettings.names.ToList());
        qualityDropdown.value = QualitySettings.GetQualityLevel();
        qualityDropdown.RefreshShownValue();
    }
    public void SetQuality(int qualityIndex)
    {
        qualityIndex = qualityDropdown.value;

        QualitySettings.SetQualityLevel(qualityIndex);

        qualityText.text = QualitySettings.names[qualityIndex].ToString();  
        //вызываем проверку качества графики // 
        GraphicQualityCheker();
        ///Опиционально убрать после
    }
    private void GraphicQualityCheker()
    {
        int qualityLevel = QualitySettings.GetQualityLevel();
        string qualityName = QualitySettings.names[qualityLevel];
        Debug.Log("Текущее качество графики: " + qualityName + " " + qualityLevel);
    }
}
