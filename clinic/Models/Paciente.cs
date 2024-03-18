using System.ComponentModel.DataAnnotations;

namespace clinic.Models
{
    public class Paciente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Campo Convênio é Obrigatório, Caso o Paciente não possui convênio poderá colocar Particular")]
        public string Convenio { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo Gênero é obrigatório.")]
        public string Genero { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }
        public IList<Consulta>? Consultas { get; set; }
        public int PacienteID { get; internal set; }
    }
}
