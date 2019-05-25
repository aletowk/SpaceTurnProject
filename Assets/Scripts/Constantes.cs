using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum cst
{
    E_MINIMUM_PLANET_NUMBER = 1,
    E_MAXIMUM_PLANET_NUMBER = 4,
    E_MINIMAL_PLANET_DISTANCE = 5,
    E_DISTANCE_BETWEEN_PLANETS = 4
}

public static class Constantes
{
    public static string[] STAR_TYPE_TAB = new string[]
    {
        "Yellow Dwarf",
        "Blue Giant",
        "Unknown"
    };

    public static string prefab_sprite_selection_name = "Prefabs/Sprites/SelectionSprite";
    public static string prefab_sprite_green_circle_name = "Prefabs/UI/GreenCircle";
    public static string[] prefab_names = { "Prefabs/LP_BlueGiantPrefab", "Prefabs/LP_YellowDwarfPrefab" };
    public static string[] prefab_planet_names = {  "Prefabs/Planets/BarrenPrefab_1",
                                                    "Prefabs/Planets/LushPrefab_1",
                                                    "Prefabs/Planets/GasGiantPrefab_1" };
    public static string prefab_green_selection_circle_name = "Prefabs/UI/GreenSelectCirclePrefab";
}