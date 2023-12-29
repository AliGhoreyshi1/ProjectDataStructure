using System.Drawing;

namespace ProjectDataStructure.Models
{
    public class Project6Service
    {
        #region HashTable
        public class HashTable
        {
            private const int Capacity = 10;
            private List<KeyValuePair>[] buckets;

            public HashTable()
            {
                buckets = new List<KeyValuePair>[Capacity];
                for (int i = 0; i < Capacity; i++)
                {
                    buckets[i] = new List<KeyValuePair>();
                }
            }

            private int HashFunction(string key)
            {
                int hash = 0;
                foreach (char character in key)
                {
                    hash += (int)character;
                }

                return hash % Capacity;
            }

            public void Insert(string key, string value)
            {
                int index = HashFunction(key);
                buckets[index].Add(new KeyValuePair(key, value));
            }

            public string Remove(string key)
            {
                int index = HashFunction(key);
                foreach (var kvp in buckets[index])
                {
                    if (kvp.Key == key)
                    {
                        buckets[index].Remove(kvp);
                        return kvp.Value;
                    }
                }

                return null;
            }

            public string Search(string key)
            {
                int index = HashFunction(key);
                foreach (var kvp in buckets[index])
                {
                    if (kvp.Key == key)
                    {
                        return kvp.Value;
                    }
                }

                return null;
            }
            private class KeyValuePair
            {
                public string Key { get; }
                public string Value { get; }

                public KeyValuePair(string key, string value)
                {
                    Key = key;
                    Value = value;
                }
            }
        }
        #endregion

        #region BinaryTree
        public class BinaryTreeNode
        {
            public int Value { get; set; }
            public BinaryTreeNode Left { get; set; }
            public BinaryTreeNode Right { get; set; }

            public BinaryTreeNode(int value)
            {
                Value = value;
                Left = null;
                Right = null;
            }
        }

        public class BinaryTree
        {
            private BinaryTreeNode root;

            public BinaryTree()
            {
                root = null;
            }

            public void Insert(int value)
            {
                root = InsertRecursive(root, value);
            }

            private BinaryTreeNode InsertRecursive(BinaryTreeNode node, int value)
            {
                if (node == null)
                {
                    return new BinaryTreeNode(value);
                }

                if (value < node.Value)
                {
                    node.Left = InsertRecursive(node.Left, value);
                }
                else if (value > node.Value)
                {
                    node.Right = InsertRecursive(node.Right, value);
                }

                return node;
            }

            public void Remove(int value)
            {
                root = RemoveRecursive(root, value);
            }

            private BinaryTreeNode RemoveRecursive(BinaryTreeNode node, int value)
            {
                if (node == null)
                {
                    return null;
                }

                if (value < node.Value)
                {
                    node.Left = RemoveRecursive(node.Left, value);
                }
                else if (value > node.Value)
                {
                    node.Right = RemoveRecursive(node.Right, value);
                }
                else
                {
                    if (node.Left == null)
                    {
                        return node.Right;
                    }
                    else if (node.Right == null)
                    {
                        return node.Left;
                    }

                    node.Value = FindMinValue(node.Right);
                    node.Right = RemoveRecursive(node.Right, node.Value);
                }

                return node;
            }

            private int FindMinValue(BinaryTreeNode node)
            {
                int minValue = node.Value;
                while (node.Left != null)
                {
                    minValue = node.Left.Value;
                    node = node.Left;
                }
                return minValue;
            }

            public bool Search(int value)
            {
                return SearchRecursive(root, value);
            }

            private bool SearchRecursive(BinaryTreeNode node, int value)
            {
                if (node == null)
                {
                    return false;
                }

                if (value == node.Value)
                {
                    return true;
                }
                else if (value < node.Value)
                {
                    return SearchRecursive(node.Left, value);
                }
                else
                {
                    return SearchRecursive(node.Right, value);
                }
            }

            public string Preorder()
            {
                return PreorderRecursive(root);
            }

            private string PreorderRecursive(BinaryTreeNode node)
            {
                if (node == null)
                {
                    return "";
                }

                return $"{node.Value} {PreorderRecursive(node.Left)} {PreorderRecursive(node.Right)}";
            }

            public string Inorder()
            {
                return InorderRecursive(root);
            }

