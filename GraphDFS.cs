using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    class GraphDFS
    {
        int[,] array = new int[6, 6]
        {
              { 0, 1, 0, 1, 0, 0 }
            , { 1, 0, 1, 1, 0, 0 }
            , { 0, 1, 0, 0, 0, 0 }
            , { 1, 1, 0, 0, 0, 0 }
            , { 0, 0, 0, 0, 0, 1 }
            , { 0, 0, 0, 0, 1, 0 }
        };

        List<int>[] list = new List<int>[]
        {
              new List<int> { 1, 3 }
            , new List<int> { 0, 2, 3 }
            , new List<int> { 1 }
            , new List<int> { 0, 1 }
            , new List<int> { 5 }
            , new List<int> { 4 }
        };

        bool[] arrayVisited = new bool[6];
        bool[] listVisited = new bool[6];

        /// <summary>
        /// 1. now 방문.
        /// 2. now와 연결된 정점을 하나씩 확인, 미방문 상태라면 방문.
        /// </summary>
        /// <param name="now"></param>
        public void ArrayDFS(int now)
        {
            Console.WriteLine(now);
            arrayVisited[now] = true;

            for (int next = 0; next < 6; ++next)
            {
                // 연결되어 있지 않음.
                if (array[now, next] == 0)
                    continue;

                // 이미 방문.
                if (arrayVisited[next])
                    continue;

                // 현재의 위치와 연결되어 있는 다음 정점을 시작.
                ArrayDFS(next);
            }
        }

        public void ListDFS(int now)
        {
            Console.WriteLine(now);
            listVisited[now] = true;

            foreach (int next in list[now])
            {
                // adjList는 연결되어 있는 번호들만 들어있기 때문에,
                // 연결되지 않는 경우를 체크하지 않아도 됨.

                // 이미 방문.
                if (listVisited[next])
                    continue;

                ListDFS(next);
            }
        }

        public void SearchAll()
        {
            arrayVisited = new bool[6];
            for (int now = 0; now < 6; ++now)
            {
                if (!arrayVisited[now])
                    ArrayDFS(now);
            }
        }
    }
}
