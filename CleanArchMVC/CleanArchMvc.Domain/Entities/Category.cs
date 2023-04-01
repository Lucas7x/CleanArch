using CleanArchMvc.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        public ICollection<Product> Products { get; set; }
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Identificador inválido.");
            ValidateDomain(name);

            Id = id;
            Name= name;
        }

        public void Update(string name)
        {
            ValidateDomain(name);

            Name = name;
        }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido, é necessário preencher o campo Nome");
            DomainExceptionValidation.When(name.Length < 3, "Nome inválido, mínimo de 3 caracteres.");

            Name = name;
        }

    }
}
