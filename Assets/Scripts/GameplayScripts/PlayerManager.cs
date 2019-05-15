using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager playerInstance;

    public List<CStar> m_playerStarList;
    public List<CColony> m_playerColonyList;


    public Canvas m_playerColonyCanva;

    void OnEnable()
    {
        playerInstance = this;    
    }

    // Start is called before the first frame update
    void Start()
    {
        m_playerStarList = new List<CStar>();
        m_playerColonyList = new List<CColony>();
        m_playerColonyCanva.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(mouseRay, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                CStar m_star = GalaxyManager.galaxyInstance.returnStarFromGameobject(hit.transform.gameObject);
                if(m_star != null)
                {
                    if(m_star.m_parentFaction == E_FACTION.E_PLAYER)
                    {
                        m_playerColonyCanva.gameObject.SetActive(true);
                        UpdateCanvaInfos();
                    }
                }
                    
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
                m_playerColonyCanva.gameObject.SetActive(false);
        }
    }

    void UpdateCanvaInfos()
    {
        Text[] colonyInfoTxt = m_playerColonyCanva.GetComponentsInChildren<Text>();

        for(int index = 0 ; index < colonyInfoTxt.Length; index++)
        {
            if (colonyInfoTxt[index].name == "ColonyList")
            {
                colonyInfoTxt[index].text = "TODO"; 
                break;
            }
                
        }
        
    }
}
