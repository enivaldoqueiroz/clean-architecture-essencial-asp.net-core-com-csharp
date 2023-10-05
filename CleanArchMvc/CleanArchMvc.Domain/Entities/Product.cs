namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Descrition { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public string Image { get; private set; }

        public int CategoryId { get; private set; }

        public Category Category { get; set; }
    }
}
