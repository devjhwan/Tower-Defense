using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanHeadQuater : TowerBase
{
    // Start is called before the first frame update
    void Start()
    {
        //���� �ǹ��� ���� ���� ������ �̹� �Ǽ��Ǿ� ������ ���� �� �� ������ �� �ϳ��� ������.
        //���� ���� �ӵ��� �Ϲ� Ÿ������ 2�� ������.
        //�⺻ 0.8��
        //���δ� 15������ �����Ѵ�.
        InitTowerBase(0, 2.0f, 0.8f, 15);
        StartCoroutine(RegenerateTroop());
    }

    void Update()
    {
        HandleObjectClickEvent();
    }
}
