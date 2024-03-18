using UnityEngine;

public class Bullet : MonoBehaviour
{
    // 총알 이동 속도
    public float speed = 10f;

    // 총알 이동 방향 (오른쪽으로 고정)
    private Vector3 direction = Vector3.right;

    void FixedUpdate()
    {
        // 총알을 이동 방향으로 이동
        transform.Translate(direction * speed * Time.fixedDeltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        // 총알이 빨간 큐브와 충돌하면
        if (other.CompareTag("RedCube"))
        {
            // 총알 제거
            Destroy(gameObject);
        }
    }
}