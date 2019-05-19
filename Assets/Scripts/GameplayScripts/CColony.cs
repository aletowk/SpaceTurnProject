using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CColony 
{
    public List<CBuilding> m_buildingList;
    public CPlanet m_parentPlanet;

    public CResources m_planetResources; 

    public CColony(CPlanet parent)
    {
        m_buildingList = new List<CBuilding>();
        m_parentPlanet = parent;
    }

    public void CreateBuilding(E_BUILDING_TYPES type)
    {
        CBuilding build = new CBuilding(type);
        m_buildingList.Add(build);
    }
}
