using System.Collections;
using UnityEngine;

public abstract class TowerBase : MonoBehaviour, ISelectable
{
    protected Player player;
    private Camera mainCamera;

    protected int constructionTime;
    protected float troopRegenerationSpeed;
    protected float troopRegenerationTimer;
    protected int troopAmount;

    private bool isSelected = false;
    private bool isDragging = false;
    private bool isDragEnabled = false;

    private Vector3 initialMousePosition;
    private float dragThreshold = 1.0f;

    protected void InitTowerBase()
    {
        InitTowerBase(Camera.main, 0, 0, 0, 0);
    }

    protected void InitTowerBase(int constructionTime, float troopRegenerationSpeed, float troopRegenerationTimer, int troopAmount)
    {
        InitTowerBase(Camera.main, constructionTime, troopRegenerationSpeed, troopRegenerationTimer, troopAmount);
    }

    protected void InitTowerBase(Camera mainCamera, int constructionTime, float troopRegenerationSpeed, float troopRegenerationTimer, int troopAmount)
    {
        this.mainCamera = mainCamera;
        this.constructionTime = constructionTime;
        this.troopRegenerationSpeed = troopRegenerationSpeed;
        this.troopRegenerationTimer = troopRegenerationTimer;
        this.troopAmount = troopAmount;
    }

    /// <summary>
    /// 병력 생산을 담당하는 코루틴 함수다.
    /// troopRegenerationSpeed가 1일때 0.8초마다 병력을 1만큼 생산한다. => 1.25 unit/sec.
    /// 사전에 troopRegenerationTimer를 설정해야하며 troopRegenerationSpeed와 반비례한다.
    /// </summary>
    protected IEnumerator RegenerateTroop()
    {
        while (true)
        {
            yield return new WaitForSeconds(troopRegenerationTimer);
            troopAmount += 1;
            //Debug.Log(this.troopAmount);
        }
    }

    /// <summary>
    /// 마우스의 월드 좌표를 반환한다.
    /// </summary>
    protected Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 0f; // 2D이므로 Z축을 0으로 설정
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    /// <summary>
    /// 타워가 클릭됐을때 행동 제어용 함수.
    /// </summary>
    protected void HandleObjectClickEvent()
    {
        if (Input.GetMouseButtonUp(0))
        {
            if (isDragEnabled && !isDragging)
            {
                isSelected = true;
                Debug.Log("Object is selected");
            }
            //TODO 만약 드래그 도중이었고 놓았을 때 타워 혹은 빈 땅을 가리키고 있었다면 해당 위치로 유닛을 보내는 함수 호출 (Player).
            else if (isDragging)
            {
                Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

                if (hit.collider != null && (hit.transform.CompareTag("Tower") || hit.transform.CompareTag("EmptyLand")))
                {
                    this.player.MoveUnit(this.gameObject, hit.transform.gameObject);
                }
            }
            isDragging = false;
            isDragEnabled = false;
        }
        else if (isDragEnabled && !isDragging)
        {
            Vector3 currentMousePosition = GetMouseWorldPosition();
            if (Vector3.Distance(initialMousePosition, currentMousePosition) > dragThreshold)
            {
                isDragging = true;
                Debug.Log("Object is being dragged");
            }
        }
    }

    public int GetTroopAmount()
    {
        return this.troopAmount;
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }

    //ISelectable로 부터 상속받음
    public void OnObjectClicked()
    {
        //TODO 클릭된 오브젝트의 소유권이 현재 플레이어에게 있는지 확인. 소유권이 있다면 아래 로직 수행. 없으면 무시
        initialMousePosition = GetMouseWorldPosition();
        isDragEnabled = true;
    }

    public void ClearSelection()
    {
        isSelected = false;
        isDragging = false;
        isDragEnabled = false;
    }
}
