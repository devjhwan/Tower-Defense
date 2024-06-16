public interface ISelectable
{
    /// <summary>
    /// 선택 가능한 오브젝트에 연결할 클래스의 인터페이스.
    /// 오브젝트 선택시 수행할 작업에 대한 함수이다.
    /// </summary>
    public void OnObjectClicked();

    /// <summary>
    /// 클릭 상태를 초기화 하는 함수다.
    /// </summary>
    public void ClearSelection();
}
