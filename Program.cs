using System;
using System.Collections.Generic;

namespace Exercise
{
    /**
     * Stack : Last In First Out  ( 후입선출 )
     * Queue : First In First Out ( 선입선출 )
     * */

    class Program
    {
        static void Main(string[] args)
        {
            // DFS ( Depth First Search     , 깊이 우선 탐색 )
            GraphDFS graphDFS = new GraphDFS();

            graphDFS.ArrayDFS(3);
            Console.WriteLine();

            graphDFS.ListDFS(3);
            Console.WriteLine();

            graphDFS.SearchAll();
            Console.WriteLine();

            // BFS ( Breadth First Search   , 너비 우선 탐색 )
            GraphBFS graphBFS = new GraphBFS();
            
            graphBFS.ArrayBFS(0);
            Console.WriteLine();

            graphBFS.ListBFS(0);
            Console.WriteLine();

            // Dijkstra
            GraphDijkstra graphDijkstra = new GraphDijkstra();

            graphDijkstra.arrayDijkstra(0);
            Console.WriteLine();
        }
    }
}
