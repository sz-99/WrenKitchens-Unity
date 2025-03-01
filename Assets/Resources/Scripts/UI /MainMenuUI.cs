using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUI : MonoBehaviour
{
    public VisualTreeAsset mainMenuUIAsset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var uiDocument = GetComponent<UIDocument>();
        if(uiDocument == null) 
        {    
            Debug.LogError("UI document not found."); 
            return;
        }

        if (mainMenuUIAsset != null)
        {
            uiDocument.visualTreeAsset = mainMenuUIAsset;
        }
        else
        {
            Debug.LogError("VisualTreeAsset (mainMenuUIAsset) is not assigned.");
            return;
        }
        
        var root = uiDocument.rootVisualElement;
        Button startButton = root.Q<Button>("Start");
        
        startButton.clicked += ()=> 
        {
            Debug.Log("Start button clicked! Loading scene...");

            SceneManager.LoadScene("ProceduralFunnel");
        };
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
