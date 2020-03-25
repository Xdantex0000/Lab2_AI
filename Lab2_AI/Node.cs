using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Lab2_AI
{
    class Node
    {
        /// Имя вершины.
        public int[] holes = new int[7];
        public int Value { get; set; }
        public int Depth { get; set; }

        /// Список соседних вершин.
        public List<Node> Children { get; }

        public Node(int[] arr)
        {
            this.holes = arr;
            Children = new List<Node>();
        }

        /// Добавляет новую соседнюю вершину.
        public Node AddChildren(Node node, bool bidirect = false)
        {
            Children.Add(node);

            if (bidirect)
            {
                node.Children.Add(this);
            }
            return this;
        }
    }
}
