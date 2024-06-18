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
    /// ���� ������ ����ϴ� �ڷ�ƾ �Լ���.
    /// troopRegenerationSpeed�� 1�϶� 0.8�ʸ��� ������ 1��ŭ �����Ѵ�. => 1.25 unit/sec.
    /// ������ troopRegenerationTimer�� �����ؾ��ϸ� troopRegenerationSpeed�� �ݺ���Ѵ�.
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
    /// ���콺�� ���� ��ǥ�� ��ȯ�Ѵ�.
    /// </summary>
    protected Vector3 GetMouseWorldPosition()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = 0f; // 2D�̹Ƿ� Z���� 0���� ����
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }

    /// <summary>
    /// Ÿ���� Ŭ�������� �ൿ ����� �Լ�.
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
            //TODO ���� �巡�� �����̾��� ������ �� Ÿ�� Ȥ�� �� ���� ����Ű�� �־��ٸ� �ش� ��ġ�� ������ ������ �Լ� ȣ�� (Player).
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

    //ISelectable�� ���� ��ӹ���
    public void OnObjectClicked()
    {
        //TODO Ŭ���� ������Ʈ�� �������� ���� �÷��̾�� �ִ��� Ȯ��. �������� �ִٸ� �Ʒ� ���� ����. ������ ����
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
