using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CColony 
{
    public List<CBuilding> m_buildingList;
    public CPlanet m_parentPlanet;

    public CResources m_colonyResources; 

    public CColony(CPlanet parent)
    {
        m_buildingList = new List<CBuilding>();
        m_parentPlanet = parent;
        InitColonyResources();
    }
    public void InitColonyResources()
    {
        m_colonyResources = new CResources();
        m_colonyResources.InitColony();
    }
    public void CreateBuilding(E_BUILDING_TYPES type)
    {
        CBuilding build = new CBuilding(type);
        m_buildingList.Add(build);
    }
    public bool CheckResourcesToConstruct(E_BUILDING_TYPES type)
    {
        switch(type)
        {
            // Farm :: 5 food et 5 metal
            case E_BUILDING_TYPES.E_FARM:
                {
                    if( m_colonyResources.m_foodAmount - 5 <=0 || m_colonyResources.m_metalAmount - 5 <=0 )
                    {
                        return false;
                    }
                    else
                    {
                        m_colonyResources.m_foodAmount -= 5;
                        m_colonyResources.m_metalAmount -= 5;
                        return true;
                    }
                }
        }
        return false;
    }
}
