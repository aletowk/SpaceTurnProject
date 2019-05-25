using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CFleet
{
	public E_FACTION m_parentFaction;

	Dictionary<CShip, GameObject> shipToGameObject;
	public List<CShip> m_shipList;

	public CFleet(E_FACTION faction)
	{
        m_parentFaction = faction;
		m_shipList = new List<CShip>();
		shipToGameObject = new Dictionary<CShip,GameObject>();
	}
	// Ship creation in colony manager, definition of functions
	// in UIManager
	public void AddShip(CShip ship)
	{
		m_shipList.Add(ship);
		shipToGameObject.Add(ship,ship.m_shipGameObject);
	}
	public void RemoveShip(CShip shipToRemove)
	{
		//Remove it from list
	}
}