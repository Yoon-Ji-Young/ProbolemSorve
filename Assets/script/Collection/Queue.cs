using UnityEngine;

// �̸� : ������ 
// �й� : 201927060
public class Node<T>
{
    //NextNode : ���� ���, value : ��
    private Node<T> nextNode;
    private T value;

    public Node(T value)
    {
        this.value = value;
    }
    //Get Set Get Set
    public void SetNextNode(Node<T> next)
    {
        this.nextNode = next;
    }
    public Node<T> GetNextNode()
    {
        return nextNode;
    }
    public void SetValue(T value)
    {
        this.value = value;
    }
    public T GetValue()
    {
        return value;
    }
}
public class LinkedList<T>
{
    public Node<T> firstNode { get; set; } // ù ���
    public Node<T> lastNode { get; set; } // ������ ���
    public int nodeCnt; //��� ������
    public LinkedList()
    {
        nodeCnt = 0;
    }
    public void CreateFirstNode(T value) //��尡 �ƿ� ���� �� ���ο� ��� ����
    {
        Node<T> tempNode = new Node<T>(value);
        firstNode = tempNode;
        lastNode = tempNode;
        nodeCnt++;
    }
    public void AddNodeFront(T value) //�տ� ���ο� ��带 ����
    {
        if (nodeCnt == 0)
        {
            CreateFirstNode(value);
            return;
        }
        Node<T> tempNode = new Node<T>(value);
        tempNode.SetNextNode(firstNode);
        firstNode = tempNode;
        nodeCnt++;
    }
    public void AddNodeBehind(T value) //�ڿ� ���ο� ��带 ����
    {
        if (nodeCnt == 0)
        {
            CreateFirstNode(value);
            return;
        }
        Node<T> tempNode = new Node<T>(value);
        lastNode.SetNextNode(tempNode);
        lastNode = tempNode;
        nodeCnt++;
    }
    public void RemoveNodeFront() //�տ� �ִ� ��带 ����
    {
        if (nodeCnt == 0)
        {
            Debug.Log("ERROE ����ִ� ��ũ�� ����Ʈ���� ��带 ������ �� �����ϴ�");
            return;
        }
        Node<T> nextNode = firstNode.GetNextNode();
        firstNode = nextNode;
        nodeCnt--;
    }
    public void RemoveNodeBehind() //�ڿ� �ִ� ��带 ����
    {
        if (nodeCnt == 0)
        {
            Debug.Log("ERROE ����ִ� ��ũ�� ����Ʈ���� ��带 ������ �� �����ϴ�");
            return;
        }
        Node<T> currentNode = firstNode;
        while (currentNode.GetNextNode() != lastNode)
        {
            currentNode = currentNode.GetNextNode();
        }
        lastNode = currentNode;
        nodeCnt--;
    }

}
public class Queue<T>
{
    private LinkedList<T> pizza; //����
    public Queue()
    {
        pizza = new LinkedList<T>();
    }

    public void Enqueue(T value) //ť�� ������ �߰�
    {
        pizza.AddNodeBehind(value);
    }
    public T Dequeue() //ť���� ������ ��
    {
        if (pizza.nodeCnt == 0)
        {
            Debug.Log("ERROR ����ִ� ť�� Dequeue�� �� �����ϴ�");
            return default(T);
        }
        T result = pizza.firstNode.GetValue();
        pizza.RemoveNodeFront();
        return result;
    }
    public int Size() //ť�� ������ ��������
    {
        return pizza.nodeCnt;
    }
    public T Peek() //Dequeue�� �����͸� �̸�����
    {
        if (pizza.nodeCnt == 0)
        {
            Debug.Log("ERROR ����ִ� ť�� Peek�� �� �����ϴ�");
            return default(T);
        }
        return pizza.firstNode.GetValue();
    }
}
public class LinkedListScript : MonoBehaviour
{
    //�׽�Ʈ
    private void Start()
    {
        Queue<int> armmo = new Queue<int>();
    }
}