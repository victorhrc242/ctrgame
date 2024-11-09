namespace ctrgamer._03_entidades
{
    public class Carrinho
    {
        public int ID { get; set; }
        public int usuarioid { get; set; }
        public int JogoId { get; set; }
        public string formadepagamento {  get; set; }

        // Novo campo para indicar o status do carrinho
        public string Status { get; set; }  // Ex: "Em andamento", "Finalizado"
    }
}
