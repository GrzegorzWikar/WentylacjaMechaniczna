using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WentylacjaMechaniczna.Models
{
    public class Floor : List<Room>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Floor(string name, List<Room> rooms) : base(rooms)
        {
            Name = name;
        }

    }
}
