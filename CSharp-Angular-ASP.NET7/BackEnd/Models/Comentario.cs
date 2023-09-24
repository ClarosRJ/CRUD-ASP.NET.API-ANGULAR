using System.ComponentModel.DataAnnotations;

namespace BackEnd.Models
{
    public class Comentario
    {
        public int Id { get; set; }
        [Required] public string? Titulo { get; set; }
        [Required] public string? Creador { get; set; }
        [Required] public string? Texto { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaUpdate { get; set; }

    }
}
