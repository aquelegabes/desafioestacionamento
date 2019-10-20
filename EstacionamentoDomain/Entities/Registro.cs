using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EstacionamentoDomain.Entities
{
    public class Registro
    {
        public int Id { get; set; }
        public bool Ativo {get;set;}

        [Required(ErrorMessage="A placa é obrigatório!")]
        public string Placa { get; set; }

        [DisplayName("Data de chegada")]
        [Required(ErrorMessage="A data de chegada é obrigatória!")]
        [DataType(DataType.DateTime)]
        public DateTime Chegada { get; set; }

        [DisplayName("Data de saída")]
        [DataType(DataType.DateTime)]
        public DateTime? Saida { get; set; }

        [DisplayName("Duração")]
        [DataType(DataType.Duration)]
        public TimeSpan? Duracao { get; set; }

        [DisplayName("Tempo cobrado")]
        public int? TempoCobrado { get; set; }

        [DisplayName("Preço")]
        [DataType(DataType.Currency)]
        public decimal? Preco { get; set; }

        [DisplayName("Valor total")]
        [DataType(DataType.Currency)]
        public decimal? ValorTotal { get; set; }
    }
}
