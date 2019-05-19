using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager playerInstance;

    public List<CStar> m_playerStarList;
    public List<CColony> m_playerColonyList;

    public List<GameObject> m_playerStarsIconList;

    public Image m_playerColonyInfos;
    public Image m_colonyManagerImage;
    public bool oneIconNotActive;

    void OnEnable()
    {
        playerInstance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        m_playerStarList = new List<CStar>();
        m_playerColonyList = new List<CColony>();
        m_playerStarsIconList = new List<GameObject>();
        m_playerColonyInfos.gameObject.SetActive(false);
        m_colonyManagerImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Update in galaxy 
        if (!SolarSystemManager.m_solarSystemInstance.solarSystemViewActive)
        {
            //check for star clicks
            if (Input.GetMouseButtonDown(0))
            {
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(mouseRay, out hit))
                {
                    CStar star = GalaxyManager.galaxyInstance.returnStarFromGameobject(hit.transform.gameObject);
                    if (star != null)
                    {
                        if (star.m_parentFaction == E_FACTION.E_PLAYER)
                        {
                            m_playerColonyInfos.gameObject.SetActive(true);
                            UpdateColonyInfoInGalaxyView(star);
                        }
                    }
                }
                else
                {
                    m_playerColonyInfos.gameObject.SetActive(false);
                }
            }

            // update player star icons
            if (oneIconNotActive == true)
            {
                for (int i = 0; i < m_playerStarsIconList.Count; i++)
                {
                    m_playerStarsIconList[i].SetActive(true);
                }
                oneIconNotActive = false;
            }
        }// Update in solar system view
        else
        {
            // check for planet clicks
            if (Input.GetMouseButtonDown(0))
            {
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(mouseRay, out hit))
                {
                    CPlanet planet = SolarSystemManager.m_solarSystemInstance.returnPlanetFromGameObject(hit.transform.gameObject);
                    if (planet != null)
                    {
                        if (planet.m_parentStar.m_parentFaction == E_FACTION.E_PLAYER)
                        {
                            if (planet.m_colony != null)
                            {
                                m_playerColonyInfos.gameObject.SetActive(true);
                                UpdateColonyInfoInSolarSystemView(planet.m_colony);
                            }
                        }
                    }
                }
                else
                {
                    m_playerColonyInfos.gameObject.SetActive(false);
                }
            }
            // Check right click on colonized planet to print colony management canva;
            else if (Input.GetMouseButtonDown(1))
            {
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(mouseRay, out hit))
                {
                    CPlanet planet = SolarSystemManager.m_solarSystemInstance.returnPlanetFromGameObject(hit.transform.gameObject);
                    if (planet != null)
                    {
                        if (planet.m_parentStar.m_parentFaction == E_FACTION.E_PLAYER)
                        {
                            if (planet.m_colony != null)
                            {
                                // todo
                                m_playerColonyInfos.gameObject.SetActive(false);
                                m_colonyManagerImage.gameObject.SetActive(true);
                                UIColonyManager.uiColonyManagerInstance.ShowColonyManager(planet.m_colony);
                                Debug.Log("Entering in colony management scene");
                            }
                        }
                    }
                }
            }    
        }
    }
    void UpdateColonyInfoInGalaxyView(CStar star)
    {
        Text[] colonyInfoTxt = m_playerColonyInfos.GetComponentsInChildren<Text>();
        for (int index = 0; index < colonyInfoTxt.Length; index++)
        {
            if (colonyInfoTxt[index].name == "Text")
            {
                colonyInfoTxt[index].text = "Star  : " +star.m_starName.ToString() + "\n";
                colonyInfoTxt[index].text += "With " + star.m_planetNumber.ToString() + " Planets\n";
                //for (int i = 0; i < star.m_planetNumber; i++)
                //{
                //    colonyInfoTxt[index].text +=  "Planet  : " + star.m_planetList[i].m_planetName.ToString() 
                //                                + " Type : " + star.m_planetList[i].m_planetType+ "\n";
                //}
                break;
            }
        }
    }

    public void UpdateColonyInfoInSolarSystemView(CColony clickedColony)
    {
        Text[] colonyInfoTxt = m_playerColonyInfos.GetComponentsInChildren<Text>();
        for (int index = 0; index < colonyInfoTxt.Length; index++)
        {
            if (colonyInfoTxt[index].name == "Text")
            {
                colonyInfoTxt[index].text = "Colony description : "+ "\n";
                colonyInfoTxt[index].text += "Planet Name : " + clickedColony.m_parentPlanet.m_planetName + "\n";
                colonyInfoTxt[index].text += "Planet Type : " + clickedColony.m_parentPlanet.m_planetType + "\n";
                colonyInfoTxt[index].text += "Available Resources   : " + "\n";
                colonyInfoTxt[index].text += clickedColony.m_parentPlanet.m_planetResources.ToString();

                for (int i = 0; i < clickedColony.m_buildingList.Count;i++)
                {
                    colonyInfoTxt[index].text += "Building : " + clickedColony.m_buildingList[i].m_buildingType + "\n";
                }
                break;
            }
        }
    }
    Image returnPlanetInfo(Image[] tab)
    {
        for (int i = 0; i < tab.Length; i++)
        {
            if (tab[i].name == "PlanetInfos")
            {
                return tab[i];
            }
        }
        return null;
    }
    


}
