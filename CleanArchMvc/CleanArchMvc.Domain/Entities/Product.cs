using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public decimal Price { get; private set; }

        public int Stock { get; private set; }

        public string Image { get; private set; }

        public Product(string name, string Description, decimal price, int stock, string image)
        {
            ValidateDomain(name, Description, price, stock, image);
        }

        public Product(int id, string name, string Description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id value.");
            Id = id;

            ValidateDomain(name, Description, price, stock, image);
        }

        public void Update(string name, string Description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, Description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string Description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3, "Invalid name. too short, minimum 3 characters.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(Description), "Invalid Description. Name is required.");

            DomainExceptionValidation.When(Description.Length < 5, "Invalid Description. too short, minimum 5 characters.");

            DomainExceptionValidation.When(price < 0, "Invalid price value.");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value.");

            DomainExceptionValidation.When(image?.Length > 250, "Invalid image name. too long, miximum 250 characters.");

            Name = name;
            Description = Description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
