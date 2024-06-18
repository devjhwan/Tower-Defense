using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private ITowerFactory towerFactory;
    private IUnitFactory unitFactory;
    // Start is called before the first frame update
    void Start()
    {
        towerFactory = HumanTowerFactory.GetInstance();
        unitFactory = HumanUnitFactory.GetInstance();
    }

    public void MoveUnit(GameObject A, GameObject B)
    {
        GameObject prefabUnit = unitFactory.CreateUnit("Unit1");
        if (prefabUnit != null)
        {
            GameObject unit = Instantiate(prefabUnit);
            unit.transform.position = A.transform.position;
            unit.transform.parent = this.transform.Find("Units");
            UnitBehavior unitBehavior = (UnitBehavior)unit.GetComponent(typeof(UnitBehavior));
            unitBehavior.MoveToObject(B);
            unitBehavior.SetPlayer(this);
        }
    }

    public void CreateTower(GameObject target)
    {
        GameObject prefabTower = towerFactory.CreateTower("HeadQuater");
        if (prefabTower != null)
        {
            GameObject tower = Instantiate(prefabTower);
            tower.transform.position = target.transform.position;
            tower.transform.parent = this.transform.Find("Towers");
            tower.GetComponent<ObjectOwner>().player = this.GetComponent<ObjectOwner>().player;
            TowerBase towerBase = (TowerBase)tower.GetComponent(typeof(TowerBase));
            towerBase.SetPlayer(this);
            Destroy(target);
        }
    }
}
