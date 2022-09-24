using System;
using Gestao_Hotel.api.Domain.Validation;

namespace Gestao_Hotel.api.Domain.Entities
{
    public class Hotel
    {
        public int Id_Hotel_PK { get; private set; }
        public string Name { get; private set; }
        public string Location { get; private set; }
        public int Number_Rooms { get; private set; }
        public bool Active { get; private set; }

        /// <summary>
        /// Construtor utilizado para criar objetos
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="number_Rooms"></param>
        /// <param name="active"></param>
        public Hotel(string name, string location, int number_Rooms, bool active)
        {
            Validation(name, location, number_Rooms);
        }

        /// <summary>
        /// Método utilizado para editar o objeto
        /// </summary>
        /// <param name="id_Hotel_PK"></param>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="number_Rooms"></param>
        /// <param name="active"></param>
        public Hotel(int id_Hotel_PK, string name, string location, int number_Rooms, bool active)
        {
            DomainValidationException.When(id_Hotel_PK < 0, "O ID do hotel deve ser maior do que zero!");
            Id_Hotel_PK = Id_Hotel_PK;
            Validation(name, location, number_Rooms);
        }

        /// <summary>
        /// Funcao para a validacao dos dados ao criar um objeto do hotel, ja iniciando ele como ativo
        /// </summary>
        /// <param name="name"></param>
        /// <param name="location"></param>
        /// <param name="number_Rooms"></param>
        /// <param name="active"></param>
        private void Validation (string name, string location, int number_Rooms)
        {
           
           DomainValidationException.When(string.IsNullOrEmpty(name), "O nome do hotel nao pode ficar em branco!");
           DomainValidationException.When(number_Rooms <0, "O numero de quartos nao pode ficar vazio!");
           DomainValidationException.When(string.IsNullOrEmpty(location), "A localidade do hotel nao pode ficar em branca!");

            
            Name = name;
            Location = location;
            Number_Rooms = number_Rooms;
            Active = true; 
        }


    }
}

