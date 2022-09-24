using System;
using Gestao_Hotel.api.Domain.Validation;
using System.Diagnostics;
using System.Numerics;
using System.Xml.Linq;

namespace Gestao_Hotel.api.Domain.Entities
{
    public class Employees
    {
        public int Id_Employees_PK { get; private set; }
        public int Id_Hotel_FK { get; private set; }
        public string Name  { get; private set; }
        public string LastName { get; private set; }
        public string Phone { get; private set; }
        public DateTime? Deletion_Date{ get; private set; }
        public bool Deleted_Status { get; private set; }


        public Employees(int id_Hotel_FK, string name, string laste_Name, string phone, DateTime? deletion_Date, bool deleted_Status)
        {
            Validation(id_Hotel_FK, name, laste_Name,phone, deletion_Date, deleted_Status = false);

        }


        public Employees(int id_Employees_PK, int id_Hotel_FK, string name, string laste_Name, string phone, DateTime? deletion_Date, bool deleted_Status)
        {
            DomainValidationException.When(Id_Employees_PK < 0, "O ID do funcionário deve ser maior do que zero!");
            Validation(id_Hotel_FK, name, laste_Name, phone, deletion_Date, deleted_Status);

        }

        private void Validation(int id_Hotel_FK, string name, string laste_Name, string phone, DateTime? deletion_Date, bool deleted_Status)
        {

            DomainValidationException.When(string.IsNullOrEmpty(name), "O nome do funcionário nao pode ficar em branco!");
            DomainValidationException.When(string.IsNullOrEmpty(laste_Name), "O sobrenome do funcionário nao pode ficar em branca!");
            DomainValidationException.When(string.IsNullOrEmpty(phone), "O telefone do funcionário nao pode ficar em branca!");
            DomainValidationException.When(id_Hotel_FK < 0, "O ID do Hotel é inválido!");
            Name = name;
            LastName = laste_Name;
            Phone = phone;
            Deletion_Date = deletion_Date;
            Deleted_Status = deleted_Status;
            Id_Hotel_FK = id_Hotel_FK;

        }
    }
}

