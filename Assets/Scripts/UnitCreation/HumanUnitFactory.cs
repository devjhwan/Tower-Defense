using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanUnitFactory : IUnitFactory
{
    private static HumanUnitFactory instance = null;
    private Dictionary<string, GameObject> unitPrefabMap;

    public static HumanUnitFactory GetInstance()
    {
        if (instance == null)
            instance = new HumanUnitFactory();
        return instance;
    }

    private HumanUnitFactory()
    {
        unitPrefabMap = new Dictionary<string, GameObject>();
        GameObject[] units = Resources.LoadAll<GameObject>("Units/Human");
        foreach (GameObject unit in units)
            unitPrefabMap.Add(unit.name, unit);
    }

    public GameObject CreateUnit(string type)
    {
        if (unitPrefabMap.ContainsKey(type))
            return unitPrefabMap[type];
        else
            return null;
    }
}
