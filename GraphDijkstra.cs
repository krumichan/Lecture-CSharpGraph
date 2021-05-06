using System;
using System.Collections.Generic;
using System.Text;

namespace Exercise
{
    class GraphDijkstra
    {
        const int DOT_COUNT = 6;
        const int NOT_VALID = Int32.MaxValue;

        int[,] array = new int[DOT_COUNT, DOT_COUNT]
        {
              { -1, 15, -1, 35, -1, -1 }
            , { 15, -1, 05, 10, -1, -1 }
            , { -1, 05, -1, -1, -1, -1 }
            , { 35, 10, -1, -1, 05, -1 }
            , { -1, -1, -1, 05, -1, 05 }
            , { -1, -1, -1, -1, 05, -1 }
        };

        bool[] visited;
        int[] distance;
        int[] parent;

        public void Initialization(int start)
        {
            Initialization();
            distance[start] = 0;
        }

        public void Initialization()
        {
            visited = new bool[DOT_COUNT];
            distance = new int[DOT_COUNT];
            parent = new int[DOT_COUNT];

            Array.Fill(distance, NOT_VALID);
        }

        public void arrayDijkstra(int start)
        {
            Initialization(start);
            DoDijkstra();

            foreach (int dot in parent)
            {
                Console.WriteLine(dot);
            }
        }

        private void DoDijkstra()
        {
            while (true)
            {
                // 현재 정점에서 가장 가까운 정점을 저장할 변수.
                int now = NOT_VALID;

                // 현재 정점에서 가강 가까운 정점을 방문 및 방문한 정점 저장.
                if (!VisitClosestDotFromCurrentDot(ref now))
                    break; // 가장 가까운 정점이 없어서 방문하지 못한 경우.

                // 현재 정점에서 인접한 정점까지의 거리를 조사.
                ServeyAllDotsOfRightNext(now);
            }
        }

        private bool VisitClosestDotFromCurrentDot(ref int nowDot)
        {
            // 현재 정점에서 가장 가까운 정점을 탐색.
            nowDot = FindClosestDot(nowDot);

            // true : 가장 가까운 정점이 존재할경우 방문.
            return VisitIfClosestDotExists(nowDot);
        }

        private int FindClosestDot(int nowDot)
        {
            int closest = NOT_VALID;

            for (int i = 0; i < DOT_COUNT; ++i)
            {
                // 이미 방문한 경우 무시.
                if (IsAlreadyVisited(i))
                    continue;

                // 아직 방문할 수 없는 정점 또는 현재 구해진 최단 정점보다 먼 정점은 무시.
                if (UnknownDistanceOrNotCloest(i, closest))
                    continue;

                // 현재 구해진 최단 정점 거리를 저장.
                closest = distance[i];

                // 현재 구해진 최당 점점을 저장.
                nowDot = i;
            }

            return nowDot;
        }
        
        private bool VisitIfClosestDotExists(int now)
        {
            // true : 가장 가까운 정점이 존재.
            bool closestDotIsExists = IsValidDot(now);
            if (closestDotIsExists)
            {
                visited[now] = closestDotIsExists;
            }
            return closestDotIsExists;
        }

        private void ServeyAllDotsOfRightNext(int now)
        {
            // 방문한 정점에 인접해있는 모든 정점의 최단거리를 조사.

            for (int next = 0; next < DOT_COUNT; ++next)
            {
                // 연결되지 않은 정점.
                if (!IsConnected(now, next))
                    continue;

                // 이미 방문.
                if (IsAlreadyVisited(next))
                    continue;

                // 현재 알려진 시작점부터 인접한 정점까지의 거리보다
                // 가까운 최단 거리가 존재할 경우,
                // 해당 거리를 갱신한다.
                UpdateDistanceIfCloserThan(now, next);
            }
        }

        private void UpdateDistanceIfCloserThan(int now, int next)
        {
            // distance[now] : 시작점부터 현재 정점까지의 거리.
            // array[now, next] : 현재 정점부터 인접한 정점까지의 거리.
            int nextDistance = distance[now] + array[now, next];

            // distance[next] : 현재 알려진 시작점부터 인접한 정점까지의 최단 거리.
            if (nextDistance < distance[next])
            {
                distance[next] = nextDistance;
                parent[next] = now;
            }
        }

        private bool IsValidDot(int dot)
        {
            return dot != NOT_VALID;
        }

        private bool UnknownDistanceOrNotCloest(int index, int closest)
        {
            return NotYetKnownDistance(index) || !IsClosest(index, closest);
        }

        private bool IsClosest(int index, int closest)
        {
            return distance[index] < closest;
        }

        private bool NotYetKnownDistance(int index)
        {
            return distance[index] == NOT_VALID;
        }

        private bool IsAlreadyVisited(int index)
        {
            return visited[index];
        }

        private bool IsConnected(int now, int next)
        {
            return array[now, next] != -1;
        }
    }
}
