using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanHeadQuater : TowerBase
{
    // Start is called before the first frame update
    void Start()
    {
        //본부 건물은 게임 시작 시점에 이미 건설되어 있으며 게임 중 각 진영당 단 하나만 존재함.
        //병력 생산 속도가 일반 타워보다 2배 빠르다.
        //기본 0.8초
        //본부는 15명으로 시작한다.
        InitTowerBase(0, 2.0f, 0.8f, 15);
        StartCoroutine(RegenerateTroop());
    }

    void Update()
    {
        HandleObjectClickEvent();
    }
}
