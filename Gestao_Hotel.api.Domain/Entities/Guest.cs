using System;
using System.Numerics;
using System.Xml.Linq;
using Gestao_Hotel.api.Domain.Validation;

namespace Gestao_Hotel.api.Domain.Entities
{
    public class Guest
    {
        public int Id_Guest_PK { get; private set; }
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
        public DateTime? Deletion_Date { get; private set; }
        public bool Deleted_Status { get; private set; }


        public Guest(string address, string name, string laste_Name, string phone, DateTime? deletion_Date, bool deleted_Status)
        {
            Validation(address, name, laste_Name, phone, deletion_Date, deleted_Status = false);
        }


        public Guest(int id_Guest_PK, string address, string name, string laste_Name, string phone, DateTime? deletion_Date, bool deleted_Status)
        {
            DomainValidationException.When(id_Guest_PK < 0, "O ID do hóspede deve ser maior do que zero!");
            Validation(address, name, laste_Name, phone, deletion_Date, deleted_Status);
        }
        private void Validation(string address, string name, string laste_Name, string phone, DateTime? deletion_Date, bool deleted_Status)
        {

            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome do hóspede nao pode ficar em branco!");
            DomainValidationException.When(string.IsNullOrEmpty(laste_Name), "O sobrenome do hóspede nao pode ficar em branca!");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "O telefone do hóspede nao pode ficar em branca!");
            DomainValidationException.When(string.IsNullOrWhiteSpace(address), "O endereco do hóspede nao pode ficar em branco!");
            Name = name;
            LastName = laste_Name;
            Phone = phone;
            Deleted_Status = deleted_Status;
            Address = address;
            Deletion_Date = deletion_Date;
        }
    }
}

