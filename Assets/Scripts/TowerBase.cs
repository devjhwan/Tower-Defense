using System.Collections;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    protected int constructionTime;
    protected float troopRegenerationSpeed;
    protected float troopRegenerationTimer;
    protected int troopAmount;

    /**
     * 병력 생산을 담당하는 코루틴 함수다.
     * troopRegenerationSpeed가 1일때 0.8초마다 병력을 1만큼 생산한다. => 1.25 unit/sec
     * 사전에 troopRegenerationTimer를 설정해야하며 troopRegenerationSpeed와 반비례한다.
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
