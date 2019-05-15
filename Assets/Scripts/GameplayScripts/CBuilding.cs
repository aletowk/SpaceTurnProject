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


    public CBuilding(E_BUILDING_TYPES buildType)
    {

    }
    

    public void ComputeBuildingTask()
    {
        // todo
    }
}