            private string InorderRecursive(BinaryTreeNode node)
            {
                if (node == null)
                {
                    return "";
                }

                return $"{InorderRecursive(node.Left)} {node.Value} {InorderRecursive(node.Right)}";
            }

            public string Postorder()
            {
                return PostorderRecursive(root);
            }

            private string PostorderRecursive(BinaryTreeNode node)
            {
                if (node == null)
                {
                    return "";
                }

                return $"{PostorderRecursive(node.Left)} {PostorderRecursive(node.Right)} {node.Value}";
            }
        }
        #endregion

        #region AVLTree
        public class AVLTreeNode
        {
            public int Value { get; set; }
            public int Height { get; set; }
            public AVLTreeNode Left { get; set; }
            public AVLTreeNode Right { get; set; }

            public AVLTreeNode(int value)
            {
                Value = value;
                Height = 1;
                Left = null;
                Right = null;
            }
        }

        public class AVLTree
        {
            private AVLTreeNode root;

            public AVLTree()
            {
                root = null;
            }

            public void Insert(int value)
            {
                root = InsertRecursive(root, value);
            }

            private AVLTreeNode InsertRecursive(AVLTreeNode node, int value)
            {
                if (node == null)
                {
                    return new AVLTreeNode(value);
                }

                if (value < node.Value)
                {
                    node.Left = InsertRecursive(node.Left, value);
                }
                else if (value > node.Value)
                {
                    node.Right = InsertRecursive(node.Right, value);
                }
                else
                {
                    return node;
                }

                node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));
                int balance = GetBalance(node);

                if (balance > 1 && value < node.Left.Value)
                {
                    return RotateRight(node);
                }

                if (balance < -1 && value > node.Right.Value)
                {
                    return RotateLeft(node);
                }

                if (balance > 1 && value > node.Left.Value)
                {
                    node.Left = RotateLeft(node.Left);
                    return RotateRight(node);
                }

                if (balance < -1 && value < node.Right.Value)
                {
                    node.Right = RotateRight(node.Right);
                    return RotateLeft(node);
                }

                return node;
            }

            public void Remove(int value)
            {
                root = RemoveRecursive(root, value);
            }

            private AVLTreeNode RemoveRecursive(AVLTreeNode node, int value)
            {
                if (node == null)
                {
                    return null;
                }

                if (value < node.Value)
                {
                    node.Left = RemoveRecursive(node.Left, value);
                }
                else if (value > node.Value)
                {
                    node.Right = RemoveRecursive(node.Right, value);
                }
                else
                {
                    if (node.Left == null || node.Right == null)
                    {
                        AVLTreeNode temp = (node.Left != null) ? node.Left : node.Right;

                        if (temp == null)
                        {
                            temp = node;
                            node = null;
                        }
                        else
                        {
                            node = temp;
                        }
                    }
                    else
                    {
                        AVLTreeNode temp = FindMinValueNode(node.Right);
                        node.Value = temp.Value;
                        node.Right = RemoveRecursive(node.Right, temp.Value);
                    }
                }

                if (node == null)
                {
                    return null;
                }

                node.Height = 1 + Math.Max(GetHeight(node.Left), GetHeight(node.Right));

                int balance = GetBalance(node);

                if (balance > 1 && GetBalance(node.Left) >= 0)
                {
                    return RotateRight(node);
                }

                if (balance < -1 && GetBalance(node.Right) <= 0)
                {
                    return RotateLeft(node);
                }

                if (balance > 1 && GetBalance(node.Left) < 0)
                {
                    node.Left = RotateLeft(node.Left);
                    return RotateRight(node);
                }

                if (balance < -1 && GetBalance(node.Right) > 0)
                {
                    node.Right = RotateRight(node.Right);
                    return RotateLeft(node);
                }

                return node;
            }

