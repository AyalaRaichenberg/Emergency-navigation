using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;


namespace EmergencyNavigation.Service
{
    public class MinHeap 

    {
        private VertexWithPriority[] priorityQueue;
        private Dictionary<Vertex, int> indexes;
        private int maxIndex;

        public MinHeap(int numberOfElements)
        {
            priorityQueue = new VertexWithPriority[numberOfElements];
            maxIndex = -1;
            indexes = new Dictionary<Vertex, int>();
        }
        public int Count() { return this.maxIndex; }
        private void SiftUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = index / 2;

                if (priorityQueue[index].Priority < priorityQueue[parentIndex].Priority)
                {
                    var currentVertex = priorityQueue[index].Vertex;
                    var parentVertex = priorityQueue[parentIndex].Vertex;
                    var temp = priorityQueue[index];
                    priorityQueue[index] = priorityQueue[parentIndex];
                    priorityQueue[parentIndex] = temp;
                    indexes[currentVertex] = parentIndex;
                    indexes[parentVertex] = index;
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void SiftDown(int index)
        {
            while (true)
            {
                int smallest = index;
                int leftChild = index * 2;
                int rightChild = index * 2 + 1;

                if (leftChild <= maxIndex && priorityQueue[leftChild].Priority < priorityQueue[smallest].Priority)
                {
                    smallest = leftChild;
                }

                if (rightChild <= maxIndex && priorityQueue[rightChild].Priority < priorityQueue[smallest].Priority)
                {
                    smallest = rightChild;
                }

                if (smallest != index)
                {
                    var currentVertex = priorityQueue[index].Vertex;
                    var smallestVertex = priorityQueue[smallest].Vertex;
                    var temp = priorityQueue[index];
                    priorityQueue[index] = priorityQueue[smallest];
                    priorityQueue[smallest] = temp;
                    indexes[currentVertex] = smallest;
                    indexes[smallestVertex] = index;
                    index = smallest;
                }
                else
                {break;}
            }
        }

        public void Enqueue(Vertex vertex, double priority)
        {
            this.maxIndex++;
            this.indexes.Add(vertex, this.maxIndex);
            Console.WriteLine("index :"+vertex.Id);
            this.priorityQueue[this.maxIndex] = new VertexWithPriority(vertex, priority);
            SiftUp(this.maxIndex);


        }
        public Vertex Dequeue()
        {
            Vertex vertex = this.priorityQueue[0].Vertex;
            this.priorityQueue[0] = this.priorityQueue[this.maxIndex];
            this.maxIndex--;
            this.indexes[this.priorityQueue[0].Vertex] = 0;
            this.indexes.Remove(vertex);
            SiftDown(0);
            return vertex;
        }
        public void ChangePriority(Vertex vertex, double priority)
        {
            int index = this.indexes[vertex];
            double oldPriority = this.priorityQueue[index].Priority;
            this.priorityQueue[index].Priority = priority;
            if (priority < oldPriority)
            {
                SiftUp(index);
            }
            else if (priority > oldPriority)
            {
                SiftDown(index);
            }
        }

        public void Print()
        {
            for (int i = 0; i <= this.maxIndex; i++)
            {
                Console.WriteLine(this.priorityQueue[i].Priority);
            }
        }
    }
}