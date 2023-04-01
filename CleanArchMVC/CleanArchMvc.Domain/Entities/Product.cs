using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public Product(string name, string description, decimal price, int stock, string image, int categoryId, Category category)
        {
            ValidateDomain(name, description, price, stock, image);

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
            CategoryId = categoryId;
            Category = category;
        }

        public Product(int id, string name, string description, decimal price, int stock, string image, int categoryId, Category category)
        {
            DomainExceptionValidation.When(id < 0, "Identificador inválido.");
            ValidateDomain(name, description, price, stock, image);
            
            Id = id;
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        public void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido, é necessário preencher o campo Nome");
            DomainExceptionValidation.When(name.Length < 3, "Nome inválido, mínimo de 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição inválida, é necessário preencher o campo Descrição.");
            DomainExceptionValidation.When(description.Length < 5, "Descrição inválida, mínimo 5 caracteres.");
            DomainExceptionValidation.When(stock < 0, "Quantidade em Estoque inválida.");
            DomainExceptionValidation.When(price < 0, "Preço inválido.");
            DomainExceptionValidation.When(image.Length > 250, "Nome da Imagem inválido, tamanho máximo é de 250 caracteres.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
