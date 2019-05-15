using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum E_StarType
{
    E_BLUE_GIANT = 0,
    E_YELLOW_DWARF,

    E_STAR_TYPE_NB
}

public enum E_FACTION
{
    E_NONE,
    E_ENEMY,
    E_PLAYER,

    E_NB_FACTION
}

public class CStar 
{
    public string m_starName;
    public float m_starSize;
    public E_StarType m_starType;
    public Vector3 m_starPosition;

    public int m_planetNumber;
    public List<CPlanet> m_planetList;


    public E_FACTION m_parentFaction;

    public bool m_starSelected;

    public CStar(string name, float size, int type, Vector3 position, int planetNumber, E_FACTION faction)
    {
        m_starName = name;
        m_starSize = size;
        m_starType = (E_StarType) type;
        m_starPosition = position;
        m_planetNumber = planetNumber;
        m_planetList = new List<CPlanet>();
        m_parentFaction = faction;
        CreatePlanetsData();
    }
    public void PrintStarInfo()
    {
        string toPrint;
        toPrint = "Star name : " + m_starName +"\n" +
                  "Star type : " + m_starType +"\n" +
                  "Star size : " + m_starSize + "\n" +
                  "Planet nb : " + m_planetNumber + "\n" +
                  "Star pos  : " + m_starPosition.ToString() + "\n";
        Debug.Log(toPrint);
    }
    public void PrintPlanetsAroundStar()
    {
        string toPrint;
        Debug.Log("Planets for Star " + m_starName);
        for(int i = 0; i < m_planetList.Count; i++)
        {
            toPrint = "Name :" + m_planetList[i].m_planetName + "\n" +
                      "Type :" + m_planetList[i].m_planetType + "\n" +
                      "Pos :" + m_planetList[i].m_planetPosition + "\n";
            Debug.Log(toPrint);
        }
        Debug.Log("End of planets for Star " + m_starName);

    }
    public void CreatePlanetsData()
    {
        CPlanet tmpPlanet;
        int randomType;
        float distance;
        float angle;
        float scale;
        Vector3 position;
        for(int i = 0; i < m_planetNumber; i++)
        {
            //randomType =(int)Mathf.Round(UnityEngine.Random.Range((float)E_PLANET_TYPE.E_BARREN,
            //                                                      (float)E_PLANET_TYPE.E_NB_PLANET_TYPE - 1.55f));
            randomType = planetTypeComputing();
            distance = (float) (cst.E_MINIMAL_PLANET_DISTANCE + (int)cst.E_DISTANCE_BETWEEN_PLANETS * i);
            angle = UnityEngine.Random.Range(0f, 2 * Mathf.PI);

            scale = 1f;

            position = new Vector3(distance * Mathf.Cos(angle), 0, distance * Mathf.Sin(angle));

            tmpPlanet = new CPlanet(this,m_starName+"_"+ i, (E_PLANET_TYPE) randomType, scale, position);

            m_planetList.Add(tmpPlanet);
        }
    }

    int planetTypeComputing()
    {
        int type = (int)Mathf.Round((int)UnityEngine.Random.Range(1,100));
        if (type >= 1 && type < 10)
            type = (int)E_PLANET_TYPE.E_LUSH;
        else if (type >= 10 && type < 50)
            type = (int)E_PLANET_TYPE.E_GAS_GIANT;
        else
            type = (int)E_PLANET_TYPE.E_BARREN;
        return type;
    }
}
