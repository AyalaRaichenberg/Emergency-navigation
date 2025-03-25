import { Floor } from "./floor.model";
import { VertexCharacterization } from "./vertexCharacterization.model";

export class Vertex{
    id!:number;
    roomNumber!:number;
    floor!:Floor;
    MainCharacterization!:VertexCharacterization;
    SecondaryCharacterization?:VertexCharacterization;
}
// public long Id { get; set; }
// public int RoomNumber { get; set; }
// public long FloorId { get; set; }
// public Floor Floor { get; set; }
// public VertexCharacterization MainCharacterization { get; set; }
// public VertexCharacterization SecondaryCharacterization { get; set; }
// public List<Edge> Edges { get; set; }  
// public List<User> Users {  get; set; }