using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_PLANET_TYPE
{
    E_BARREN = 0,
    E_LUSH, //Earth like
    E_GAS_GIANT,

    E_NB_PLANET_TYPE
}

public class CPlanet
{
    public string m_planetName;
    public E_PLANET_TYPE m_planetType;

    public float m_planetSize;
    public Vector3 m_planetPosition;

    public CStar m_parentStar;

    public CColony m_colony;

    public CPlanet(CStar parent,string name, E_PLANET_TYPE type, float size, Vector3 position)
    {
        m_parentStar = parent;
        m_planetName = name;
        m_planetType = type;
        m_planetSize = size;
        m_planetPosition = position;

        m_colony = null;
    }

}
