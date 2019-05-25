using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFleetManager : MonoBehaviour
{
    public static UIFleetManager uiFleetManagerInstance;


    public Button CloseButton;


    void OnEnable()
    {
        uiFleetManagerInstance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        Button[] buttonList = GetComponentsInChildren<Button>();


        CloseButton = buttonList[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenFleetManager()
    {
        this.gameObject.SetActive(true);
    }
    public void CloseFleetManager()
    {
        this.gameObject.SetActive(false);
    }
}
