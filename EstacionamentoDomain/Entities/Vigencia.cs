using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EstacionamentoDomain.Entities
{
    public class Vigencia
    {
        public int Id { get; set; }
        public bool Ativo { get;set; }

        [DisplayName("Valor da hora")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage="O valor da hora é obrigatório!")]
        public decimal ValorHora { get; set; }

        [DisplayName("Hora adicional")]
        [DataType(DataType.Currency)]
        [Required(ErrorMessage="O valor da hora adicional é obrigatório!")]
        public decimal HoraAdicional { get; set; }

        [DisplayName("Data de início de vigência")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage="O data de início de vigência é obrigatória!")]
        public DateTime VigenciaInicio { get; set; }

        [DisplayName("Data de fim de vigência")]
        [Required(ErrorMessage="O data de fim de vigência é obrigatória!")]
        [DataType(DataType.Date)]
        public DateTime VigenciaFim { get; set; }
    }
}
