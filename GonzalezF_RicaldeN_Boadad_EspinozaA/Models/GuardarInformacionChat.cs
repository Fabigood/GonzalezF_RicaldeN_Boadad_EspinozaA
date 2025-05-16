using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GonzalezF_RicaldeN_Boadad_EspinozaA.Models
{
    public class GuardarInformacionChat
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Respuesta { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public string Proveedor { get; set; } // Gemini, OpenAI, etc.

        [ForeignKey("UsuarioId")]
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
