using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_SHIP_TYPE
{
	Figther = 0, // little fighter:
				 // 3 Weapons attachments
				 // Small cargo bay
	BattleShip,  // Bigger fighter:
				 // 6 Weapons attachments
				 // Small cargo bay

	Frigate,	 // Small transport:
				 // 1 Weapon attachment
				 // Medium cargo bay
	Carrier,     // Bigger transport
				 // 2 Weapons attachments
				 // Large cargo bay
	Cruiser,	 // ultime ship
				 // 10 Weapons
	             // Extremly large cargo bay
	E_shipTypeNumber
}

public class CShipStats
{
	public int shell;
	public int maxShell;

	public int shield;
	public int maxShield;

	public int remainingFuel;
	public int maxFuel;

	public float remainingDistanceInTurn;
	public float maxDistancePerTurn;

	public int weaponAttachement;
	public int maxWeapons;

	public int equipmentAttachement;
	public int maxEquipment;

	public int cargoSlotUsed;
	public int maxCargoBay;
	// We assume at creation ship level is 1
	public CShipStats(E_SHIP_TYPE type)
	{
		switch(type)
		{
			case E_SHIP_TYPE.Figther:
				{
                    InitFighterStats();
					break;
				}
			case E_SHIP_TYPE.BattleShip:
				{
                    InitBattleShipStats();
					break;
				}
			case E_SHIP_TYPE.Frigate:
				{
                    InitFrigateStats();
					break;
				}
			case E_SHIP_TYPE.Carrier:
				{
                    InitCarrierStats();
					break;
				}
			case E_SHIP_TYPE.Cruiser:
				{
                    InitCruiserStats();
					break;
				}
		}
	}
	public void InitFighterStats()
	{
		maxShell 			= ShipProperties.FighterInitShell;
		shell 				= maxShell;
		maxShield 			= ShipProperties.FighterInitShield;
		shield 				= maxShield;
		maxFuel				= ShipProperties.FighterInitFuel;
		remainingFuel		= maxFuel;
		maxDistancePerTurn 	= ShipProperties.FighterInitDistance;
		remainingDistanceInTurn = maxDistancePerTurn;
		maxWeapons 			= ShipProperties.FighterInitWeapons;
		weaponAttachement	= 0;
		maxEquipment 		= ShipProperties.FighterInitEquipment;
		equipmentAttachement= 0;
		maxCargoBay 		= ShipProperties.FighterInitCargo;
		cargoSlotUsed       = 0;
	}
	public void InitBattleShipStats()
	{
		maxShell 			= ShipProperties.BattleShipInitShell;
		shell 				= maxShell;
		maxShield 			= ShipProperties.BattleShipInitShield;
		shield 				= maxShield;
		maxFuel				= ShipProperties.BattleShipInitFuel;
		remainingFuel		= maxFuel;
		maxDistancePerTurn 	= ShipProperties.BattleShipInitDistance;
		remainingDistanceInTurn = maxDistancePerTurn;
		maxWeapons 			= ShipProperties.BattleShipInitWeapons;
		weaponAttachement	= 0;
		maxEquipment 		= ShipProperties.BattleShipInitEquipment;
		equipmentAttachement= 0;
		maxCargoBay 		= ShipProperties.BattleShipInitCargo;
		cargoSlotUsed       = 0;
	}
	public void InitFrigateStats()
	{
		maxShell 			= ShipProperties.FrigateInitShell;
		shell 				= maxShell;
		maxShield 			= ShipProperties.FrigateInitShield;
		shield 				= maxShield;
		maxFuel				= ShipProperties.FrigateInitFuel;
		remainingFuel		= maxFuel;
		maxDistancePerTurn 	= ShipProperties.FrigateInitDistance;
		remainingDistanceInTurn = maxDistancePerTurn;
		maxWeapons 			= ShipProperties.FrigateInitWeapons;
		weaponAttachement	= 0;
		maxEquipment 		= ShipProperties.FrigateInitEquipment;
		equipmentAttachement= 0;
		maxCargoBay 		= ShipProperties.FrigateInitCargo;
		cargoSlotUsed       = 0;
	}
	public void InitCarrierStats()
	{
		maxShell 			= ShipProperties.CarrierInitShell;
		shell 				= maxShell;
		maxShield 			= ShipProperties.CarrierInitShield;
		shield 				= maxShield;
		maxFuel				= ShipProperties.CarrierInitFuel;
		remainingFuel		= maxFuel;
		maxDistancePerTurn 	= ShipProperties.CarrierInitDistance;
		remainingDistanceInTurn = maxDistancePerTurn;
		maxWeapons 			= ShipProperties.CarrierInitWeapons;
		weaponAttachement	= 0;
		maxEquipment 		= ShipProperties.CarrierInitEquipment;
		equipmentAttachement= 0;
		maxCargoBay 		= ShipProperties.CarrierInitCargo;
		cargoSlotUsed       = 0;
	}
	public void InitCruiserStats()
	{
		maxShell 			= ShipProperties.CruiserInitShell;
		shell 				= maxShell;
		maxShield 			= ShipProperties.CruiserInitShield;
		shield 				= maxShield;
		maxFuel				= ShipProperties.CruiserInitFuel;
		remainingFuel		= maxFuel;
		maxDistancePerTurn 	= ShipProperties.CruiserInitDistance;
		remainingDistanceInTurn = maxDistancePerTurn;
		maxWeapons 			= ShipProperties.CruiserInitWeapons;
		weaponAttachement	= 0;
		maxEquipment 		= ShipProperties.CruiserInitEquipment;
		equipmentAttachement= 0;
		maxCargoBay 		= ShipProperties.CruiserInitCargo;
		cargoSlotUsed       = 0;
	}
}

