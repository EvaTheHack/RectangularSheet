using System.ComponentModel;

namespace RectangularSheet.Models
{
    public class DetailDto
    {
        [DisplayName("Ширина")]
        public int? Width { get; set; }

        [DisplayName("Высота")]
        public int? Height { get; set; }

        [DisplayName("Кол-во")]
        public int? Count { get; set; }
    }
}
