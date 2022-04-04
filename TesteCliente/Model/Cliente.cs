using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace TesteCliente.Model
{
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation (BsonType.ObjectId)]

        public string? Id { get; set; }

      //  [Required(ErrorMessage = "O campo CPF é obrigatório")]
        [BsonElement("Cpf")]
        public string? Cpf { get; set; } = null;

        //[Required(ErrorMessage = "O campo Nome é obrigatório")]
        [BsonElement("Nome")]
        public string? Nome { get; set; }  = null;

       // [Required(ErrorMessage = "O campo Sobrnome é obrigatório")]
        [BsonElement("Sobrenome")]
        public string? Sobrenome { get; set; } = null;

        [BsonElement("DataDeNascimento")]
        public DateTime? DataDeNascimento { get; set; }
    }
}
