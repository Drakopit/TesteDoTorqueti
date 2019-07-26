using System;
using System.ComponentModel.DataAnnotations;

namespace TesteDoTorqueti2._0.Domain.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }
    }
}
