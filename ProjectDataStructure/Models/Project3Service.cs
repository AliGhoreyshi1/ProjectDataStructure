using static ProjectDataStructure.Models.Project2Service;

namespace ProjectDataStructure.Models
{
    public class Project3Service
    {
        public QueueArray TestQueueArray(string test)
        {
            QueueArray matrix = new QueueArray(test.Length);

            foreach (var item in test)
            {
                if (!matrix.IsEmpty() && (char)matrix.Peek() == item)
                    continue;
                matrix.Enqueue(item);
            }
            
            return matrix;
        }
        public CircularQueue TestCircularQueue(string test)
        {
            CircularQueue matrix = new CircularQueue(test.Length);

            foreach (var item in test)
            {
                if (matrix.Peek() != null && (char)matrix.Peek() == item)
                    continue;
                matrix.Enqueue(item);
            }

            return matrix;
        }

        public class QueueArray
        {
            private object[] array;
            private int front;
            private int rear;
            private int capacity;
            private int size;

            public QueueArray(int capacity)
            {
                this.capacity = capacity;
                array = new object[capacity];
                front = 0;
                rear = -1;
                size = 0;
            }

            public void Enqueue(object item)
            {
                if (IsFull())
                {
                    throw new InvalidOperationException("Queue is full");
                }

                rear = (rear + 1) % capacity;
                array[rear] = item;
                size++;
            }

            public object Dequeue()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                object item = array[front];
                front = (front + 1) % capacity;
                size--;
                return item;
            }

            public object Peek()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                return array[front];
            }

            public QueueArray ReverseQueue()
            {
                QueueArray reversedQueue = new QueueArray(capacity);
                for (int i = 0; i < size; i++)
                {
                    reversedQueue.Enqueue(array[(front + i) % capacity]);
                }

                return reversedQueue;
            }

            public bool IsEmpty()
            {
                return size == 0;
            }

            public bool IsFull()
            {
                return size == capacity;
            }
        }
        public class CircularQueue
        {
            private object[] array;
            private int front;
            private int rear;
            private int capacity;
            private int size;

            public CircularQueue(int capacity)
            {
                this.capacity = capacity;
                array = new object[capacity];
                front = -1;
                rear = -1;
                size = 0;
            }

            public void Enqueue(object item)
            {
                if (IsFull())
                {
                    throw new InvalidOperationException("Queue is full");
                }

                if (IsEmpty())
                {
                    front = 0;
                }

                rear = (rear + 1) % capacity;
                array[rear] = item;
                size++;
            }

            public object Dequeue()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                object item = array[front];

                if (front == rear)
                {
                    front = -1;
                    rear = -1;
                }
                else
                {
                    front = (front + 1) % capacity;
                }

                size--;
                return item;
            }

            public object Peek()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                return array[front];
            }

            public CircularQueue ReverseQueue()
            {
                CircularQueue reversedQueue = new CircularQueue(capacity);
                int tempFront = front;

                for (int i = 0; i < size; i++)
                {
                    reversedQueue.Enqueue(array[tempFront]);
                    tempFront = (tempFront + 1) % capacity;
                }

                return reversedQueue;
            }

            public bool IsEmpty()
            {
                return size == 0;
            }

            public bool IsFull()
            {
                return size == capacity;
            }
        }
    }
}
