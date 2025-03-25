using EmergencyNavigation.Core.Model;
using EmergencyNavigation.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Numerics;
using System.Drawing;
using EmergencyNavigation.Core.Services;

namespace EmergencyNavigation.Service
{
    public class NavigationService : INavigationService
    {
        private readonly ICommunicationService communicationService;
        private readonly IBuildingService buildingService;
        private readonly IVertexServices vertexServices;
        public NavigationService(IBuildingService buildingService,ICommunicationService communicationService,IVertexServices vs) { 
            this.buildingService = buildingService;
            this.communicationService = communicationService;
            this.vertexServices = vs;

        }
        public NavigationWithLength NavigationToDefribrelator(long sourceId)
        {
            Vertex source=vertexServices.GetVertexById(sourceId);
            long buildingId = source.Floor.BuildingId;
            List<Floor> floors = buildingService.FloorsByBuildingId(buildingId) ;
            List<Vertex> vertices = floors.SelectMany(floor => floor.Vertices).ToList();
            List<User> paramedics = vertices.SelectMany(vertex => vertex.Users).Where(user=>user.IsParamedic).ToList();
            communicationService.sendMassegesToParamedics(paramedics,source);
            List<Dictionary<Vertex, object>> dijkstraResult = Dijkstra(source, vertices);
            Vertex defribrelater = FindDefribrelator(dijkstraResult[0], vertices);
            List<Vertex> navigation = NavigationToSafeArea(defribrelater, dijkstraResult[1]);
            return new NavigationWithLength(navigation, (double)dijkstraResult[0][defribrelater]);
        }
        public NavigationWithLength NavigationToProtectedRoom(long sourceId)
        {
            Vertex source = vertexServices.GetVertexById(sourceId);
            long buildingId = source.Floor.BuildingId;
            List<Floor> floors = buildingService.FloorsByBuildingId(buildingId).Where(floor => Math.Abs(floor.FloorNumber - source.Floor.FloorNumber) <= 2).ToList();;
            List<Vertex> vertices =floors.SelectMany(floor=> floor.Vertices).ToList();
            List<Dictionary<Vertex, object>> dijkstraResult=Dijkstra(source, vertices);
            Vertex protectedRoom = FindProtectedRoom(dijkstraResult[0], vertices);
            List<Vertex> navigation = NavigationToSafeArea(protectedRoom, dijkstraResult[1]);
            return new NavigationWithLength(navigation, (double)dijkstraResult[0][protectedRoom]);
        }
        public NavigationWithLength NavigationToProtectedRoomWithOutStaircase(long sourceId)
        {
            Vertex source = vertexServices.GetVertexById(sourceId);
            long buildingId = source.Floor.BuildingId;
            List<Floor> floors = buildingService.FloorsByBuildingId(buildingId).Where(floor => Math.Abs(floor.FloorNumber - source.Floor.FloorNumber) <= 2).ToList(); ;
            List<Vertex> vertices = floors.SelectMany(floor => floor.Vertices).ToList();
            List<Dictionary<Vertex, object>> dijkstraResult = Dijkstra(source, vertices);
            Vertex protectedRoom = FindProtectedRoomWithOutStaircase(dijkstraResult[0], vertices);
            List<Vertex> navigation = NavigationToSafeArea(protectedRoom, dijkstraResult[1]);
            return new NavigationWithLength(navigation, (double)dijkstraResult[0][protectedRoom]);
        }
        public NavigationWithLength NavigationToTopFloor(long sourceId)
        {
            Vertex source = vertexServices.GetVertexById(sourceId);
            long buildingId = source.Floor.BuildingId;
            List<Floor> floors = buildingService.FloorsByBuildingId(buildingId).Where(floor => floor.FloorNumber >= source.Floor.FloorNumber).ToList(); ;
            List<Vertex> vertices = floors.SelectMany(floor => floor.Vertices).ToList();
            List<Dictionary<Vertex, object>> dijkstraResult = Dijkstra(source, vertices);
            Vertex topFloor = FindTopFloor(dijkstraResult[0], vertices);
            List<Vertex> navigation = NavigationToSafeArea(topFloor, dijkstraResult[1]);
            return new NavigationWithLength(navigation, (double)dijkstraResult[0][topFloor]);
        }
        public NavigationWithLength NavigationToExitingTheBuilding(long sourceId)
        {
            Vertex source = vertexServices.GetVertexById(sourceId);
            long buildingId = source.Floor.BuildingId;
            List<Floor> floors = buildingService.FloorsByBuildingId(buildingId).Where(floor => floor.FloorNumber <= source.Floor.FloorNumber).ToList(); ;
            List<Vertex> vertices = floors.Where(floor => floor.Vertices != null).SelectMany(floor => floor.Vertices).ToList();
            List<Dictionary<Vertex, object>> dijkstraResult = Dijkstra(source, vertices);
            Vertex exitingBuilding = FindExitingBuilding(dijkstraResult[0], vertices);
            List<Vertex> navigation = NavigationToSafeArea(exitingBuilding, dijkstraResult[1]);
            return new NavigationWithLength(navigation, (double)dijkstraResult[0][exitingBuilding]);
        }
        public NavigationWithLength NavigationToExitingTheBuildingOrToProtectedRoomWithOutStaircase(long sourceId)
        {
            NavigationWithLength exitingTheBuildin = NavigationToProtectedRoomWithOutStaircase(sourceId);
            NavigationWithLength protectedRoom = NavigationToExitingTheBuilding(sourceId);
            return exitingTheBuildin.Length + 100 < protectedRoom.Length ? exitingTheBuildin : protectedRoom;
        }
        public List<Dictionary<Vertex, object>> Dijkstra(Vertex source, List<Vertex> graph)
        {
            Vertex s = vertexServices.GetVertexById(source.Id);
            Dictionary<Vertex, double> distances = graph.ToDictionary(v => v, v => double.MaxValue);
            Dictionary<Vertex, Vertex> previous = graph.ToDictionary(v => v, v => (Vertex?)null);
            distances[s] = 0;
            MinHeap minHeap = new MinHeap(graph.Count());
            for (int i = 0; i < graph.Count; i++)
            {
                minHeap.Enqueue(graph[i], distances[graph[i]]);
            }
            while (minHeap.Count() > 0)
            {
                Vertex vertex = minHeap.Dequeue();
                foreach (Edge edge in vertex.Edges)
                {
                    if (distances.ContainsKey(edge.Vertex)) { 
                    if (distances[edge.Vertex] > distances[vertex] + edge.Meters)
                    {
                        distances[edge.Vertex] = distances[vertex] + edge.Meters;
                        previous[edge.Vertex] = vertex;
                        minHeap.ChangePriority(edge.Vertex, distances[edge.Vertex]);
                    }
                    }
                }
            }
            return new List<Dictionary<Vertex, object>>
    {
        distances.ToDictionary(kv => kv.Key, kv => (object)kv.Value),
        previous.ToDictionary(kv => kv.Key, kv => (object)kv.Value)
    };
        }
        public Vertex FindDefribrelator(Dictionary<Vertex, object> distances, List<Vertex> graph)
        {
            double minDistance = double.MaxValue;
            Vertex vertex = graph[0];
            ;
            for (int i = 1; i < graph.Count; i++)
            {
                if (graph[i].MainCharacterization.Name.Equals("defribrelator") || graph[i].SecondaryCharacterization.Name.Equals("defribrelator")
                    )
                {
                    if ((double)distances[graph[i]] < minDistance)
                    {
                        minDistance = (double)distances[graph[i]];
                        vertex = graph[i];
                    }
                }
            }
            return vertex;
        }
        public Vertex FindProtectedRoom(Dictionary<Vertex, object> distances, List<Vertex> graph)
        {
            double minDistance= double.MaxValue;
            Vertex vertex = graph[0];
                ;
            for(int i = 1; i < graph.Count; i++)
            {
                if (graph[i].MainCharacterization.Name.Equals("protected room")|| graph[i].SecondaryCharacterization.Name.Equals("protected room")
                    )
                {
                    if ((double)distances[graph[i]] < minDistance)
                    {
                        minDistance = (double)distances[graph[i]];
                        vertex = graph[i];
                    }
                }
            }
            return vertex;
        }
        public Vertex FindProtectedRoomWithOutStaircase(Dictionary<Vertex, object> distances, List<Vertex> graph)
        {
            double minDistance = double.MaxValue;
            Vertex vertex = graph[0];
            ;
            for (int i = 1; i < graph.Count; i++)
            {
                if (graph[i].MainCharacterization.Name.Equals("protected room"))
                {
                    if ((double)distances[graph[i]] < minDistance)
                    {
                        minDistance = (double)distances[graph[i]];
                        vertex = graph[i];
                    }
                }
            }
            return vertex;
        }
        public Vertex FindTopFloor(Dictionary<Vertex, object> distances, List<Vertex> graph)
        {
            double minDistance = double.MaxValue;
            Vertex vertex = graph[0];
            ;
            for (int i = 1; i < graph.Count; i++)
            {
                if (graph[i].MainCharacterization.Name.Equals("top floor") || graph[i].SecondaryCharacterization.Name.Equals("top floor")
                    )
                {
                    if ((double)distances[graph[i]] < minDistance)
                    {
                        minDistance = (double)distances[graph[i]];
                        vertex = graph[i];
                    }
                }
            }
            return vertex;
        }
        public Vertex FindExitingBuilding(Dictionary<Vertex, object> distances, List<Vertex> graph)
        {
            double minDistance = double.MaxValue;
            Vertex vertex = graph[0];
            ;
            for (int i = 0; i < graph.Count; i++)
            {
                if (graph[i].MainCharacterization.Name.Equals("entry"))
                {      
                    if ((double)distances[graph[i]] < minDistance)
                    {
                        minDistance = (double)distances[graph[i]];
                        vertex = graph[i];
                    }
                }
            }
            return vertex;
        }      
        public List<Vertex> NavigationToSafeArea(Vertex vertex, Dictionary<Vertex, object> prevous)
        {
            Vertex tempVertex = vertex;
            List<Vertex> navigation = new List<Vertex>();
            while (tempVertex != null)
            {
                navigation.Add(tempVertex);
                tempVertex = (Vertex)prevous[tempVertex];
            }
            navigation.Reverse();
            return navigation;
        }

    }
}