            private AVLTreeNode RotateRight(AVLTreeNode y)
            {
                AVLTreeNode x = y.Left;
                AVLTreeNode T2 = x.Right;

                x.Right = y;
                y.Left = T2;

                y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));
                x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));

                return x;
            }

            private AVLTreeNode RotateLeft(AVLTreeNode x)
            {
                AVLTreeNode y = x.Right;
                AVLTreeNode T2 = y.Left;

                y.Left = x;
                x.Right = T2;

                x.Height = 1 + Math.Max(GetHeight(x.Left), GetHeight(x.Right));
                y.Height = 1 + Math.Max(GetHeight(y.Left), GetHeight(y.Right));

                return y;
            }

            private int GetHeight(AVLTreeNode node)
            {
                if (node == null)
                {
                    return 0;
                }
                return node.Height;
            }

            private int GetBalance(AVLTreeNode node)
            {
                if (node == null)
                {
                    return 0;
                }
                return GetHeight(node.Left) - GetHeight(node.Right);
            }

            private AVLTreeNode FindMinValueNode(AVLTreeNode node)
            {
                while (node.Left != null)
                {
                    node = node.Left;
                }
                return node;
            }
        }

        #endregion

        #region RedBlackTree
        public class RedBlackTreeNode
        {
            public int Value { get; set; }
            public Color NodeColor { get; set; }
            public RedBlackTreeNode Parent { get; set; }
            public RedBlackTreeNode Left { get; set; }
            public RedBlackTreeNode Right { get; set; }

            public RedBlackTreeNode(int value, Color color)
            {
                Value = value;
                NodeColor = color;
                Parent = null;
                Left = null;
                Right = null;
            }
        }

        public class RedBlackTree
        {
            private RedBlackTreeNode root;

            public RedBlackTree()
            {
                root = null;
            }

            public void Insert(int value)
            {
                RedBlackTreeNode node = new RedBlackTreeNode(value, Color.Red);
                root = InsertRecursive(root, node);
                FixInsert(node);
            }

            private RedBlackTreeNode InsertRecursive(RedBlackTreeNode root, RedBlackTreeNode node)
            {
                if (root == null)
                {
                    return node;
                }

                if (node.Value < root.Value)
                {
                    root.Left = InsertRecursive(root.Left, node);
                    root.Left.Parent = root;
                }
                else if (node.Value > root.Value)
                {
                    root.Right = InsertRecursive(root.Right, node);
                    root.Right.Parent = root;
                }

                return root;
            }

            private void FixInsert(RedBlackTreeNode node)
            {
                while (node != root && node.Parent.NodeColor == Color.Red)
                {
                    if (node.Parent == node.Parent.Parent.Left)
                    {
                        RedBlackTreeNode uncle = node.Parent.Parent.Right;
                        if (uncle != null && uncle.NodeColor == Color.Red)
                        {
                            node.Parent.NodeColor = Color.Black;
                            uncle.NodeColor = Color.Black;
                            node.Parent.Parent.NodeColor = Color.Red;
                            node = node.Parent.Parent;
                        }
                        else
                        {
                            if (node == node.Parent.Right)
                            {
                                node = node.Parent;
                                RotateLeft(node);
                            }

                            node.Parent.NodeColor = Color.Black;
                            node.Parent.Parent.NodeColor = Color.Red;
                            RotateRight(node.Parent.Parent);
                        }
                    }
                    else
                    {
                        RedBlackTreeNode uncle = node.Parent.Parent.Left;
                        if (uncle != null && uncle.NodeColor == Color.Red)
                        {
                            node.Parent.NodeColor = Color.Black;
                            uncle.NodeColor = Color.Black;
                            node.Parent.Parent.NodeColor = Color.Red;
                            node = node.Parent.Parent;
                        }
                        else
                        {
                            if (node == node.Parent.Left)
                            {
                                node = node.Parent;
                                RotateRight(node);
                            }

                            node.Parent.NodeColor = Color.Black;
                            node.Parent.Parent.NodeColor = Color.Red;
                            RotateLeft(node.Parent.Parent);
                        }
                    }
                }

                root.NodeColor = Color.Black;
            }

            public void Remove(int value)
            {
                RedBlackTreeNode node = Search(value);
                if (node == null)
                {
                    Console.WriteLine($"Node with value {value} not found");
                    return;
                }

                RedBlackTreeNode temp = node;
                RedBlackTreeNode y = temp;
                Color originalColor = y.NodeColor;

                if (node.Left == null)
                {
                    RedBlackTreeNode x = node.Right;
                    Transplant(node, node.Right);
                }
                else if (node.Right == null)
                {
                    RedBlackTreeNode x = node.Left;
                    Transplant(node, node.Left);
                }
                else
                {
                    y = FindMinValueNode(node.Right);
                    originalColor = y.NodeColor;
                    RedBlackTreeNode x = y.Right;

                    if (y.Parent == node)
                    {
                        x.Parent = y;
                    }
                    else
                    {
                        Transplant(y, y.Right);
                        y.Right = node.Right;
                        y.Right.Parent = y;
                    }

                    Transplant(node, y);
                    y.Left = node.Left;
                    y.Left.Parent = y;
                    y.NodeColor = node.NodeColor;
                }

                if (originalColor == Color.Black)
                {
                    FixDelete(temp);
                }
            }

            private void Transplant(RedBlackTreeNode u, RedBlackTreeNode v)
            {
                if (u.Parent == null)
                {
                    root = v;
                }
                else if (u == u.Parent.Left)
                {
                    u.Parent.Left = v;
                }
                else
                {
                    u.Parent.Right = v;
                }

                if (v != null)
                {
                    v.Parent = u.Parent;
                }
            }

            private void FixDelete(RedBlackTreeNode node)
            {
                while (node != root && node.NodeColor == Color.Black)
                {
                    if (node == node.Parent.Left)
                    {
                        RedBlackTreeNode sibling = node.Parent.Right;

                        if (sibling.NodeColor == Color.Red)
                        {
                            sibling.NodeColor = Color.Black;
                            node.Parent.NodeColor = Color.Red;
                            RotateLeft(node.Parent);
                            sibling = node.Parent.Right;
                        }

                        if (sibling.Left.NodeColor == Color.Black && sibling.Right.NodeColor == Color.Black)
                        {
                            sibling.NodeColor = Color.Red;
                            node = node.Parent;
                        }
                        else
                        {
                            if (sibling.Right.NodeColor == Color.Black)
                            {
                                sibling.Left.NodeColor = Color.Black;
                                sibling.NodeColor = Color.Red;
                                RotateRight(sibling);
                                sibling = node.Parent.Right;
                            }

                            sibling.NodeColor = node.Parent.NodeColor;
                            node.Parent.NodeColor = Color.Black;
                            sibling.Right.NodeColor = Color.Black;
                            RotateLeft(node.Parent);
                            node = root;
                        }
                    }
                    else
                    {
                        RedBlackTreeNode sibling = node.Parent.Left;

                        if (sibling.NodeColor == Color.Red)
                        {
                            sibling.NodeColor = Color.Black;
                            node.Parent.NodeColor = Color.Red;
                            RotateRight(node.Parent);
                            sibling = node.Parent.Left;
                        }

                        if (sibling.Right.NodeColor == Color.Black && sibling.Left.NodeColor == Color.Black)
                        {
                            sibling.NodeColor = Color.Red;
                            node = node.Parent;
                        }
                        else
                        {
                            if (sibling.Left.NodeColor == Color.Black)
                            {
                                sibling.Right.NodeColor = Color.Black;
                                sibling.NodeColor = Color.Red;
                                RotateLeft(sibling);
                                sibling = node.Parent.Left;
                            }

                            sibling.NodeColor = node.Parent.NodeColor;
                            node.Parent.NodeColor = Color.Black;
                            sibling.Left.NodeColor = Color.Black;
                            RotateRight(node.Parent);
                            node = root;
                        }
                    }
                }

                node.NodeColor = Color.Black;
            }

            public RedBlackTreeNode Search(int value)
            {
                return SearchRecursive(root, value);
            }

            private RedBlackTreeNode SearchRecursive(RedBlackTreeNode root, int value)
            {
                if (root == null || root.Value == value)
                {
                    return root;
                }

                if (value < root.Value)
                {
                    return SearchRecursive(root.Left, value);
                }

                return SearchRecursive(root.Right, value);
            }

            private void RotateLeft(RedBlackTreeNode x)
            {
                RedBlackTreeNode y = x.Right;
                x.Right = y.Left;

                if (y.Left != null)
                {
                    y.Left.Parent = x;
                }

                y.Parent = x.Parent;

                if (x.Parent == null)
                {
                    root = y;
                }
                else if (x == x.Parent.Left)
                {
                    x.Parent.Left = y;
                }
                else
                {
                    x.Parent.Right = y;
                }

                y.Left = x;
                x.Parent = y;
            }

            private void RotateRight(RedBlackTreeNode y)
            {
                RedBlackTreeNode x = y.Left;
                y.Left = x.Right;

                if (x.Right != null)
                {
                    x.Right.Parent = y;
                }

                x.Parent = y.Parent;

                if (y.Parent == null)
                {
                    root = x;
                }
                else if (y == y.Parent.Left)
                {
                    y.Parent.Left = x;
                }
                else
                {
                    y.Parent.Right = x;
                }

                x.Right = y;
                y.Parent = x;
            }

            private RedBlackTreeNode FindMinValueNode(RedBlackTreeNode node)
            {
                while (node.Left != null)
                {
                    node = node.Left;
                }

                return node;
            }

            public string Preorder()
            {
                return PreorderTraversal(root);
            }

            private string PreorderTraversal(RedBlackTreeNode node)
            {
                if (node == null)
                {
                    return string.Empty;
                }

                string result = $"{node.Value} ({node.NodeColor}), ";
                result += PreorderTraversal(node.Left);
                result += PreorderTraversal(node.Right);

                return result;
            }
        }
        #endregion

        #region MaxHeap, MinHeap
        public class MaxHeap
        {
            private int[] heapArray;
            private int capacity;
            private int heapSize;

            public MaxHeap(int capacity)
            {
                this.capacity = capacity;
                heapSize = 0;
                heapArray = new int[capacity];
            }

            public void Insert(int value)
            {
                if (heapSize == capacity)
                {
                    Console.WriteLine("Heap is full. Cannot insert.");
                    return;
                }

                heapSize++;
                int i = heapSize - 1;
                heapArray[i] = value;

                while (i != 0 && heapArray[GetParent(i)] < heapArray[i])
                {
                    Swap(ref heapArray[i], ref heapArray[GetParent(i)]);
                    i = GetParent(i);
                }
            }

            public void Remove(int value)
            {
                int index = Find(value);
                if (index == -1)
                {
                    Console.WriteLine($"Value {value} not found in the heap.");
                    return;
                }

                heapArray[index] = int.MaxValue;
                MaxHeapify(index);
                ExtractMax();
            }

            private void MaxHeapify(int i)
            {
                int left = GetLeftChild(i);
                int right = GetRightChild(i);
                int largest = i;

                if (left < heapSize && heapArray[left] > heapArray[largest])
                {
                    largest = left;
                }

                if (right < heapSize && heapArray[right] > heapArray[largest])
                {
                    largest = right;
                }

                if (largest != i)
                {
                    Swap(ref heapArray[i], ref heapArray[largest]);
                    MaxHeapify(largest);
                }
            }

            private void ExtractMax()
            {
                if (heapSize <= 0)
                {
                    Console.WriteLine("Heap is empty. Cannot extract max.");
                    return;
                }

                if (heapSize == 1)
                {
                    heapSize--;
                    return;
                }

                heapArray[0] = heapArray[heapSize - 1];
                heapSize--;
                MaxHeapify(0);
            }

            private int GetParent(int i)
            {
                return (i - 1) / 2;
            }

            private int GetLeftChild(int i)
            {
                return 2 * i + 1;
            }

            private int GetRightChild(int i)
            {
                return 2 * i + 2;
            }

            private void Swap(ref int x, ref int y)
            {
                int temp = x;
                x = y;
                y = temp;
            }

            private int Find(int value)
            {
                for (int i = 0; i < heapSize; i++)
                {
                    if (heapArray[i] == value)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public void PrintHeap()
            {
                Console.Write("Heap: ");
                for (int i = 0; i < heapSize; ++i)
                {
                    Console.Write($"{heapArray[i]} ");
                }
                Console.WriteLine();
            }
        }

        public class MinHeap
        {
            private int[] heapArray;
            private int capacity;
            private int heapSize;

            public MinHeap(int capacity)
            {
                this.capacity = capacity;
                heapSize = 0;
                heapArray = new int[capacity];
            }

            public void Insert(int value)
            {
                if (heapSize == capacity)
                {
                    Console.WriteLine("Heap is full. Cannot insert.");
                    return;
                }

                heapSize++;
                int i = heapSize - 1;
                heapArray[i] = value;

                while (i != 0 && heapArray[GetParent(i)] > heapArray[i])
                {
                    Swap(ref heapArray[i], ref heapArray[GetParent(i)]);
                    i = GetParent(i);
                }
            }

            public void Remove(int value)
            {
                int index = Find(value);
                if (index == -1)
                {
                    Console.WriteLine($"Value {value} not found in the heap.");
                    return;
                }

                heapArray[index] = int.MinValue;
                MinHeapify(index);
                ExtractMin();
            }

            private void MinHeapify(int i)
            {
                int left = GetLeftChild(i);
                int right = GetRightChild(i);
                int smallest = i;

                if (left < heapSize && heapArray[left] < heapArray[smallest])
                {
                    smallest = left;
                }

                if (right < heapSize && heapArray[right] < heapArray[smallest])
                {
                    smallest = right;
                }

                if (smallest != i)
                {
                    Swap(ref heapArray[i], ref heapArray[smallest]);
                    MinHeapify(smallest);
                }
            }

            private void ExtractMin()
            {
                if (heapSize <= 0)
                {
                    Console.WriteLine("Heap is empty. Cannot extract min.");
                    return;
                }

                if (heapSize == 1)
                {
                    heapSize--;
                    return;
                }

                heapArray[0] = heapArray[heapSize - 1];
                heapSize--;
                MinHeapify(0);
            }

            private int GetParent(int i)
            {
                return (i - 1) / 2;
            }

            private int GetLeftChild(int i)
            {
                return 2 * i + 1;
            }

            private int GetRightChild(int i)
            {
                return 2 * i + 2;
            }

            private void Swap(ref int x, ref int y)
            {
                int temp = x;
                x = y;
                y = temp;
            }

            private int Find(int value)
            {
                for (int i = 0; i < heapSize; i++)
                {
                    if (heapArray[i] == value)
                    {
                        return i;
                    }
                }
                return -1;
            }

            public void PrintHeap()
            {
                Console.Write("Heap: ");
                for (int i = 0; i < heapSize; ++i)
                {
                    Console.Write($"{heapArray[i]} ");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Tree
        public class TreeNode
        {
            public int Data { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }

            public TreeNode(int data)
            {
                Data = data;
                Left = null;
                Right = null;
            }
        }

        public class Tree
        {
            private TreeNode root;

            public Tree()
            {
                root = null;
            }

            public void Insert(int value)
            {
                root = InsertRec(root, value);
            }

            private TreeNode InsertRec(TreeNode root, int value)
            {
                if (root == null)
                {
                    root = new TreeNode(value);
                    return root;
                }

                if (value < root.Data)
                {
                    root.Left = InsertRec(root.Left, value);
                }
                else if (value > root.Data)
                {
                    root.Right = InsertRec(root.Right, value);
                }

                return root;
            }

            public void Remove(int value)
            {
                root = RemoveRec(root, value);
            }

            private TreeNode RemoveRec(TreeNode root, int value)
            {
                if (root == null)
                {
                    return root;
                }

                if (value < root.Data)
                {
                    root.Left = RemoveRec(root.Left, value);
                }
                else if (value > root.Data)
                {
                    root.Right = RemoveRec(root.Right, value);
                }
                else
                {
                    if (root.Left == null)
                    {
                        return root.Right;
                    }
                    else if (root.Right == null)
                    {
                        return root.Left;
                    }

                    root.Data = MinValue(root.Right);
                    root.Right = RemoveRec(root.Right, root.Data);
                }

                return root;
            }

            private int MinValue(TreeNode root)
            {
                int minValue = root.Data;
                while (root.Left != null)
                {
                    minValue = root.Left.Data;
                    root = root.Left;
                }
                return minValue;
            }
        }
        #endregion

        #region Graph
        public class Vertex
        {
            public string Label { get; private set; }

            public Vertex(string label)
            {
                Label = label;
            }
        }

        public class Graph
        {
            private Dictionary<Vertex, List<Vertex>> adjacencyList;

            public Graph()
            {
                adjacencyList = new Dictionary<Vertex, List<Vertex>>();
            }

            public void AddVertex(Vertex vertex)
            {
                if (!adjacencyList.ContainsKey(vertex))
                {
                    adjacencyList[vertex] = new List<Vertex>();
                }
            }

            public void AddEdge(Vertex firstVertex, Vertex secondVertex)
            {
                if (!adjacencyList.ContainsKey(firstVertex) || !adjacencyList.ContainsKey(secondVertex))
                {
                    throw new InvalidOperationException("Both vertices must be added to the graph before adding an edge.");
                }

                if (!adjacencyList[firstVertex].Contains(secondVertex))
                {
                    adjacencyList[firstVertex].Add(secondVertex);
                    adjacencyList[secondVertex].Add(firstVertex);
                }
            }

            public void RemoveEdge(Vertex firstVertex, Vertex secondVertex)
            {
                if (adjacencyList.ContainsKey(firstVertex) && adjacencyList.ContainsKey(secondVertex))
                {
                    adjacencyList[firstVertex].Remove(secondVertex);
                    adjacencyList[secondVertex].Remove(firstVertex);
                }
            }

            public void RemoveVertex(Vertex vertex)
            {
                if (adjacencyList.ContainsKey(vertex))
                {
                    foreach (var neighbor in adjacencyList[vertex])
                    {
                        adjacencyList[neighbor].Remove(vertex);
                    }

                    adjacencyList.Remove(vertex);
                }
            }

            public string BFS()
            {
                HashSet<Vertex> visited = new HashSet<Vertex>();
                Queue<Vertex> queue = new Queue<Vertex>();
                List<string> result = new List<string>();

                foreach (var vertex in adjacencyList.Keys)
                {
                    if (!visited.Contains(vertex))
                    {
                        BFSHelper(vertex, visited, queue, result);
                    }
                }

                return string.Join(" -> ", result);
            }

            private void BFSHelper(Vertex start, HashSet<Vertex> visited, Queue<Vertex> queue, List<string> result)
            {
                visited.Add(start);
                queue.Enqueue(start);

                while (queue.Count > 0)
                {
                    Vertex current = queue.Dequeue();
                    result.Add(current.Label);

                    foreach (var neighbor in adjacencyList[current])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }

            public string DFS()
            {
                HashSet<Vertex> visited = new HashSet<Vertex>();
                Stack<Vertex> stack = new Stack<Vertex>();
                List<string> result = new List<string>();

                foreach (var vertex in adjacencyList.Keys)
                {
                    if (!visited.Contains(vertex))
                    {
                        DFSHelper(vertex, visited, stack, result);
                    }
                }

                return string.Join(" -> ", result);
            }

            private void DFSHelper(Vertex start, HashSet<Vertex> visited, Stack<Vertex> stack, List<string> result)
            {
                visited.Add(start);
                stack.Push(start);

                while (stack.Count > 0)
                {
                    Vertex current = stack.Pop();
                    result.Add(current.Label);

                    foreach (var neighbor in adjacencyList[current])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            stack.Push(neighbor);
                        }
                    }
                }
            }
        }
        #endregion

        public class BubbleSort
        {
            public static void Sort(int[] array)
            {
                if (array == null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                int n = array.Length;

                for (int i = 0; i < n - 1; i++)
                {
                    for (int j = 0; j < n - i - 1; j++)
                    {
                        if (array[j] > array[j + 1])
                        {
                            Swap(ref array[j], ref array[j + 1]);
                        }
                    }
                }
            }

            private static void Swap(ref int a, ref int b)
            {
                int temp = a;
                a = b;
                b = temp;
            }
        }
        public class SelectionSort
        {
            public static void Sort(int[] array)
            {
                if (array == null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                int n = array.Length;

                for (int i = 0; i < n - 1; i++)
                {
                    int minIndex = i;
                    for (int j = i + 1; j < n; j++)
                    {
                        if (array[j] < array[minIndex])
                        {
                            minIndex = j;
                        }
                    }
                    Swap(ref array[i], ref array[minIndex]);
                }
            }

            private static void Swap(ref int a, ref int b)
            {
                int temp = a;
                a = b;
                b = temp;
            }
        }
        public class InsertionSort
        {
            public static void Sort(int[] array)
            {
                if (array == null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                int n = array.Length;

                for (int i = 1; i < n; i++)
                {
                    int key = array[i];
                    int j = i - 1;
                    while (j >= 0 && array[j] > key)
                    {
                        array[j + 1] = array[j];
                        j = j - 1;
                    }

                    array[j + 1] = key;
                }
            }
        }
        public class MergeSort
        {
            public static void Sort(int[] array)
            {
                if (array == null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                int n = array.Length;

                if (n > 1)
                {
                    int mid = n / 2;

                    // تقسیم آرایه به دو نیمه
                    int[] leftArray = new int[mid];
                    int[] rightArray = new int[n - mid];

                    Array.Copy(array, 0, leftArray, 0, mid);
                    Array.Copy(array, mid, rightArray, 0, n - mid);

                    // فراخوانی بازگشتی برای مرتب‌سازی هر دو نیمه
                    Sort(leftArray);
                    Sort(rightArray);

                    // ادغام دو نیمه مرتب‌شده
                    Merge(array, leftArray, rightArray);
                }
            }

            private static void Merge(int[] array, int[] leftArray, int[] rightArray)
            {
                int i = 0, j = 0, k = 0;
                int leftLength = leftArray.Length;
                int rightLength = rightArray.Length;

                while (i < leftLength && j < rightLength)
                {
                    if (leftArray[i] <= rightArray[j])
                    {
                        array[k] = leftArray[i];
                        i++;
                    }
                    else
                    {
                        array[k] = rightArray[j];
                        j++;
                    }
                    k++;
                }
                while (i < leftLength)
                {
                    array[k] = leftArray[i];
                    i++;
                    k++;
                }

                while (j < rightLength)
                {
                    array[k] = rightArray[j];
                    j++;
                    k++;
                }
            }

        }
        public class QuickSort
        {
            public static void Sort(int[] array)
            {
                if (array == null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                int n = array.Length;
                QuickSortAlgorithm(array, 0, n - 1);
            }

            private static void QuickSortAlgorithm(int[] array, int low, int high)
            {
                if (low < high)
                {
                    int partitionIndex = Partition(array, low, high);

                    // فراخوانی بازگشتی برای مرتب‌سازی دو نیمه
                    QuickSortAlgorithm(array, low, partitionIndex - 1);
                    QuickSortAlgorithm(array, partitionIndex + 1, high);
                }
            }

            private static int Partition(int[] array, int low, int high)
            {
                int pivot = array[high];
                int i = low - 1;

                for (int j = low; j <= high - 1; j++)
                {
                    if (array[j] < pivot)
                    {
                        i++;
                        Swap(array, i, j);
                    }
                }

                Swap(array, i + 1, high);
                return i + 1;
            }

            private static void Swap(int[] array, int i, int j)
            {
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
        }
        public class BucketSort
        {
            public static void Sort(float[] array)
            {
                if (array == null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                int n = array.Length;
                List<float>[] buckets = new List<float>[n];
                for (int i = 0; i < n; i++)
                {
                    buckets[i] = new List<float>();
                }
                for (int i = 0; i < n; i++)
                {
                    int bucketIndex = (int)(n * array[i]);
                    buckets[bucketIndex].Add(array[i]);
                }
                for (int i = 0; i < n; i++)
                {
                    buckets[i].Sort();
                }
                int index = 0;
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < buckets[i].Count; j++)
                    {
                        array[index++] = buckets[i][j];
                    }
                }
            }
        }
        public class CountingSort
        {
            public static void Sort(int[] array)
            {
                if (array == null)
                {
                    throw new ArgumentNullException(nameof(array));
                }

                int n = array.Length;

                int max = array[0];
                for (int i = 1; i < n; i++)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                    }
                }

                int[] count = new int[max + 1];

                for (int i = 0; i < n; i++)
                {
                    count[array[i]]++;
                }

                for (int i = 1; i <= max; i++)
                {
                    count[i] += count[i - 1];
                }

                int[] result = new int[n];

                for (int i = n - 1; i >= 0; i--)
                {
                    result[count[array[i]] - 1] = array[i];
                    count[array[i]]--;
                }

                for (int i = 0; i < n; i++)
                {
                    array[i] = result[i];
                }
            }
        }
    }
}
