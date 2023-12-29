namespace ProjectDataStructure.Models
{
    public class Project5Service
    {
        #region LinkedList
        public class NodeLinkedList
        {
            public int Data { get; set; }
            public NodeLinkedList Next { get; set; }

            public NodeLinkedList(int data)
            {
                Data = data;
                Next = null;
            }
        }

        public class LinkedList
        {
            private NodeLinkedList head;
            private int size;

            public LinkedList()
            {
                head = null;
                size = 0;
            }

            public void InsertAtIndex(int data, int index)
            {
                if (index < 0 || index > size)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                NodeLinkedList newNode = new NodeLinkedList(data);

                if (index == 0)
                {
                    InsertAtBegin(data);
                }
                else if (index == size)
                {
                    InsertAtEnd(data);
                }
                else
                {
                    NodeLinkedList current = head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next;
                    }

                    newNode.Next = current.Next;
                    current.Next = newNode;
                    size++;
                }
            }

            public void InsertAtEnd(int data)
            {
                NodeLinkedList newNode = new NodeLinkedList(data);

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    NodeLinkedList current = head;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }

                    current.Next = newNode;
                }

                size++;
            }

            public void InsertAtBegin(int data)
            {
                NodeLinkedList newNode = new NodeLinkedList(data);
                newNode.Next = head;
                head = newNode;
                size++;
            }

            public void UpdateNode(int data, int index)
            {
                if (index < 0 || index >= size)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                NodeLinkedList current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                current.Data = data;
            }

            public int RemoveNodeAtIndex(int index)
            {
                if (index < 0 || index >= size)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                int removedData;

                if (index == 0)
                {
                    removedData = RemoveNodeAtBegin();
                }
                else
                {
                    NodeLinkedList current = head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next;
                    }

                    removedData = current.Next.Data;
                    current.Next = current.Next.Next;
                    size--;
                }

                return removedData;
            }

            public int RemoveNodeAtEnd()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("List is empty");
                }

                int removedData;

                if (size == 1)
                {
                    removedData = head.Data;
                    head = null;
                }
                else
                {
                    NodeLinkedList current = head;
                    while (current.Next.Next != null)
                    {
                        current = current.Next;
                    }

                    removedData = current.Next.Data;
                    current.Next = null;
                }

                size--;
                return removedData;
            }

            public int RemoveNodeAtBegin()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("List is empty");
                }

                int removedData = head.Data;
                head = head.Next;
                size--;
                return removedData;
            }

            public int SizeOfList()
            {
                return size;
            }

            public void Concatenate(LinkedList list)
            {
                if (list == null)
                {
                    throw new ArgumentNullException(nameof(list));
                }

                if (head == null)
                {
                    head = list.head;
                }
                else
                {
                    NodeLinkedList current = head;
                    while (current.Next != null)
                    {
                        current = current.Next;
                    }

                    current.Next = list.head;
                }

                size += list.size;
            }

            public void Invert()
            {
                NodeLinkedList prev = null;
                NodeLinkedList current = head;
                NodeLinkedList next = null;

                while (current != null)
                {
                    next = current.Next;
                    current.Next = prev;
                    prev = current;
                    current = next;
                }

                head = prev;
            }

            public int[] ToArray()
            {
                int[] array = new int[size];
                NodeLinkedList current = head;
                int index = 0;

                while (current != null)
                {
                    array[index++] = current.Data;
                    current = current.Next;
                }

                return array;
            }

            public bool IsEmpty()
            {
                return head == null;
            }
        }
        #endregion

        #region CircularLinkedList
        public class NodeCircularLinkedList
        {
            public int Data { get; set; }
            public NodeCircularLinkedList Next { get; set; }

            public NodeCircularLinkedList(int data)
            {
                Data = data;
                Next = this;
            }
        }

        public class CircularLinkedList
        {
            private NodeCircularLinkedList head;
            private int size;

            public CircularLinkedList()
            {
                head = null;
                size = 0;
            }

            public void InsertAtIndex(int data, int index)
            {
                if (index < 0 || index > size)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                NodeCircularLinkedList newNode = new NodeCircularLinkedList(data);

                if (index == 0)
                {
                    InsertAtBegin(data);
                }
                else if (index == size)
                {
                    InsertAtEnd(data);
                }
                else
                {
                    NodeCircularLinkedList current = head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next;
                    }

                    newNode.Next = current.Next;
                    current.Next = newNode;
                    size++;
                }
            }

            public void InsertAtEnd(int data)
            {
                NodeCircularLinkedList newNode = new NodeCircularLinkedList(data);

                if (head == null)
                {
                    head = newNode;
                }
                else
                {
                    NodeCircularLinkedList current = head;
                    while (current.Next != head)
                    {
                        current = current.Next;
                    }

                    newNode.Next = head;
                    current.Next = newNode;
                }

                size++;
            }

            public void InsertAtBegin(int data)
            {
                NodeCircularLinkedList newNode = new NodeCircularLinkedList(data);

                if (head == null)
                {
                    head = newNode;
                    head.Next = head;
                }
                else
                {
                    NodeCircularLinkedList current = head;
                    while (current.Next != head)
                    {
                        current = current.Next;
                    }

                    newNode.Next = head;
                    head = newNode;
                    current.Next = head;
                }

                size++;
            }

            public void UpdateNode(int data, int index)
            {
                if (index < 0 || index >= size)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                NodeCircularLinkedList current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }

                current.Data = data;
            }

            public int RemoveNodeAtIndex(int index)
            {
                if (index < 0 || index >= size)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                int removedData;

                if (index == 0)
                {
                    removedData = RemoveNodeAtBegin();
                }
                else
                {
                    NodeCircularLinkedList current = head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        current = current.Next;
                    }

                    removedData = current.Next.Data;
                    current.Next = current.Next.Next;
                    size--;

                    if (index == size)
                    {
                        head = current.Next;
                    }
                }

                return removedData;
            }

            public int RemoveNodeAtEnd()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("List is empty");
                }

                int removedData;

                if (size == 1)
                {
                    removedData = RemoveNodeAtBegin();
                }
                else
                {
                    NodeCircularLinkedList current = head;
                    while (current.Next.Next != head)
                    {
                        current = current.Next;
                    }

                    removedData = current.Next.Data;
                    current.Next = head;
                    size--;
                }

                return removedData;
            }

            public int RemoveNodeAtBegin()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("List is empty");
                }

                int removedData = head.Data;

                if (size == 1)
                {
                    head = null;
                }
                else
                {
                    NodeCircularLinkedList current = head;
                    while (current.Next != head)
                    {
                        current = current.Next;
                    }

                    head = head.Next;
                    current.Next = head;
                }

                size--;
                return removedData;
            }

            public int SizeOfList()
            {
                return size;
            }

            public void Concatenate(CircularLinkedList list)
            {
                if (list == null)
                {
                    throw new ArgumentNullException(nameof(list));
                }

                if (head == null)
                {
                    head = list.head;
                }
                else if (list.head != null)
                {
                    NodeCircularLinkedList current = head;
                    while (current.Next != head)
                    {
                        current = current.Next;
                    }

                    current.Next = list.head;

                    NodeCircularLinkedList endOfList = list.head;
                    while (endOfList.Next != list.head)
                    {
                        endOfList = endOfList.Next;
                    }

                    endOfList.Next = head;
                }

                size += list.size;
            }

            public void Invert()
            {
                if (!IsEmpty())
                {
                    NodeCircularLinkedList prev = null;
                    NodeCircularLinkedList current = head;
                    NodeCircularLinkedList next = null;

                    do
                    {
                        next = current.Next;
                        current.Next = prev;
                        prev = current;
                        current = next;
                    } while (current != head);

                    head = prev;
                }
            }

            public bool IsEmpty()
            {
                return head == null;
            }
        }
        #endregion

        #region DoublyLinkedList
        public class NodeDoublyLinkedList
        {
            public int Data { get; set; }
            public NodeDoublyLinkedList Next { get; set; }
            public NodeDoublyLinkedList Previous { get; set; }

            public NodeDoublyLinkedList(int data)
            {
                Data = data;
                Next = null;
                Previous = null;
            }
        }

        public class DoublyLinkedList
        {
            private NodeDoublyLinkedList head;
            private NodeDoublyLinkedList tail;
            private int size;

            public DoublyLinkedList()
            {
                head = null;
                tail = null;
                size = 0;
            }

            public void InsertAtIndex(int data, int index)
            {
                if (index < 0 || index > size)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                NodeDoublyLinkedList newNode = new NodeDoublyLinkedList(data);

                if (index == 0)
                {
                    InsertAtBegin(data);
                }
                else if (index == size)
                {
                    InsertAtEnd(data);
                }
                else
                {
                    NodeDoublyLinkedList current = GetNodeAtIndex(index - 1);

                    newNode.Next = current.Next;
                    newNode.Previous = current;
                    current.Next.Previous = newNode;
                    current.Next = newNode;

                    size++;
                }
            }

            public void InsertAtEnd(int data)
            {
                NodeDoublyLinkedList newNode = new NodeDoublyLinkedList(data);

                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    newNode.Previous = tail;
                    tail.Next = newNode;
                    tail = newNode;
                }

                size++;
            }

            public void InsertAtBegin(int data)
            {
                NodeDoublyLinkedList newNode = new NodeDoublyLinkedList(data);

                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    newNode.Next = head;
                    head.Previous = newNode;
                    head = newNode;
                }

                size++;
            }

            public void UpdateNode(int data, int index)
            {
                if (index < 0 || index >= size)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                GetNodeAtIndex(index).Data = data;
            }

            public int RemoveNodeAtIndex(int index)
            {
                if (index < 0 || index >= size)
                {
                    throw new ArgumentOutOfRangeException("Invalid index");
                }

                int removedData;

                if (index == 0)
                {
                    removedData = RemoveNodeAtBegin();
                }
                else if (index == size - 1)
                {
                    removedData = RemoveNodeAtEnd();
                }
                else
                {
                    NodeDoublyLinkedList current = GetNodeAtIndex(index);

                    removedData = current.Data;
                    current.Previous.Next = current.Next;
                    current.Next.Previous = current.Previous;

                    size--;
                }

                return removedData;
            }

            public int RemoveNodeAtEnd()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("List is empty");
                }

                int removedData;

                if (size == 1)
                {
                    removedData = head.Data;
                    head = null;
                    tail = null;
                }
                else
                {
                    removedData = tail.Data;
                    tail = tail.Previous;
                    tail.Next = null;
                }

                size--;
                return removedData;
            }

            public int RemoveNodeAtBegin()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("List is empty");
                }

                int removedData = head.Data;

                if (size == 1)
                {
                    head = null;
                    tail = null;
                }
                else
                {
                    head = head.Next;
                    head.Previous = null;
                }

                size--;
                return removedData;
            }

            public int SizeOfList()
            {
                return size;
            }

            public void Concatenate(DoublyLinkedList list)
            {
                if (list == null)
                {
                    throw new ArgumentNullException(nameof(list));
                }

                if (head == null)
                {
                    head = list.head;
                    tail = list.tail;
                }
                else
                {
                    tail.Next = list.head;
                    list.head.Previous = tail;
                    tail = list.tail;
                }

                size += list.size;
            }

            public void Invert()
            {
                NodeDoublyLinkedList current = head;
                NodeDoublyLinkedList temp;

                while (current != null)
                {
                    // Swap next and previous pointers of the current node
                    temp = current.Next;
                    current.Next = current.Previous;
                    current.Previous = temp;

                    // Move to the next node
                    current = temp;
                }

                // Swap head and tail pointers
                temp = head;
                head = tail;
                tail = temp;
            }


            private NodeDoublyLinkedList GetNodeAtIndex(int index)
            {
                NodeDoublyLinkedList current = head;
                for (int i = 0; i < index; i++)
                {
                    current = current.Next;
                }
                return current;
            }

            private bool IsEmpty()
            {
                return head == null;
            }
        }
        #endregion

        public class DynamicArray
        {
            private LinkedList linkedList;

            public DynamicArray()
            {
                linkedList = new LinkedList();
            }

            public void InsertAtIndex(int data, int index)
            {
                linkedList.InsertAtIndex(data, index);
            }

            public void InsertAtEnd(int data)
            {
                linkedList.InsertAtEnd(data);
            }

            public void InsertAtBegin(int data)
            {
                linkedList.InsertAtBegin(data);
            }

            public void UpdateNode(int data, int index)
            {
                linkedList.UpdateNode(data, index);
            }

            public int RemoveNodeAtIndex(int index)
            {
                return linkedList.RemoveNodeAtIndex(index);
            }

            public int RemoveNodeAtEnd()
            {
                return linkedList.RemoveNodeAtEnd();
            }

            public int RemoveNodeAtBegin()
            {
                return linkedList.RemoveNodeAtBegin();
            }

            public int SizeOfList()
            {
                return linkedList.SizeOfList();
            }

            public void Concatenate(DynamicArray array)
            {
                linkedList.Concatenate(array.linkedList);
            }

            public void Invert()
            {
                linkedList.Invert();
            }

            public int[] ToArray()
            {
                return linkedList.ToArray();
            }
        }

        public class Queue
        {
            private NodeLinkedList front;
            private NodeLinkedList rear;
            private int size;

            public Queue()
            {
                front = null;
                rear = null;
                size = 0;
            }

            public void Enqueue(int data)
            {
                NodeLinkedList newNode = new NodeLinkedList(data);

                if (rear == null)
                {
                    front = newNode;
                    rear = newNode;
                }
                else
                {
                    rear.Next = newNode;
                    rear = newNode;
                }

                size++;
            }

            public int Dequeue()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                int removedData = front.Data;

                if (front == rear)
                {
                    front = null;
                    rear = null;
                }
                else
                {
                    front = front.Next;
                }

                size--;
                return removedData;
            }

            public int Peek()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                return front.Data;
            }

            public bool IsEmpty()
            {
                return front == null;
            }

            public bool IsFull()
            {
                // In the context of a linked list, the concept of being "full" is not applicable.
                // You can always add new nodes to the linked list.
                return false;
            }
        }

        public class Stack
        {
            private LinkedList linkedList;

            public Stack()
            {
                linkedList = new LinkedList();
            }

            public void Push(int data)
            {
                linkedList.InsertAtBegin(data);
            }

            public int Pop()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Stack is empty");
                }

                return linkedList.RemoveNodeAtBegin();
            }

            public int Peek()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Stack is empty");
                }

                return linkedList.RemoveNodeAtBegin();
            }

            public bool IsEmpty()
            {
                return linkedList.IsEmpty();
            }

            public bool IsFull()
            {
                // In the context of a linked list, the concept of being "full" is not applicable.
                // You can always add new nodes to the linked list.
                return false;
            }
        }

    }
}
