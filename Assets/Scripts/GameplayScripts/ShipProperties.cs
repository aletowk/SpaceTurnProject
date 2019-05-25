using System.Collections;
using System.Collections.Generic;

public static class ShipProperties
{
	//Shell:
	public static int FighterInitShell 		= 100;
	public static int BattleShipInitShell 		= 200;
	public static int FrigateInitShell 		= 200;
	public static int CarrierInitShell 		= 300;
	public static int CruiserInitShell 		= 500;

	//Shield:
	public static int FighterInitShield 		= 50;
	public static int BattleShipInitShield 	= 100;
	public static int FrigateInitShield 		= 150;
	public static int CarrierInitShield 		= 200;
	public static int CruiserInitShield 		= 300;

	//Fuel
	public static int FighterInitFuel 			= 1000;
	public static int BattleShipInitFuel 		= 2000;
	public static int FrigateInitFuel 			= 3000;
	public static int CarrierInitFuel 			= 4000;
	public static int CruiserInitFuel 			= 10000;

	//Distance per turn (in unity units)
	public static int FighterInitDistance 		= 10;
	public static int BattleShipInitDistance 	= 15;
	public static int FrigateInitDistance 		= 10;
	public static int CarrierInitDistance 		= 15;
	public static int CruiserInitDistance 		= 25;

	//Weapons
	public static int FighterInitWeapons 		= 3;
	public static int BattleShipInitWeapons 	= 6;
	public static int FrigateInitWeapons 		= 1;
	public static int CarrierInitWeapons 		= 2;
	public static int CruiserInitWeapons 		= 10;

	//Equipment
	public static int FighterInitEquipment 	= 1;
	public static int BattleShipInitEquipment 	= 2;
	public static int FrigateInitEquipment 	= 1;
	public static int CarrierInitEquipment 	= 2;
	public static int CruiserInitEquipment 	= 5;

	//Cargo bay
	public static int FighterInitCargo 		= 5;
	public static int BattleShipInitCargo 		= 8;
	public static int FrigateInitCargo 		= 15;
	public static int CarrierInitCargo 		= 25;
	public static int CruiserInitCargo 		= 50;
}
