using System.ComponentModel.DataAnnotations;

namespace ItemFinder.Models
{
    public class ItemLocation
    {
        [Range(-90, 90, ErrorMessage = "Values are supposed to be between - 90 and 90")]
        public double X { get; set; }
        [Range(-90, 90, ErrorMessage = "Values are supposed to be between - 90 and 90")]
        public double Y { get; set; }
    }
}