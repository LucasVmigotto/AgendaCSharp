using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agenda.Models
{
    public class Contato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContato { get; set; }
        [Required]
        [StringLength(20, MinimumLength=2)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50, MinimumLength=2)]
        public string Sobrenome { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DataDeAniversario { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime DataDeCadastro { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DataDeModificacao { get; set; }

        public Contato(int IdContato, string Nome, string Sobrenome, string Email, DateTime DataDeAniversario, DateTime DataDeCadastro, DateTime DataDeModificacao){
            this.IdContato=IdContato;
            this.Nome=Nome;
            this.Sobrenome=Sobrenome;
            this.Email=Email;
            this.DataDeAniversario=DataDeAniversario;
            this.DataDeCadastro=DataDeCadastro;
            this.DataDeModificacao=DataDeModificacao;
        }

        public Contato(string Nome, string Sobrenome, DateTime DataDeCadastro){
            this.Nome=Nome;
            this.Sobrenome=Sobrenome;
            this.DataDeCadastro=DataDeCadastro;
        }

        public Contato()
        {
            
        }
    }
}