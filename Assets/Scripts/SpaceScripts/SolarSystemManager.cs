using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SolarSystemManager : MonoBehaviour
{
    public static SolarSystemManager m_solarSystemInstance;
    Dictionary<CPlanet, GameObject> m_planetToGameObject;
    Dictionary<CStar, GameObject> m_centralStarToGameObject;
    public bool solarSystemViewActive;

    public Text infoText;

    public CStar m_star;

    void OnEnable()
    {
        m_solarSystemInstance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        solarSystemViewActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();
        if (Physics.Raycast(mouseRay, out hit) )
        {
            GalaxyManager.galaxyInstance.MoveSelectionIcon(hit);
            // Entering from galaxy view to solar system view 
            if (Input.GetMouseButtonDown(1) && !solarSystemViewActive)
            {
                m_star = GalaxyManager.galaxyInstance.returnStarFromGameobject(hit.transform.gameObject);
                if (m_star != null)
                {
                    GalaxyManager.galaxyInstance.DestroyGalaxy();
                    CreateSolarSystem();
                }

            }
            else if (Input.GetMouseButtonDown(0) && solarSystemViewActive)
            {
                CPlanet planet = returnPlanetFromGameObject(hit.transform.gameObject);
                if (planet != null)
                {
                    infoText.text = "Selected Planet     : \n" +
                                    "Planet Name         : " + planet.m_planetName + "\n" +
                                    "Planet Type         : " + planet.m_planetType + "\n" +
                                    "Position            : " + planet.m_planetPosition.ToString() + "\n";
                }
                else if(m_centralStarToGameObject.Values.ToList().IndexOf(hit.transform.gameObject) != -1)
                {
                    infoText.text = "Star of the solar system    : \n" +
                                    "Name         : " + m_star.m_starName + "\n" +
                                    "Type         : " + m_star.m_starType + "\n";
                }
            }
        }
        else
            GalaxyManager.galaxyInstance.selectionIcon.SetActive(false);
    }

    void CreateSolarSystem()
    {
        m_planetToGameObject = new Dictionary<CPlanet, GameObject>();
        m_centralStarToGameObject = new Dictionary<CStar, GameObject>();
        InstanciateStar();

        for(int i = 0; i < m_star.m_planetNumber; i++)
        {
            GameObject instance = Instantiate(Resources.Load(Constantes.prefab_planet_names[(int)m_star.m_planetList[i].m_planetType])) as GameObject;
            instance.transform.SetParent(this.transform);

            instance.transform.position = m_star.m_planetList[i].m_planetPosition;
            instance.transform.localScale = new Vector3(m_star.m_planetList[i].m_planetSize,
                                                        m_star.m_planetList[i].m_planetSize,
                                                        m_star.m_planetList[i].m_planetSize);
            m_planetToGameObject.Add(m_star.m_planetList[i], instance);
        }
        solarSystemViewActive = true;
    }

    public CPlanet returnPlanetFromGameObject(GameObject go)
    {
        int index;
        if ((index = m_planetToGameObject.Values.ToList().IndexOf(go)) != -1)
            return m_planetToGameObject.Keys.ToList()[index];
        else
            return null;
    }

    void InstanciateStar()
    {
        GameObject instance = Instantiate(Resources.Load(Constantes.prefab_names[(int)m_star.m_starType])) as GameObject;
        instance.transform.SetParent(this.transform);
        instance.transform.position = Vector3.zero;
        instance.transform.localScale = new Vector3(1f,1f,1f);
        m_centralStarToGameObject.Add(m_star, instance);
    }
    public void DestroySolarSystem()
    {
        while (transform.childCount > 0)
        {
            Transform go = transform.GetChild(0);
            go.SetParent(null);
            Destroy(go.gameObject);
        }
        solarSystemViewActive = false;
    }
}
