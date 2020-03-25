using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows;
using System.Linq;

namespace Lab2_AI
{
    class Program
    {
        static public bool AddValues(Node node) // Method that make right values of nodes for RBFS
        {
            int iterator = 0;
            node.Value = 999;

            #region AddPath
            List<int[]> res_arr = new List<int[]>(); // List for making right value for RBFS
            res_arr.Add(new int[] { 1, 1, 1, 1, 3, 2, 3, 3 });
            res_arr.Add(new int[] { 1, 1, 1, 2, 3, 1, 3, 3 });
            res_arr.Add(new int[] { 1, 1, 2, 1, 3, 1, 3, 3 });
            res_arr.Add(new int[] { 1, 1, 3, 1, 2, 1, 3, 3 });
            res_arr.Add(new int[] { 1, 1, 3, 1, 3, 1, 2, 3 });
            res_arr.Add(new int[] { 1, 1, 3, 1, 3, 1, 3, 2 });
            res_arr.Add(new int[] { 1, 1, 3, 1, 3, 2, 3, 1 });
            res_arr.Add(new int[] { 1, 1, 3, 2, 3, 1, 3, 1 });
            res_arr.Add(new int[] { 1, 2, 3, 1, 3, 1, 3, 1 });
            res_arr.Add(new int[] { 2, 1, 3, 1, 3, 1, 3, 1 });
            res_arr.Add(new int[] { 3, 1, 2, 1, 3, 1, 3, 1 });
            res_arr.Add(new int[] { 3, 1, 3, 1, 2, 1, 3, 1 });
            res_arr.Add(new int[] { 3, 1, 3, 1, 3, 1, 2, 1 });
            res_arr.Add(new int[] { 3, 1, 3, 1, 3, 2, 1, 1 });
            res_arr.Add(new int[] { 3, 1, 3, 2, 3, 1, 1, 1 });
            res_arr.Add(new int[] { 3, 2, 3, 1, 3, 1, 1, 1 });
            res_arr.Add(new int[] { 3, 3, 2, 1, 3, 1, 1, 1 });
            res_arr.Add(new int[] { 3, 3, 3, 1, 2, 1, 1, 1 });
            res_arr.Add(new int[] { 3, 3, 3, 2, 1, 1, 1, 1 });
            #endregion
            foreach (var x in res_arr)
            {
                iterator++;
                if (x.SequenceEqual(node.holes))
                {
                    node.Value = 20 - iterator;
                }
            }
            foreach (var x in node.Children)
                AddValues(x);

            return true;
        }
        static public bool GraphBuild(Node node, ref List<int[]> in_arr) // Method of building the graph oh solvation
        {
            Node node_child = new Node(new int[8]);
            bool added = false, repeat_check = false;
            int arr_size = 8, position = 0, depth = 0;

            position = Array.IndexOf(node.holes, 2);

            // Left branch
            if (position != 0 && node.holes[position - 1] == 1)
            {
                node_child.holes = (int[])node.holes.Clone();
                node_child.holes[position] = 1;
                node_child.holes[position - 1] = 2;
                // Check the repeating
                foreach (var x in in_arr)
                {
                    if (x.SequenceEqual(node_child.holes))
                    {
                        repeat_check = true;
                        break;
                    }
                }
                // If this node wasn't added
                if (repeat_check == false)
                {
                    in_arr.Add(node_child.holes);
                }
                depth = node.Depth;
                node_child.Depth = --depth;

                node_child.Value = node_child.Depth;
                node.AddChildren(node_child);
                GraphBuild(node_child, ref in_arr);
                node_child = new Node(new int[8]);
                repeat_check = false;

            }

            if (position != 0 && position != 1 && node.holes[position - 2] == 1)
            {
                node_child.holes = (int[])node.holes.Clone();
                node_child.holes[position] = 1;
                node_child.holes[position - 2] = 2;
                // Check the repeating
                foreach (var x in in_arr)
                {
                    if (x.SequenceEqual(node_child.holes))
                    {
                        repeat_check = true;
                        break;
                    }
                }
                // If this node wasn't added
                if (repeat_check == false)
                {
                    in_arr.Add(node_child.holes);
                }
                depth = node.Depth;
                node_child.Depth = --depth;

                node.AddChildren(node_child);
                GraphBuild(node_child, ref in_arr);
                node_child = new Node(new int[8]);
                repeat_check = false;

            }
            if (position != 7 && node.holes[position] == 2 && node.holes[position + 1] == 3)
            {
                node_child.holes = (int[])node.holes.Clone();
                node_child.holes[position] = 3;
                node_child.holes[position + 1] = 2;
                // Check the repeating
                foreach (var x in in_arr)
                {
                    if (x.SequenceEqual(node_child.holes))
                    {
                        repeat_check = true;
                        break;
                    }
                }
                // If this node wasn't added
                if (repeat_check == false)
                {
                    in_arr.Add(node_child.holes);
                }
                depth = node.Depth;
                node_child.Depth = --depth;
                node.AddChildren(node_child);
                GraphBuild(node_child, ref in_arr);
                node_child = new Node(new int[8]);
                repeat_check = false;

            }

            if (position != 7 && position != 6 && node.holes[position] == 2 && node.holes[position + 2] == 3)
            {
                node_child.holes = (int[])node.holes.Clone();
                node_child.holes[position] = 3;
                node_child.holes[position + 2] = 2;
                // Check the repeating
                foreach (var x in in_arr)
                {
                    if (x.SequenceEqual(node_child.holes))
                    {
                        repeat_check = true;
                        break;
                    }
                }
                // If this node wasn't added
                if (repeat_check == false)
                {
                    in_arr.Add(node_child.holes);
                }
                depth = node.Depth;
                node_child.Depth = --depth;

                node.AddChildren(node_child);
                GraphBuild(node_child, ref in_arr);
                node_child = new Node(new int[8]);
                repeat_check = false;

            }

            return true;
        } 
        static public void PrintVector(int[] vector) // Method to print the array
        {
            foreach (var x in vector)
                Console.Write(x + " ");
            Console.WriteLine();
        }
        static public bool RBFS(Node node) // Method of algorithm
        {
            Node minimal = new Node(new int[8]);
            minimal.Value = 999;


            List<Node> arr = new List<Node>();
            // Инициализация: есть информация про начальную вершину
            foreach (var x in node.Children)
                arr.Add(x);
            foreach (var x in arr)
                if (minimal.Value >= x.Value)
                    minimal = x;
            if (node.Value == 0 || node.Children.Count == 0)
                return true;
            PrintVector(minimal.holes);

            RBFS(minimal);
            return true;
        }
        static void Main(string[] args)
        {
            // Inicializing the variables
            List<int[]> in_arr = new List<int[]>();
            int[] first_arr = new int[] { 1, 1, 1, 1, 2, 3, 3, 3 };
            Node n0 = new Node(first_arr);
            n0.Depth = 20;

            in_arr.Add(first_arr);
            Console.WriteLine("1 - black circle");
            Console.WriteLine("2 - void circle");
            Console.WriteLine("3 - white circle\n");

            Console.WriteLine("Algorithm of solving the exercise: ");
            PrintVector(n0.holes);
            GraphBuild(n0,ref in_arr);
            AddValues(n0);
            n0.Value = 20; // rebind the value of root

            RBFS(n0);
        }
    }
}