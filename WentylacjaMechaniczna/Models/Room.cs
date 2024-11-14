using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WentylacjaMechaniczna.Models
{
    public class Room
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name = "Nazwa Pomieszczenia";
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