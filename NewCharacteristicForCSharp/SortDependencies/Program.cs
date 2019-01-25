﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortDependencies
{
    // Item 定义
    public class Item
    {
        // 条目名称
        public string Name { get; private set; }
        // 依赖项
        public Item[] Dependencies { get; set; }

        public Item(string name, params Item[] dependencies)
        {
            Name = name;
            Dependencies = dependencies;
        }

        public override string ToString()
        {
            return Name;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var moduleA = new Item("Module A");
            var moduleC = new Item("Module C", moduleA);
            var moduleB = new Item("Module B", moduleC);
            var moduleE = new Item("Module E", moduleB);
            var moduleD = new Item("Module D", moduleE);

            var unsorted = new[] { moduleE, moduleA, moduleD, moduleB, moduleC };

            var sorted = Sort(unsorted, x => x.Dependencies);

            foreach (var item in sorted)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadLine();
        }
        public static IList<T> Sort<T>(IEnumerable<T> source, Func<T, IEnumerable<T>> getDependencies)
        {
            var sorted = new List<T>();
            var visited = new Dictionary<T, bool>();

            foreach (var item in source)
            {
                Visit(item, getDependencies, sorted, visited);
            }

            return sorted;
        }
        public static void Visit<T>(T item, Func<T, IEnumerable<T>> getDependencies, List<T> sorted, Dictionary<T, bool> visited)
        {
            bool inProcess;
            var alreadyVisited = visited.TryGetValue(item, out inProcess);

            // 如果已经访问该顶点，则直接返回
            if (alreadyVisited)
            {
                // 如果处理的为当前节点，则说明存在循环引用
                if (inProcess)
                {
                    throw new ArgumentException("Cyclic dependency found.");
                }
            }
            else
            {
                // 正在处理当前顶点
                visited[item] = true;

                // 获得所有依赖项
                var dependencies = getDependencies(item);
                // 如果依赖项集合不为空，遍历访问其依赖节点
                if (dependencies != null)
                {
                    foreach (var dependency in dependencies)
                    {
                        // 递归遍历访问
                        Visit(dependency, getDependencies, sorted, visited);
                    }
                }

                // 处理完成置为 false
                visited[item] = false;
                sorted.Add(item);
            }
        }
    }

}
