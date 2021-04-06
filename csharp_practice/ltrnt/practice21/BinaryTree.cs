using System;
namespace csharp_practice.ltrnt.practice21
{
    public class BinaryTree
    {

        private class Node
        {
            public object value;
            public Node left;
            public Node right;
            public int leftChildrenCounter;
            public int rightChildrenCounter;

            public Node(object value)
            {
                this.value = value;
                this.left = null;
                this.right = null;
                this.leftChildrenCounter = 0;
                this.rightChildrenCounter = 0;
            }

            public static void Add(ref Node root, object value)
            {
                if (root == null)
                {
                    root = new Node(value);
                    
                }
                else
                {
                    if (((IComparable)(root.value)).CompareTo(value) > 0)
                    {
                        root.leftChildrenCounter++; // Для решения практики 21.2
                        Add(ref root.left, value);
                    }
                    else
                    {
                        root.rightChildrenCounter++; // Для решения практики 21.2
                        Add(ref root.right, value);
                    }
                }
            }

            public static void Preorder(Node root)
            {
                if (root != null)
                {
                    Console.Write("{0} ", root.value);
                    Preorder(root.left);
                    Preorder(root.right);
                }
            }

            public static Boolean isPerfectlyBalancedTree(Node root)
            {
                if (root == null)
                {
                    return true;
                }
                else if (Math.Abs(root.leftChildrenCounter - root.rightChildrenCounter) > 1)
                {
                    Console.WriteLine(root.value + " " + root.leftChildrenCounter + " " + root.rightChildrenCounter);
                    return false;
                }
                else
                {
                    return isPerfectlyBalancedTree(root.left) && isPerfectlyBalancedTree(root.right);
                }
            }

            public static bool isPossibleToAddValueToPerfectlyBalancedTree(ref Node root, ref int minValue, ref int maxValue)
            {
                if (root == null)
                {
                    return true;
                }
                else if (Math.Abs(root.leftChildrenCounter - root.rightChildrenCounter) > 2)
                {
                    return false;
                }
                else if (root.leftChildrenCounter <= root.rightChildrenCounter)
                {
                    maxValue = (int)root.value;
                    return isPossibleToAddValueToPerfectlyBalancedTree(ref root.left, ref minValue, ref maxValue) && isPerfectlyBalancedTree(root.right);
                }
                else
                {
                    minValue = (int)root.value;
                    return isPossibleToAddValueToPerfectlyBalancedTree(ref root.right, ref minValue, ref maxValue) && isPerfectlyBalancedTree(root.left);
                }
            }
                  
            public static bool HasValue(Node root, int value)
            {
                if (root == null) return false;

                if ((int)root.value == value) return true;

                return HasValue(root.left, value) || HasValue(root.right, value);
            }

            // end of Node class
        }

        Node tree;

        public BinaryTree()
        {
            tree = null;
        }

        private BinaryTree(Node root)
        {
            tree = root;
        }

        public void Add(object value)
        {
            Node.Add(ref tree, value);
        }

        public void Preorder()
        {
            Node.Preorder(tree);
        }

        public bool IsPerfectlyBalancedTree()
        {
            return Node.isPerfectlyBalancedTree(tree);
        }

        // Working with int
        public void IsPossibleToAddValueToPerfectlyBalancedTree()
        {
            int minValue = Int32.MinValue;
            int maxValue = Int32.MaxValue;

            if (Node.isPossibleToAddValueToPerfectlyBalancedTree(ref tree, ref minValue, ref maxValue))
            {
                while (minValue <= maxValue && Node.HasValue(tree, minValue))
                {
                    minValue++;
                }

                Console.WriteLine("Минимально возможное новое значение, при котором дерево будет идеально сбалансированным: " + minValue);
            }
            else
            {
                Console.WriteLine("Невозможно добавить новое значение, при котором дерево будет идеально сбалансированным.");
            }
        }



    }
}
