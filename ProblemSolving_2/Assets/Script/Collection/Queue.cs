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

    private Node head; // ť�� �� ���� ����Ű�� ���
    private Node tail; // ť�� �� �ڸ� ����Ű�� ���
    private int count; // ť�� ����ִ� ����� ��
    public GameObject bulletPrefab; // �Ѿ� ������

    void Start()
    {
        head = null;
        tail = null;
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

            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.next = newNode;
                tail = newNode;
            }

            count++;

            Debug.Log("Enqueue �Լ���. ���� �Ѿ� ��: " + count);
        }
    }

    // ť���� ��� ����
    public void DequeueBullet()
    {
        if (head != null)
        {
            Destroy(head.data);
            head = head.next;
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
        if (other.CompareTag("Bullet") && count > 0)
        {
            DequeueBullet();
        }
    }
}