using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
    public class Consulta
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataHoraConsulta { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DataHoraRetorno { get; set; }

        [Required(ErrorMessage = "O campo Status é obrigatório.")]
        public string Status { get; set; } // Agendada, Confirmada, Concluída, Cancelada

        public string ObservacoesAdm { get; set; }

        public string ObservacoesMedica { get; set; }

        [ForeignKey("Paciente")]
        public int? fk_PacienteID { get; set; }
        public Paciente? Paciente { get; set; }

    }
}
