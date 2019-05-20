using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIColonyManager : MonoBehaviour
{
    public static UIColonyManager uiColonyManagerInstance;

    public CPlanet currentPlanet;

    // Images
    public Image BuildingList;
    public Image PlanetInfos;
    public Image BuildingTypeChoice;
    public Image AlertImage;
    public Image ColonyResources;
    // Buttons
    public Button BuildingShipButton;
    public Button BuildBuildingButton;
    public Button ShowPopulationButton;
    public Button CloseButton;
    public void OnEnable()
    {
        uiColonyManagerInstance = this;
    }
    public void Start()
    {
        Image[] imgTab = GetComponentsInChildren<Image>();
        for(int i = 0; i < imgTab.Length;i++)
        {
            if (imgTab[i].name == "BuildingTypeChoice")
            {
                BuildingTypeChoice = imgTab[i];
                BuildingTypeChoice.gameObject.SetActive(false);
            }
            else if(imgTab[i].name == "BuildingList")
            {
                BuildingList = imgTab[i];
            }
            else if (imgTab[i].name == "PlanetInfos")
            {
                PlanetInfos = imgTab[i];
            }
            else if (imgTab[i].name == "AlertImage")
            {
                AlertImage = imgTab[i];
                AlertImage.gameObject.SetActive(false);
            }
            else if( imgTab[i].name == "ColonyResources")
            {
                ColonyResources = imgTab[i];
            }
        }
        Button[] butTab = GetComponentsInChildren<Button>();
        for(int i = 0; i < butTab.Length;i++)
        {
            if(butTab[i].name == "BuildShipButton")
            {
                BuildingShipButton = butTab[i];
            }
            else if (butTab[i].name == "BuildBuildingButton")
            {
                BuildingShipButton = butTab[i];
            }
        }
    }
    public void ShowColonyManager(CColony colony)
    {
        currentPlanet = colony.m_parentPlanet;
        UpdateColonyManagerImage(colony);
    }
    void UpdateColonyManagerImage(CColony colony)
    {
        Text[] texts = PlanetInfos.GetComponentsInChildren<Text>();
        for (int i = 0; i < texts.Length; i++)
        {
            if (texts[i].name == "NameText")
                texts[i].text = colony.m_parentPlanet.m_planetName;
            else if (texts[i].name == "TypeText")
                texts[i].text = colony.m_parentPlanet.m_planetType.ToString();
            else if (texts[i].name == "PlanetResourcesText")
                texts[i].text = colony.m_parentPlanet.m_planetResources.ToString();
        }
        UpdateColonyResourcesImage();
    }
    public void ConstructBuildingPhase1()
    {
        BuildingTypeChoice.gameObject.SetActive(true);
    }
    // Farm Cost 5 food and 5 metal
    public void ConstructFarm()
    {
        bool check;
        check = currentPlanet.m_colony.CheckResourcesToConstruct(E_BUILDING_TYPES.E_FARM);
        if(!check)
        {
            AlertImage.gameObject.SetActive(true);
            return;
        }
        else
        {
            currentPlanet.m_colony.CreateBuilding(E_BUILDING_TYPES.E_FARM);
            BuildingTypeChoice.gameObject.SetActive(false);
            PlayerManager.playerInstance.UpdateColonyInfoInSolarSystemView(currentPlanet.m_colony);
            UpdateBuildingList();
            UpdateColonyResourcesImage();
        }
    }
    public void ConstructMine()
    {
        bool check;
        check = currentPlanet.m_colony.CheckResourcesToConstruct(E_BUILDING_TYPES.E_MINE);
        if (!check)
        {
            AlertImage.gameObject.SetActive(true);
            return;
        }
        else
        {
            currentPlanet.m_colony.CreateBuilding(E_BUILDING_TYPES.E_MINE);
            BuildingTypeChoice.gameObject.SetActive(false);
            PlayerManager.playerInstance.UpdateColonyInfoInSolarSystemView(currentPlanet.m_colony);
            UpdateBuildingList();
            UpdateColonyResourcesImage();
        }
    }
    public void UpdateBuildingList()
    {
        Text text = BuildingList.gameObject.GetComponentInChildren<Text>();
        text.text = "Building List:\n";
        text.text += "Number of buildings " + currentPlanet.m_colony.m_buildingList.Count + "\n";
        for(int i = 0; i < currentPlanet.m_colony.m_buildingList.Count;i++)
        {
            text.text += i.ToString()+"  Type : " + currentPlanet.m_colony.m_buildingList[i].m_buildingType.ToString() + "\n";
        }
    }

    public void UpdateColonyResourcesImage()
    {
        Text[] texts = ColonyResources.GetComponentsInChildren<Text>();
        if(currentPlanet != null)
        {
            texts[0].text = currentPlanet.m_colony.m_colonyResources.m_foodAmount.ToString();
            texts[1].text = currentPlanet.m_colony.m_colonyResources.m_metalAmount.ToString();
            texts[2].text = currentPlanet.m_colony.m_colonyResources.m_hydrogenAmount.ToString();
            texts[3].text = currentPlanet.m_colony.m_colonyResources.m_uraniumAmount.ToString();
        }
        
    }

    public void CloseColonyManager()
    {
        currentPlanet = null;
        this.gameObject.SetActive(false);
    }
    public void CloseAlert()
    {
        AlertImage.gameObject.SetActive(false);
    }
    public void CloseChoosingBuildingType()
    {
        BuildingTypeChoice.gameObject.SetActive(false);
    }
}
