using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmergencyNavigation.Core.Model
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
       
        public string Password { get; set; }
        public long UsualLocalId {  get; set; }
        public Vertex? UsualLocal { get; set; }
        public bool IsParamedic {  get; set; }
    }
}