public class CShip
{
	public string m_shipName;
	public int m_shipLevel;
	public CShipStats m_shipStats;

	public List<CWeapon> m_weaponList;
	public List<CEquipment> m_equipmentList;

	public GameObject m_shipGameObject;

	public CFleet m_parentFleet;

	public bool shipInAstroport;

	public bool shipSelected;


	public CShip(int indexInFleet,E_SHIP_TYPE type)
	{
		m_shipName = "Ship_" + indexInFleet.ToString() + "_" + type.ToString();
		m_shipLevel = 1;

		m_weaponList = new List<CWeapon>();
		m_shipStats.weaponAttachement = 0;
		m_equipmentList = new List<CEquipment>();
		m_shipStats.equipmentAttachement = 0;

		m_shipStats = new CShipStats(type);
	}

	public void AddWeapon(E_WEAPON_TYPE type)
	{
		if(m_shipStats.weaponAttachement < m_shipStats.maxWeapons)
		{
			CWeapon weapon = new CWeapon(this,type);
			m_shipStats.weaponAttachement++;
			m_weaponList.Add(weapon);
		}else
		{
			Debug.Log("Add weapon impossible, ship can only have "+
					  m_shipStats.maxWeapons);
		}
	}
	public void AddEquipment(E_EQUIPMENT_TYPE type)
	{
		if( m_shipStats.equipmentAttachement < m_shipStats.maxEquipment)
		{
			CEquipment equip = new CEquipment(this,type);
			m_shipStats.equipmentAttachement++;
			m_equipmentList.Add(equip);
			equip.ApplyEquipment(this);	
		}else
		{
			Debug.Log("Add weapon impossible, ship can only have "+
					  m_shipStats.maxWeapons);
		}
	}
	public void InstantiateShip(Vector3 position)
	{
		GameObject instance = null; // to complete with prefab
        GameObject playerGO = GameObject.FindGameObjectWithTag("PlayerManagerTag");
		instance.transform.SetParent(playerGO.transform);
		
		instance.transform.position = position;

		m_shipGameObject = instance;
	}

	public void SetActive(bool param)
	{
		if(m_shipGameObject!=null)
			m_shipGameObject.SetActive(param);
	}

	public void CheckDestruction()
	{
		//if shell is 0 ==> ship must be destroyed
		if(m_shipStats.shell <= 0)
		{
			//Destroy(m_shipGameObject);
			m_parentFleet.RemoveShip(this);
		}
	}
}