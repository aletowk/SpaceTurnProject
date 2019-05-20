using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_BUILDING_TYPES
{
    E_HABITATION,
    E_FARM,
    E_MINE,

    E_ASTROPORT,
    E_SHIPFACTORY,
    E_SCIENCELAB,
    E_NB_BUILDING_TYPES
}


public class CBuilding
{
    public E_BUILDING_TYPES m_buildingType;
    public CColony m_parentColony;

    public CBuilding(E_BUILDING_TYPES buildType)
    {
        m_buildingType = buildType;
    }
    

    public void ComputeBuildingTask()
    {
        switch(m_buildingType)
        {
            case E_BUILDING_TYPES.E_FARM:
                {
                    m_parentColony.m_colonyResources.m_foodAmount += 5;
                    break;
                }
            case E_BUILDING_TYPES.E_MINE:
                {
                    m_parentColony.m_colonyResources.m_metalAmount += 5;
                    break;
                }
            // Other to do !!
        }
    }
}
