using UnityEngine;

public class Bullet : MonoBehaviour
{
    // �Ѿ� �̵� �ӵ�
    public float speed = 10f;

    // �Ѿ� �̵� ���� (���������� ����)
    private Vector3 direction = Vector3.right;

    void FixedUpdate()
    {
        // �Ѿ��� �̵� �������� �̵�
        transform.Translate(direction * speed * Time.fixedDeltaTime, Space.World);
    }

    void OnTriggerEnter(Collider other)
    {
        // �Ѿ��� ���� ť��� �浹�ϸ�
        if (other.CompareTag("RedCube"))
        {
            // �Ѿ� ����
            Destroy(gameObject);
        }
    }
}