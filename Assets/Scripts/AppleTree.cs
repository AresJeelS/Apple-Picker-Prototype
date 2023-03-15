using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleTree : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameObject ApplePrefab;

    public float Speed = 1f;
    public float LeftAndRightEdge = 10f;
    public float ChanceToChangeDirections = 0.1f;
    public float SecondsBetweenAppleDrops = 1f;

    private void Start()
    {
        Invoke(nameof(DropApple), 2f);
    }
    private void Update()
    {
        Vector3 pos = transform.position;
        pos.x += Speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -LeftAndRightEdge)
        {
            Speed = Mathf.Abs(Speed);
        }
        else if (pos.x > LeftAndRightEdge)
        {
            Speed = -Mathf.Abs(Speed);

        }

    }
    private void FixedUpdate()
    {
        if (Random.value < ChanceToChangeDirections) 
        {
            Speed *= -1;
        }
    }

    private void DropApple()
    {
        GameObject apple = Instantiate(ApplePrefab);
        apple.transform.position = transform.position;
        Invoke(nameof(DropApple), SecondsBetweenAppleDrops);
    }

}
