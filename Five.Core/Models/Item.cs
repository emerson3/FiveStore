namespace Five.Core.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public float Preco { get; set; }
        public int QtdEstoque { get; set; }
        public int IdCategoria { get; set; }
    }
}