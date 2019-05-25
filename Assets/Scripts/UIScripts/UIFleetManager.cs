using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFleetManager : MonoBehaviour
{
    public static UIFleetManager uiFleetManagerInstance;


    public Button CloseButton;
    public ScrollRect scrollRect;

    public RectTransform viewPortContent;

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

    
    public void UpdateFleetManager()
    {
        for(int i = 0; i < PlayerManager.playerInstance.m_playerFleet.m_shipList.Count;i++)
        {
            GameObject shipImg = Instantiate(Resources.Load("Prefabs/UI/ShipUI/ShipImage")) as GameObject;
            Image img = shipImg.GetComponentInChildren<Image>();
            shipImg.transform.SetParent(viewPortContent);
            shipImg.transform.position = new Vector3(50,-50*(i+1));
        }
    }


    public void OpenFleetManager()
    {
        this.gameObject.SetActive(true);
        UpdateFleetManager();
    }
    public void CloseFleetManager()
    {
        this.gameObject.SetActive(false);
    }
}
