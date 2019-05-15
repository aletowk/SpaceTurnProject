using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CPlayer
{
    public CStats m_playerStatistics = new CStats();
    public List<CSkill> m_playerSkills;

    public float m_movingPoints; // in distance units
    public int m_remainingActionPoints;
    public int m_skillPoints;

    public float m_targetDistance;

    public void initPlayerLevelOne()
    {
        m_playerStatistics.statLevelOne();
        m_movingPoints = 100;
    }
}

public class CStats
{
    public int m_level;
    public int m_experience;
    public int m_health;
    public int m_shell;
    public int m_shield;
    public int m_strength;
    public int m_agility;

    public void statLevelOne()
    {
        m_level = 1;
        m_experience = 0;
        m_health = 100;
        m_shell = 50;
        m_shield = 50;
        m_strength = 10;
        m_agility = 10;
    }
    public string printStats()
    {
        string toReturn;
        toReturn =                        string.Concat("Level       : ", m_level,"\n");
        toReturn = string.Concat(toReturn,string.Concat("XP          : ",m_experience,"\n"));
        toReturn = string.Concat(toReturn,string.Concat("Health      : ", m_health, "\n"));
        toReturn = string.Concat(toReturn,string.Concat("Shell       : ", m_shell, "\n"));
        toReturn = string.Concat(toReturn,string.Concat("Shield      : ", m_shield, "\n"));
        toReturn = string.Concat(toReturn,string.Concat("Strength    : ", m_strength, "\n"));
        toReturn = string.Concat(toReturn, string.Concat("Agility    : ", m_agility, "\n"));
        return toReturn;
    }
}

public class CSkill
{
    //TODO
}

public class CTurnManager
{

}

public class OLD_PlayerManager : MonoBehaviour
{
    public CPlayer m_playerEntity = new CPlayer();
    public GameObject m_playerGameObject;
    public CTurnManager m_turnManager;

    public float tmpSpeed = 10f;


    // Attributes wrt moving the GameObjet
    private Vector3 targetPosition;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        isMoving = false;
        m_playerEntity.initPlayerLevelOne();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    private void movePlayer()
    {
        if (Input.GetMouseButton(0))
            SetTargetPosition();

        if (isMoving)
            moving();
    }



    private void MovingPlayerState()
    {

    }
    private void UpdatingCombat()
    {

    }
    private void UpdateGUI()
    {

    }

    private void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;
        if (plane.Raycast(ray, out point))
        {
            targetPosition = ray.GetPoint(point);
            m_playerEntity.m_targetDistance = (targetPosition - transform.position).magnitude;
        }
        if(true)//m_playerEntity.m_targetDistance < m_playerEntity.m_movingPoints)
        {
            isMoving = true;
            m_playerEntity.m_movingPoints -= m_playerEntity.m_targetDistance;
        }
            
    }
    private void moving()
    {
        transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, tmpSpeed * Time.deltaTime);
        if (transform.position == targetPosition)
        {
            isMoving = false;
            m_playerEntity.m_targetDistance = 0f;
        }
            
    }
}
