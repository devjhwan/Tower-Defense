using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private HumanUnitFactory unitFactory;
    public GameObject test1;
    // Start is called before the first frame update
    void Start()
    {
        unitFactory = HumanUnitFactory.GetInstance();
        MoveUnit(test1, null);
    }

    public void MoveUnit(GameObject A, GameObject B)
    {
        GameObject prefabUnit = unitFactory.CreateUnit("Unit1");
        if (prefabUnit != null)
        {
            GameObject unit = Instantiate(prefabUnit);
            unit.transform.position = A.transform.position;
            unit.transform.parent = this.transform.Find("Units");
            unit.transform.position += Vector3.right;
        }
    }
}
