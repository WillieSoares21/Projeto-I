using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Configurações : MonoBehaviour
{
    // Variáveis
    public bool     isFullscreen;
    public int      resolutionIndex;
    public int      qualityTexture;

    // Objetos
    public Toggle   fullScreenToggle;
    public Dropdown resolutionDropdown;
    public Dropdown qualityTextureDropdown;
    public Dropdown linguagemDropdown;
    public Resolution[] resolutions;

    private void OnEnable()
    {
        resolutions = Screen.resolutions;
        foreach(Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add( new Dropdown.OptionData(resolution.ToString()));
        }
        // Chamado das funcões
        fullScreenToggle.onValueChanged.AddListener( delegate {OnFullScreenToggle();});
        resolutionDropdown.onValueChanged.AddListener( delegate {OnResolutionChange();});
        qualityTextureDropdown.onValueChanged.AddListener( delegate {OnTextureQualityChange();});
        linguagemDropdown.onValueChanged.AddListener( delegate {OnLiguagemChange();});
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnResolutionChange()
    {
        Screen.SetResolution(resolutions[resolutionDropdown.value].width, resolutions[resolutionDropdown.value].height, fullScreenToggle.isOn);
    }
    public void OnFullScreenToggle()
    {
        Screen.fullScreen = fullScreenToggle.isOn;
        OnResolutionChange();
    }
    public void OnTextureQualityChange()
    {
        QualitySettings.SetQualityLevel(qualityTextureDropdown.value);
    }
    public void OnLiguagemChange()
    {
        
    }
}
