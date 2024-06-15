using System.Collections;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    protected int constructionTime;
    protected float troopRegenerationSpeed;
    protected float troopRegenerationTimer;
    protected int troopAmount;

    /**
     * ���� ������ ����ϴ� �ڷ�ƾ �Լ���.
     * troopRegenerationSpeed�� 1�϶� 0.8�ʸ��� ������ 1��ŭ �����Ѵ�. => 1.25 unit/sec
     * ������ troopRegenerationTimer�� �����ؾ��ϸ� troopRegenerationSpeed�� �ݺ���Ѵ�.
     */
    protected IEnumerator RegenerateTroop()
    {
        while (true)
        {
            yield return new WaitForSeconds(troopRegenerationTimer);
            troopAmount += 1;
            Debug.Log(this.troopAmount);
        }
    }
}
