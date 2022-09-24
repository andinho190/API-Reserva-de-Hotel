using System;
using Gestao_Hotel.api.Domain.Validation;
using System.Net.NetworkInformation;

namespace Gestao_Hotel.api.Domain.Entities
{
    public class Ticket
    {
        public int Id_Ticket_PK { get; private set; }
        public int Id_Reservation_FK { get; private set; }
        public int Payment_Methods_Type { get; private set; }
        public string Payment_Name { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Price { get; private set; }

        public Ticket(int id_Reservation_FK, int payment_Methods_Type, string payment_Name, decimal price, DateTime date)
        {
            date = DateTime.Now;
            Validation(id_Reservation_FK, payment_Methods_Type, payment_Name, price);
        }

        public Ticket(int id_Ticket_PK, int id_Reservation_FK, int payment_Methods_Type, string payment_Name, decimal price, DateTime date)
        {
            DomainValidationException.When(id_Ticket_PK < 0, "O ID Ticket deve ser maior do que zero!");
            date = DateTime.Now;
            Validation(id_Reservation_FK, payment_Methods_Type, payment_Name, price);
        }


        private void Validation(int id_Reservation_FK, int payment_Methods_Type, string payment_Name, decimal price)
        {

            DomainValidationException.When(id_Reservation_FK < 0, "O ID da reserva é inválido!");
            DomainValidationException.When(payment_Methods_Type < 0, "O método de pagamento náo pode ficar em branco!");
            DomainValidationException.When(string.IsNullOrEmpty(payment_Name), "A forma de pagamento nao pode ficar em branco!");
            DomainValidationException.When(price < 0, "O valor é inválido!");
            Id_Reservation_FK = id_Reservation_FK;
            Payment_Methods_Type = payment_Methods_Type;
            Payment_Name = payment_Name;
        }
    }
}

