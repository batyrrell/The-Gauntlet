using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehaviorTree1
{
    public class Node
    {
        public enum Status { SUCCESS, RUNNING, FAILURE };
        public Status status;
        public List<Node> children = new List<Node>();
        public int currentChild = 0;
        public string nodeName;

        public Node() { }

        public Node(string n)
        {
            nodeName = n;
        }

        public virtual Status Process()
        {
            return children[currentChild].Process();
        }

        public void AddChild(Node n)
        {
            children.Add(n);
        }
    }
}
