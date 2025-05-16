using System.ComponentModel.DataAnnotations;

namespace GonzalezF_RicaldeN_Boadad_EspinozaA.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; }

        public List<GuardarInformacionChat> Respuestas { get; set; }
    }
}
