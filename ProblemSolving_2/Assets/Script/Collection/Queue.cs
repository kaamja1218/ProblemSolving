using UnityEngine;
using System.Collections.Generic;

public class Queue : MonoBehaviour
{
    // Node Ŭ���� ����
    private class Node
    {
        public GameObject data;
        public Node next;

        public Node(GameObject obj)
        {
            data = obj;
            next = null;
        }
    }

    private Queue<Node> bulletQueue = new Queue<Node>(); // ť ����
    private int count; // ť�� ����ִ� ����� ��
    public GameObject bulletPrefab; // �Ѿ� ������

    void Start()
    {
        count = 0;
    }

    // ť�� ��� �߰�
    public void EnqueueBullet()
    {
        // ť�� �Ѿ��� 10�� �̸��� ��쿡�� ���ο� �Ѿ� �߰�
        if (count < 10)
        {
            GameObject bullet = Instantiate(bulletPrefab, new Vector3(-9f, 0f, 0f), Quaternion.identity);
            Node newNode = new Node(bullet);
            bulletQueue.Enqueue(newNode);
            count++;

            Debug.Log("Enqueue �Լ���. ���� �Ѿ� ��: " + count);
        }
    }

    // ť���� ��� ����
    public void DequeueBullet()
    {
        if (bulletQueue.Count > 0)
        {
            Node dequeuedNode = bulletQueue.Dequeue();
            Destroy(dequeuedNode.data);
            count--;

            Debug.Log("Dequeue�Լ���. ���� �Ѿ� ��: " + count);
        }
    }

    // ���콺 Ŭ�� �̺�Ʈ �����Ͽ� EnqueueBullet() ȣ��
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EnqueueBullet();
        }
    }

    // ���� ť�꿡 �ε��� �Ѿ��� �ٽ� Queue�� �߰�
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && bulletQueue.Count > 0)
        {
            DequeueBullet();
        }
    }
}