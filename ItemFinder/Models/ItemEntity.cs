using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace ItemFinder.Models
{
    public class ItemEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Point Location { get; set; }
    }
}