using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsQualityController : MonoBehaviour
{
    [SerializeField] private Dropdown qualityDropdown;

    private void Start()
    {
        qualityDropdown = GetComponent<Dropdown>();
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
