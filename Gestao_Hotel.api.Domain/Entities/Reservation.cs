using System;
using Gestao_Hotel.api.Domain.Validation;
using System.Net;
using System.Numerics;
using System.Xml.Linq;

namespace Gestao_Hotel.api.Domain.Entities
{
    public class Reservation
    {
        public int Id_Reservation_PK { get; private set; }
        public int Id_Guest_FK { get; private set; }
        public int Id_Bedroom_FK { get; private set; }
        public string Status { get; private set; }
        public DateTime Date { get; private set; }
   


        public Reservation(int id_Guest_FK, int id_Bedroom_FK, string status, DateTime date)
        {
            date = DateTime.Now;
            Validation(id_Guest_FK, id_Bedroom_FK, status);
        }

        public Reservation(int id_Reservation, int id_Guest_FK, int id_Bedroom_FK, string status, DateTime date)
        {
            DomainValidationException.When(id_Reservation < 0, "O ID da reserva deve ser maior do que zero!");
            date = DateTime.Now;
            Validation(id_Guest_FK, id_Bedroom_FK, status);
        }

        private void Validation(int id_Guest_FK, int id_Bedroom_FK, string status)
        {

            DomainValidationException.When(id_Guest_FK < 0, "O ID do hóspede é inválido!");
            DomainValidationException.When(id_Bedroom_FK < 0, "O ID do quarto é inválido!");
            DomainValidationException.When(string.IsNullOrEmpty(status), "O status nao pode ficar em branca!");
           
            Id_Bedroom_FK = id_Bedroom_FK;
            Id_Guest_FK = id_Guest_FK;
            Status = status;
        }
    }
}

