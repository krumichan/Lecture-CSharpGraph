using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    class GraphBFS
    {
        int[,] array = new int[6, 6]
        {
              { 0, 1, 0, 1, 0, 0 }
            , { 1, 0, 1, 1, 0, 0 }
            , { 0, 1, 0, 0, 0, 0 }
            , { 1, 1, 0, 0, 1, 0 }
            , { 0, 0, 0, 1, 0, 1 }
            , { 0, 0, 0, 0, 1, 0 }
        };

        List<int>[] list = new List<int>[]
        {
              new List<int> { 1, 3 }
            , new List<int> { 0, 2, 3 }
            , new List<int> { 1 }
            , new List<int> { 0, 1, 4 }
            , new List<int> { 3, 5 }
            , new List<int> { 4 }
        };

        public void ArrayBFS(int start)
        {
            bool[] found = new bool[6];
            int[] parent = new int[6];
            int[] distance = new int[6];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            found[start] = true;
            parent[start] = start;
            distance[start] = 0;

            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                Console.WriteLine(now);

                for (int next = 0; next < 6; ++next)
                {
                    // 인접하지 않을경우 무시.
                    if (array[now, next] == 0)
                        continue;

                    // 이미 방문한 곳이라면 무시.
                    if (found[next])
                        continue;

                    // 다음 정점을 예약.
                    queue.Enqueue(next);

                    found[next] = true;
                    parent[next] = now; // "다음 정점"의 부모 : "현재 정점"
                    distance[next] = distance[now] + 1; // "다음 정점 거리" : "현재 거리" + 1
                }
            }
        }

        public void ListBFS(int start)
        {
            bool[] found = new bool[6];
            int[] parent = new int[6];
            int[] distance = new int[6];

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(start);

            found[start] = true;
            parent[start] = start;
            distance[start] = 0;

            while (queue.Count > 0)
            {
                int now = queue.Dequeue();
                Console.WriteLine(now);

                foreach (int next in list[now])
                {
                    // 이미 방문한 곳이라면 무시.
                    if (found[next])
                        continue;

                    // 다음 정점을 예약.
                    queue.Enqueue(next);

                    found[next] = true;
                    parent[next] = now; // "다음 정점"의 부모 : "현재 정점"
                    distance[next] = distance[now] + 1; // "다음 정점 거리" : "현재 거리" + 1
                }
            }
        }
    }
}
