using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum E_WEAPON_TYPE
{
	//Shell damage
	RailGun_1 = 0,
	RailGun_2,
	RailGun_3,

	//Shield damage
	PlasmaGun_1,
	PlasmaGun_2,
	PlasmaGun_3,
	
	//Both type damage
	BeamGun_1,
	BeamGun_2,
	BeamGun_3,
	E_WeaponTypeNumber
}

public class CWeaponStats
{
	public int m_shellDamage;
	public int m_shielDamage;

	public CWeaponStats(E_WEAPON_TYPE type)
	{
		switch(type)
		{
			case E_WEAPON_TYPE.RailGun_1:
				{
					m_shellDamage = 10;
					m_shielDamage = 0;
					break;
				}
			case E_WEAPON_TYPE.RailGun_2:
				{
					m_shellDamage = 20;
					m_shielDamage = 0;
					break;
				}	
			case E_WEAPON_TYPE.RailGun_3:
				{
					m_shellDamage = 30;
					m_shielDamage = 0;
					break;
				}

			case E_WEAPON_TYPE.PlasmaGun_1:
				{
					m_shellDamage = 0;
					m_shielDamage = 10;
					break;
				}
			case E_WEAPON_TYPE.PlasmaGun_2:
				{
					m_shellDamage = 0;
					m_shielDamage = 20;
					break;
				}	
			case E_WEAPON_TYPE.PlasmaGun_3:
				{
					m_shellDamage = 0;
					m_shielDamage = 30;
					break;
				}

			case E_WEAPON_TYPE.BeamGun_1:
				{
					m_shellDamage = 5;
					m_shielDamage = 5;
					break;
				}
			case E_WEAPON_TYPE.BeamGun_2:
				{
					m_shellDamage = 10;
					m_shielDamage = 10;
					break;
				}	
			case E_WEAPON_TYPE.BeamGun_3:
				{
					m_shellDamage = 15;
					m_shielDamage = 15;
					break;
				}
		}
	}
}

public class CWeapon
{
	public E_WEAPON_TYPE m_weaponType;
	public string m_weaponName;

	public CWeaponStats m_weaponStats;

	public CShip m_parentShip;

	public CWeapon(CShip parentShip,E_WEAPON_TYPE type)
	{
		m_weaponName = "Weapon_" + parentShip.m_shipStats.weaponAttachement + "_" + type.ToString();
		m_parentShip = parentShip;
		m_weaponType = type;

		m_weaponStats = new CWeaponStats(type);
	}

	public void ComputeWeaponDamage(CShip target,CWeapon weapon)
	{
		//Shields first
		if(target.m_shipStats.shield > 0)
		{
			target.m_shipStats.shield -= weapon.m_weaponStats.m_shielDamage;
			if(target.m_shipStats.shield < 0)
				target.m_shipStats.shield = 0;
		}
		//if shields are off, shell can be damaged
		if(target.m_shipStats.shield <= 0 && target.m_shipStats.shell > 0 )
		{
			target.m_shipStats.shell  -= weapon.m_weaponStats.m_shellDamage;
		}
		target.CheckDestruction();			
	}
}