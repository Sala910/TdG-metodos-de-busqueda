using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Алгоритм_построения_кратчайших_путей_КиТГ
{
    class Graph
    {
        public Dictionary<int, List<int>> AdjList { get; private set; }

        public Graph(int verticesCount)
        {
            AdjList = new Dictionary<int, List<int>>();
            for (int i = 0; i < verticesCount; i++)
                AdjList[i] = new List<int>();
        }

        public void AddEdge(int from, int to)
        {
            AdjList[from].Add(to);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем граф
            Graph graph = new Graph(5); // Граф с 5 вершинами

            // Добавляем рёбра (неориентированный граф)
            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            // Запускаем BFS от вершины 0
            BFS(graph, 0);
        }

        public static void BFS(Graph graph, int start)
        {
            Queue<int> queue = new Queue<int>();
            Dictionary<int, int> distances = new Dictionary<int, int>();

            // Инициализируем расстояния как бесконечность
            foreach (var vertex in graph.AdjList.Keys)
                distances[vertex] = int.MaxValue;

            // Расстояние до начальной вершины 0
            distances[start] = 0;
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                int current = queue.Dequeue();
                Console.WriteLine($"Посещаем вершину {current}, расстояние: {distances[current]}");

                // Исследуем соседей
                foreach (var neighbor in graph.AdjList[current])
                {
                    if (distances[neighbor] == int.MaxValue)
                    {
                        distances[neighbor] = distances[current] + 1;
                        queue.Enqueue(neighbor);
                    }
                }
            }

            // Выводим итоговые расстояния
            Console.WriteLine("\nРасстояния от вершины 0:");
            foreach (var distance in distances)
            {
                Console.WriteLine($"Вершина {distance.Key}: {distance.Value}");
            }
        }
    }
}
