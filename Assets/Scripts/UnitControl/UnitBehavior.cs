using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBehavior : MonoBehaviour
{
    private Player player;

    private bool isMoving = false;
    private float speed;
    private Vector3 moveDir;
    private GameObject destination;
    // Start is called before the first frame update
    void Start()
    {
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            this.transform.position += moveDir * speed * Time.deltaTime;
        }
    }

    public void MoveToObject(GameObject target)
    {
        isMoving = true;
        moveDir = Vector3.Normalize(target.transform.position - this.transform.position);
        destination = target;
    }

    public void StopMoving()
    {
        isMoving = false;
        moveDir = Vector3.zero;
        destination = null;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.gameObject == this.destination && 
            Vector3.Distance(this.transform.position, this.destination.transform.position) < 0.1)
            StopMoving();
    }

    public void SetPlayer(Player player)
    {
        this.player = player;
    }
}
