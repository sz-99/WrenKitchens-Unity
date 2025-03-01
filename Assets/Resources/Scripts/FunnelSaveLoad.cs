using System.IO;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FunnelData
{
    public float TopDiameter;
    public float BottomDiameter;
    public float SlopingHeight;
    public float TubeHeight;

    public FunnelData(float td, float bd, float sh, float th)
    {
        TopDiameter = td;
        BottomDiameter = bd;
        SlopingHeight = sh;
        TubeHeight = th;
    }
}
public class FunnelSaveLoad : MonoBehaviour
{
    private string savePath;
    private ProceduralFunnel funnel;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        savePath = Application.persistentDataPath + "/funnelData.json";
        funnel = FindFirstObjectByType<ProceduralFunnel>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveFunnel()
    {
        FunnelData funnelData = new FunnelData(
            funnel.TopDiameter,
            funnel.BottomDiameter,
            funnel.SlopingHeight,
            funnel.TubeHeight
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
            
            funnel.TopDiameter= data.TopDiameter;
            funnel.BottomDiameter = data.BottomDiameter;
            funnel.SlopingHeight = data.SlopingHeight;
            funnel.TubeHeight = data.TubeHeight;

            Debug.Log("Successfully loaded saved funnel.");
            }
        else
        {
            Debug.LogWarning("No saved funnel found");
        }
    }
}
