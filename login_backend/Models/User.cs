using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace login_backend.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("user_name")]
        [StringLength(100)]
        public string UserName{ get; set; }
        [Required]
        [Column("email")]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [Column("pass_word")]
        [StringLength(100)]
        public string Password { get; set; }
        [Required]
        [Column("fecha_registro")]
        [StringLength(100)]
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
    }
}
