using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WentylacjaMechaniczna
{
    class Room
    {
        public Room(string name, decimal surfaceM2, decimal roomHight)
        {
            Name = name;
            SurfaceM2 = surfaceM2;
            RoomHeight = roomHight;
            Cubage = SurfaceM2 * RoomHeight;
            Exchanges = 1;
            DesignSupplyAirFlowRate = Cubage * Exchanges;
            DesignExhaustAirFlowRate = Cubage * Exchanges;
            AssumedSupplyAirFlowRate = null;
            AssumedExhaustAirFlowRate = null;
        }

        [Required]
        public string Name { get; set; }
        [Required]
        public decimal SurfaceM2 { get; set; }
        [Required]
        public decimal RoomHeight { get; set; }
        [Required]
        public decimal Cubage { get; set; }
        [Required]
        public decimal Exchanges { get; set; }
        [Required]
        public decimal DesignSupplyAirFlowRate { get; set; }
        [Required]
        public decimal DesignExhaustAirFlowRate { get; set; }
        public decimal? AssumedSupplyAirFlowRate { get; set; }
        public decimal? AssumedExhaustAirFlowRate { get; set; }
    }
}