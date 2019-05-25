using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_EQUIPMENT_TYPE
{
	ShellEnhancer_1 = 0,
	ShellEnhancer_2,
	ShellEnhancer_3,

	ShieldEnhancer_1,
	ShieldEnhancer_2,
	ShieldEnhancer_3,

	//More later
	E_EquipmentTypeNumber
}

public class CEquipment
{
	public string m_equipmentName;
	public E_EQUIPMENT_TYPE m_equipmentType;
	public CShip m_parentShip;

	public CEquipment(CShip ship, E_EQUIPMENT_TYPE type)
	{
		m_equipmentName = "Equipment_" + ship.m_shipStats.equipmentAttachement +
						  "_" + type.ToString();
		m_equipmentType = type;

		m_parentShip = ship;
		//todo
	}

	public void ApplyEquipment(CShip ship)
	{
		//todo
	}
}