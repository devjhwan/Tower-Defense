using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanTowerFactory : ITowerFactory
{
    private static HumanTowerFactory instance = null;
    private Dictionary<string, GameObject> towerPrefabMap;

    public static HumanTowerFactory GetInstance()
    {
        if (instance == null)
            instance = new HumanTowerFactory();
        return instance;
    }

    private HumanTowerFactory()
    {
        towerPrefabMap = new Dictionary<string, GameObject>();
        GameObject[] towers = Resources.LoadAll<GameObject>("Towers/Human");
        foreach (GameObject tower in towers)
            towerPrefabMap.Add(tower.name, tower);
    }

    public GameObject CreateTower(string type)
    {
        if (towerPrefabMap.ContainsKey(type))
            return towerPrefabMap[type];
        else
            return null;
    }
}
