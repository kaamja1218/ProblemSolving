using UnityEngine;
using System.Collections.Generic;

public class Queue : MonoBehaviour
{
    // Node 클래스 정의
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

    private Node head; // 큐의 맨 앞을 가리키는 노드
    private Node tail; // 큐의 맨 뒤를 가리키는 노드
    private int count; // 큐에 들어있는 요소의 수
    public GameObject bulletPrefab; // 총알 프리펩

    void Start()
    {
        head = null;
        tail = null;
        count = 0;
    }

    // 큐에 요소 추가
    public void EnqueueBullet()
    {
        // 큐에 총알이 10개 미만인 경우에만 새로운 총알 추가
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

            Debug.Log("Enqueue 함수다. 현재 총알 수: " + count);
        }
    }

    // 큐에서 요소 제거
    public void DequeueBullet()
    {
        if (head != null)
        {
            Destroy(head.data);
            head = head.next;
            count--;

            Debug.Log("Dequeue함수다. 현재 총알 수: " + count);
        }
    }

    // 마우스 클릭 이벤트 감지하여 EnqueueBullet() 호출
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            EnqueueBullet();
        }
    }

    // 레드 큐브에 부딪힌 총알을 다시 Queue에 추가
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet") && count > 0)
        {
            DequeueBullet();
        }
    }
}