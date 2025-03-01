using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System.IO;

public class FunnelUIController : MonoBehaviour
{
    public VisualTreeAsset funnelUIAsset;
    private ProceduralFunnel funnelScript;
    private string savePath;

 

    void Start()
{
    savePath = Application.dataPath + "/funnelData.json";
    var uiDocument = GetComponent<UIDocument>();
    if (uiDocument == null)
    {
        Debug.LogError("UIDocument component not found.");
        return;
    }

    var root = uiDocument.rootVisualElement;
    if (root == null)
    {
        Debug.LogError("rootVisualElement is null. Check if the UI Document is correctly assigned.");
        return;
    }

    funnelScript = FindFirstObjectByType<ProceduralFunnel>();

    Slider topDSlider = root.Q<Slider>("TopDiameter");
    Slider bottomDSlider = root.Q<Slider>("BottomDiameter");
    Slider slopeHSlider = root.Q<Slider>("SlopeHeight");
    Slider tubeHSlider = root.Q<Slider>("TubeHeight");
    Slider segmentsSlider = root.Q<Slider>("Segments");

    Button saveButton = root.Q<Button>("SaveButton");
    Button loadButton = root.Q<Button>("LoadButton");

    if (topDSlider == null || bottomDSlider == null || slopeHSlider == null || tubeHSlider == null || segmentsSlider == null || saveButton == null || loadButton == null)
    {
        Debug.LogError("One or more sliders or buttons are not found in the UI Document.");
        return;
    }

    topDSlider.value = funnelScript.TopDiameter;
    bottomDSlider.value = funnelScript.BottomDiameter;
    slopeHSlider.value = funnelScript.SlopingHeight;
    tubeHSlider.value = funnelScript.TubeHeight;
    segmentsSlider.value = funnelScript.Segments;

    topDSlider.RegisterValueChangedCallback(evt => UpdateFunnel());
    bottomDSlider.RegisterValueChangedCallback(evt => UpdateFunnel());
    slopeHSlider.RegisterValueChangedCallback(evt => UpdateFunnel());
    tubeHSlider.RegisterValueChangedCallback(evt => UpdateFunnel());
    segmentsSlider.RegisterValueChangedCallback(evt => UpdateFunnel());

    saveButton.clicked += SaveFunnel;
    loadButton.clicked += LoadFunnel;
}


    // Update is called once per frame
    void Update()
    {
        
    }

    

    void UpdateFunnel()
    {
        var uiDocument = GetComponent<UIDocument>().rootVisualElement;
        funnelScript = FindFirstObjectByType<ProceduralFunnel>();

        Slider topDSlider = uiDocument.Q<Slider>("TopDiameter");
        Slider bottomDSlider = uiDocument.Q<Slider>("BottomDiameter");
        Slider slopeHSlider = uiDocument.Q<Slider>("SlopeHeight");
        Slider tubeHSlider = uiDocument.Q<Slider>("TubeHeight");
        Slider segmentsSlider = uiDocument.Q<Slider>("Segments");

        funnelScript.UpdateFunnel(
            topDSlider.value,
            bottomDSlider.value,
            slopeHSlider.value,
            tubeHSlider.value,
            (int)segmentsSlider.value
        );
    }

    public void SaveFunnel()
    {
        FunnelData funnelData = new FunnelData(
            funnelScript.TopDiameter,
            funnelScript.BottomDiameter,
            funnelScript.SlopingHeight,
            funnelScript.TubeHeight
        );

        string json = JsonUtility.ToJson(funnelData, true);
        File.WriteAllText(savePath, json);
        Debug.Log($"Funnel saved at: {savePath}");
    }

    public void LoadFunnel()
    {
        if(File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            FunnelData data = JsonUtility.FromJson<FunnelData>(json);
            
            funnelScript.TopDiameter= data.TopDiameter;
            funnelScript.BottomDiameter = data.BottomDiameter;
            funnelScript.SlopingHeight = data.SlopingHeight;
            funnelScript.TubeHeight = data.TubeHeight;

            Debug.Log("Successfully loaded saved funnel.");
            }
        else
        {
            Debug.LogWarning("No saved funnel found");
        }
    }

}
