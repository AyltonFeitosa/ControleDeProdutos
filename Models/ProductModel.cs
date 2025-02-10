using System.ComponentModel.DataAnnotations.Schema;

namespace ControleDeProdutos.Models
{
    [Table("Produto")]
    public class ProductModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public double PrecoUnitario { get; set; }
        public int QuantidadeEstoque { get; set; }
    }
}
