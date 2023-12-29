namespace ProjectDataStructure.Models
{
    public class Project4Service
    {
        public class QueueUsingStack
        {
            private Stack<object> enqueueStack;
            private Stack<object> dequeueStack;

            public QueueUsingStack()
            {
                enqueueStack = new Stack<object>();
                dequeueStack = new Stack<object>();
            }

            public void Enqueue(object item)
            {
                enqueueStack.Push(item);
            }

            public object Dequeue()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Queue is empty");
                }

                if (dequeueStack.Count == 0)
                {
                    // Transfer elements from enqueueStack to dequeueStack
                    while (enqueueStack.Count > 0)
                    {
                        dequeueStack.Push(enqueueStack.Pop());
                    }
                }

                return dequeueStack.Pop();
            }

            public bool IsEmpty()
            {
                return enqueueStack.Count == 0 && dequeueStack.Count == 0;
            }
        }
        public class Stack
        {
            private object[] array;
            private int top;
            private int capacity;

            public Stack(int capacity)
            {
                this.capacity = capacity;
                array = new object[capacity];
                top = -1;
            }

            public void Push(object item)
            {
                if (IsFull())
                {
                    throw new InvalidOperationException("Stack is full");
                }

                array[++top] = item;
            }

            public object Pop()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Stack is empty");
                }

                return array[top--];
            }

            public object Peek()
            {
                if (IsEmpty())
                {
                    throw new InvalidOperationException("Stack is empty");
                }

                return array[top];
            }

            public bool IsEmpty()
            {
                return top == -1;
            }

            public bool IsFull()
            {
                return top == capacity - 1;
            }
        }

    }
}
