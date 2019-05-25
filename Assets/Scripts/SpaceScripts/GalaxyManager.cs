using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Linq;

public enum E_GalaxyType
{
    E_SPIRAL = 0,
    E_SPHERICAL
}

public class GalaxyManager : MonoBehaviour
{
    public int numberOfStars;
    public float minDistanceBetweenStars;
    public float minimalDistanceFromCenter;
    public float galaxyRadius;
    public int  m_galaxySeedNumber;

    public static GalaxyManager galaxyInstance;

    Dictionary<CStar, GameObject> starToGameObject;
    public List<CStar> listOfStars;

    public Button resetGalaxyButton;
    public Button destroyGalaxyButton;

    public Text infoText;

    public GameObject selectionIcon;


    private void OnEnable()
    {
        galaxyInstance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        destroyGalaxyButton.gameObject.SetActive(false);
        resetGalaxyButton.gameObject.SetActive(false);
        InitGalaxy();
        SelectPlayerStar();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (!SolarSystemManager.m_solarSystemInstance.solarSystemViewActive)
            {
                Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(mouseRay, out hit))
                {
                    MoveSelectionIcon(hit);
                    if (Input.GetMouseButtonDown(0))
                    {
                        CStar m_star = returnStarFromGameobject(hit.transform.gameObject);
                        infoText.text = "Selected Star     : \n" +
                                        "Star Name         : " + m_star.m_starName + "\n" +
                                        "Star Type         : " + m_star.m_starType + "\n" +
                                        "Position          : " + m_star.m_starPosition + "\n" +
                                        "Number of planets : " + m_star.m_planetNumber + "\n";
                    }
                }
                else
                    selectionIcon.SetActive(false);
            }
        }       
    }

    void InitGalaxy()
    {
        listOfStars = new List<CStar>();
        starToGameObject = new Dictionary<CStar, GameObject>();
        CreateStars();
        destroyGalaxyButton.gameObject.SetActive(true);
        CreateSelectionIcon();
    }
    void CreateSelectionIcon()
    {
        selectionIcon = Instantiate(Resources.Load(Constantes.prefab_sprite_selection_name)) as GameObject;
        selectionIcon.transform.localScale *= 7.5f;
        selectionIcon.SetActive(false);
    }
    public void MoveSelectionIcon(RaycastHit hit)
    {
        selectionIcon.SetActive(true);
        selectionIcon.transform.position = hit.transform.position;
    }
    void CreateStars()
    {
        int randomType = 0;
        Vector3 position = new Vector3();
        float distance = 0f;
        float angle = 0f;
        float scale = 0f;
        int planetNumber = 0;
        int failCount = 0;
        CStar tmpStar;
        if(m_galaxySeedNumber != 0)
            UnityEngine.Random.InitState(m_galaxySeedNumber);
        //m_galaxySeedNumber = UnityEngine.Random;
        for (int i = 0; i < numberOfStars; i++)
        {
            randomType = (int)Mathf.Round(UnityEngine.Random.Range(0, (float)E_StarType.E_STAR_TYPE_NB - 0.55f));

            //Random geometric values
            distance = UnityEngine.Random.Range(minimalDistanceFromCenter, galaxyRadius);
            angle = UnityEngine.Random.Range(0, 2 * Mathf.PI);
            scale = UnityEngine.Random.Range(.5f, 1.5f);
            planetNumber = (int) Mathf.Round(UnityEngine.Random.Range((float)cst.E_MINIMUM_PLANET_NUMBER,
                                                                      (float)cst.E_MAXIMUM_PLANET_NUMBER)
                                            );

            position.Set(distance * Mathf.Cos(angle), 0, distance * Mathf.Sin(angle));


            Collider[] tmp = Physics.OverlapSphere(position, minDistanceBetweenStars + 10f);

            if (tmp.Length == 0)
            {
                GameObject instance = Instantiate(Resources.Load(Constantes.prefab_names[randomType])) as GameObject;
                instance.transform.SetParent(this.transform);
                instance.transform.position = position;
                instance.transform.localScale = new Vector3(scale, scale, scale);
                // We init all stars with none faction. This will be determined later
                tmpStar = new CStar("Star " + i, scale, randomType, position, planetNumber,E_FACTION.E_NONE);

                starToGameObject.Add(tmpStar, instance);
                listOfStars.Add(tmpStar);
                failCount = 0;
            }
            else
            {
                failCount++;
                i--;
            }
            if (failCount > 100)
            {
                Debug.Log("Too much fails during generation, stop !");
                break;
            }
        }
    }
    private int returnStarIndexContainingLushPlanet()
    {
        for (int i = 0; i < listOfStars.Count; i++)
        {
            for (int tmp = 0; tmp < listOfStars[i].m_planetNumber; tmp++)
            {
                if (listOfStars[i].m_planetList[tmp].m_planetType == E_PLANET_TYPE.E_LUSH)
                {
                    return i;
                }
            }
        }
        return -1;
    }
    private int returnLushPlanetIndex(int starIndexInList)
    {
        for(int i = 0; i < listOfStars[starIndexInList].m_planetNumber;i++ )
        {
            if (listOfStars[starIndexInList].m_planetList[i].m_planetType == E_PLANET_TYPE.E_LUSH)
                return i;
        }
        return -1;
    }
    private void SelectPlayerStar()
    {
        int selectedStar,selectedPlanet;

        selectedStar = returnStarIndexContainingLushPlanet();
        if (selectedStar == -1)
        {
            Debug.Log("Alert, impossible to find star with lush planet !");
            return;
        }

        selectedPlanet = returnLushPlanetIndex(selectedStar);
        if (selectedPlanet == -1)
        {
            Debug.Log("Alert impossible to find lush planet in star " + selectedStar);
            return;
        }

        CStar star = listOfStars[selectedStar];
        star.m_parentFaction = E_FACTION.E_PLAYER;

        PlayerManager.playerInstance.m_playerStarList.Add(star);

        CPlanet selectStartPlanet = star.m_planetList[selectedPlanet];
        CColony startColony = new CColony(selectStartPlanet);

        PlayerManager.playerInstance.m_playerColonyList.Add(startColony);
        selectStartPlanet.m_colony = startColony;

        GameObject instance = Instantiate(Resources.Load(Constantes.prefab_sprite_green_circle_name)) as GameObject;
        instance.transform.SetParent(PlayerManager.playerInstance.gameObject.transform);
        instance.transform.localScale *= 3f;
        instance.transform.position = star.m_starPosition;
        //store star and green circle game object in dict
        PlayerManager.playerInstance.m_playerStarsToCircle.Add(star, instance);

        GameObject instanceColonyGreenCircle = Instantiate(Resources.Load(Constantes.prefab_sprite_green_circle_name)) as GameObject;
        instanceColonyGreenCircle.transform.SetParent(PlayerManager.playerInstance.gameObject.transform);
        instanceColonyGreenCircle.transform.localScale *= 3f;
        instanceColonyGreenCircle.transform.position = startColony.m_parentPlanet.m_planetPosition;
        instanceColonyGreenCircle.gameObject.SetActive(false); // will be done in solar system view
        PlayerManager.playerInstance.m_playerPlanetcolonyToPlayerCircle.Add(startColony, instanceColonyGreenCircle);

    }

    public CStar returnStarFromGameobject(GameObject go)
    {
        int index = starToGameObject.Values.ToList().IndexOf(go);
        return starToGameObject.Keys.ToList()[index];
    }

    public void ResetGalaxy()
    {
        SolarSystemManager.m_solarSystemInstance.DestroySolarSystem();

        for(int i = 0; i < starToGameObject.Count; i++)
        {
            //GameObject instance = starToGameObject.Values.ToList()[i];
            CStar tmpStar = starToGameObject.Keys.ToList()[i];

            GameObject instance = Instantiate(Resources.Load(Constantes.prefab_names[(int) tmpStar.m_starType])) as GameObject;
            instance.transform.SetParent(this.transform);
            instance.transform.position = tmpStar.m_starPosition;
            instance.transform.localScale = new Vector3(tmpStar.m_starSize, tmpStar.m_starSize, tmpStar.m_starSize);

            starToGameObject[tmpStar] = instance;
        }
        //Update player stars icons
        for (int i = 0; i < PlayerManager.playerInstance.m_playerStarsToCircle.Values.ToList().Count; i++)
        {
            PlayerManager.playerInstance.m_playerStarsToCircle.Values.ToList()[i].SetActive(true);
        }
        resetGalaxyButton.gameObject.SetActive(false);
        destroyGalaxyButton.gameObject.SetActive(true);
    }

    public void DestroyGalaxy()
    {
        while(transform.childCount > 0)
        {
            Transform go = transform.GetChild(0);
            go.SetParent(null);
            Destroy(go.gameObject);
        }
        //Update player stars icons
        for (int i = 0; i < PlayerManager.playerInstance.m_playerStarsToCircle.Values.ToList().Count; i++)
        {
            PlayerManager.playerInstance.m_playerStarsToCircle.Values.ToList()[i].SetActive(false);
        }
        resetGalaxyButton.gameObject.SetActive(true);
        destroyGalaxyButton.gameObject.SetActive(false);

    }
}