using System.Collections;
using System.Collections.Generic;

public class HeadQuater : TowerBase
{
    // Start is called before the first frame update
    void Start()
    {
        this.constructionTime = 0; //���� �ǹ��� ���� ���� ������ �̹� �Ǽ��Ǿ� ������ ���� �� �� ������ �� �ϳ��� ������.
        this.troopRegenerationSpeed = 2; //���� ���� �ӵ��� �Ϲ� Ÿ������ 2�� ������.
        this.troopRegenerationTimer = 0.8f; //�⺻ 0.8��
        this.troopAmount = 15; //���δ� 15������ �����Ѵ�.

        StartCoroutine(RegenerateTroop());
    }
}
