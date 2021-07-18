using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Graph
{
    public List<Node> nodes;
    public List<Edge> edges;

    public Graph()
    {
        nodes = new List<Node>();
        edges = new List<Edge>();
    }

    public void AddNode(Vector3 worldPosition)
    {
        Vector3 setWorldPos = new Vector3(worldPosition.x, worldPosition.y + 0.2f, worldPosition.z);
        nodes.Add(new Node(nodes.Count, setWorldPos));
    }

    public void AddEdge(Node from, Node to, float weight = 1f)
    {
        edges.Add(new Edge(from, to, weight));
    }

    //Kiểm tra xem 2 nút Form - To có liền kề nhau ko
    public bool Adjacent(Node from, Node to)
    {
        foreach (Edge e in edges)
        {
            if (e.from == from && e.to == to)
                return true;
        }
        return false;
    }

    //Trả ra list các Nút nằm xung quanh nút form
    public List<Node> Neighbors(Node from)
    {
        List<Node> result = new List<Node>();
        foreach (Edge e in edges)
        {
            if (e.from == from)
                result.Add(e.to);
        }
        return result;
    }

    public float Distance(Node from, Node to)
    {
        foreach(Edge e in edges)
        {
            if (e.from == from && e.to == to)
                return e.GetWeight();
        }
        return Mathf.Infinity;
    }

    /// <summary>
    /// Tìm ra node để Unit đáp xuông sau khi dash qua target
    /// </summary>
    /// <param name="dash_target"></param>
    /// <returns></returns>
    public Node Get_Free_Node_forDash(BaseEntiny unit, Node dash_target)
    {
        float Distance_from_Unit_to_Node_Free = 0;
        Node dashTo = null;
        foreach(Node to in Neighbors(dash_target))
        {
            if(Vector3.Distance(unit.transform.position,to.worldPosition)  >= Distance_from_Unit_to_Node_Free)
            {
                Distance_from_Unit_to_Node_Free = Vector3.Distance(unit.transform.position, to.worldPosition);
                dashTo = to;
            }
        }
        return dashTo;
    }

    //Tìm ra con đường ngắn nhất đi từ nút Start tới nút End
    //
    public virtual List<Node> GetShortestPath(Node start, Node end)
    {
        List<Node> path = new List<Node>();
        if(start == end)
        {
            path.Add(start);
            return path;
        }
        List<Node> openlist = new List<Node>();
        Dictionary<Node, Node> previous = new Dictionary<Node, Node>();
        Dictionary<Node, float> distances = new Dictionary<Node, float>();

        for(int i = 0; i <nodes.Count; i++)
        {
            openlist.Add(nodes[i]);
            distances.Add(nodes[i], float.PositiveInfinity);  //default distance is infinity
        }
        
        distances[start] = 0f; //distance from the same node is zero
        
        while (openlist.Count > 0)
        {   

            //Get the node with smaller distance
            openlist = openlist.OrderBy(x => distances[x]).ToList();
            Node current = openlist[0];
            openlist.Remove(current);

            if(current == end)
            {   

                //done!
                while (previous.ContainsKey(current))
                {
                    path.Insert(0, current);
                    current = previous[current];
                }
                path.Insert(0, current);
                break;
            }
            foreach (Node neighbor in Neighbors(current))
            {
                float distance = Distance(current, neighbor);

                float candidateNewDistance = distances[current] + distance;

                if(candidateNewDistance < distances[neighbor])
                {
                    distances[neighbor] = candidateNewDistance;
                    previous[neighbor] = current;
                }
            }
           
        }
        return path;
    }
}

/// <summary>
/// Class Node là class tạo ra các nút trên titlemap
/// các Nút này gồm index là số thứ tự của nút, wordPosition là vị trí của nút trên titlemap
/// occupied là biến kiểm tra xem trên nút đó đã có người chưa
/// </summary>
public class Node
{
    public int index;
    public Vector3 worldPosition;

    public bool occupied = false;
    public bool IsOccupided => occupied;

    public Node(int index, Vector3 worldPosition)
    {
        this.index = index;
        this.worldPosition = worldPosition;
        occupied = false;
    }
    public void SetOccupied(bool val)
    {
        occupied = val;
    }
}


/// <summary>
/// Class Edge là class về cạnh. 
/// Cạnh sẽ nằm giữa 2 nút, 1 đầu là nút Form -> 1 đầu nút To
/// Chiều dài
/// </summary>
public class Edge
{
    public Node from;
    public Node to;

    private float weight;

    public Edge(Node from, Node to, float weight)
    {
        this.from = from;
        this.to = to;
        this.weight = weight;
    }

    public float GetWeight()
    {
        if (to.IsOccupided)
        {
            return Mathf.Infinity;
        }
        return weight;
    }
}

