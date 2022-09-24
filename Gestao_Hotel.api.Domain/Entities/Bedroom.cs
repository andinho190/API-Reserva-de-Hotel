using System;
using Gestao_Hotel.api.Domain.Validation;

namespace Gestao_Hotel.api.Domain.Entities
{
    public class Bedrom
    {
        public int Id_Badroom_PK { get; private set; }
        public string Name { get; private set; }
        public string Badroom_Type { get; private set; }
        public decimal Price { get; private set; }
        public int Id_Hotel_FK {get; private set;}

        public Bedrom(string name, string badroom_Type, decimal price)
        {
            Validation(name, badroom_Type, price);
        }

        public Bedrom(int id_Badroom_PK, string name, string badroom_Type, decimal price, int id_Hotel_FK)
        {
            DomainValidationException.When(id_Badroom_PK < 0, "O ID do quarto deve ser maior do que zero!");
            DomainValidationException.When(id_Hotel_FK < 0, "O ID do hotel deve ser maior do que zero!");
            Validation(name, badroom_Type, price);
        }

        /// <summary>
        /// Funcao para realizar a validacao dos dados da entidade
        /// </summary>
        /// <param name="name"></param>
        /// <param name="badroom_Type"></param>
        /// <param name="price"></param>
        private void Validation(string name, string badroom_Type, decimal price)
        {

            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome do quarto nao pode ficar em branco!");
            DomainValidationException.When(string.IsNullOrEmpty(badroom_Type), "A localidade do hotel nao pode ficar em branca!");
            DomainValidationException.When(price < 0, "O valor deve ser maior do que zero");

            Name = name;
            Badroom_Type = badroom_Type;
            Price = price;

        }
    }
}

