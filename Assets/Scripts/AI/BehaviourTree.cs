using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree
{
    private List<IBehaviourNode> nodes = new List<IBehaviourNode>();

    public void AddNode(IBehaviourNode node)
    {
        nodes.Add(node);
    }

    public void Execute()
    {
        foreach (var node in nodes)
        {
            node.Execute();
        }
    }
}

public interface IBehaviourNode
{
    void Execute();
}