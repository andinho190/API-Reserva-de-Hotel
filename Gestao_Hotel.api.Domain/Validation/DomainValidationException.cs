using System;
namespace Gestao_Hotel.api.Domain.Validation
{
    public class DomainValidationException: Exception
    {
        public DomainValidationException(string Error) : base(Error)
        {
        }



        public static void When(bool hasError, string messege)
        {

            if (hasError)
                throw new DomainValidationException(messege);

        }
    }
}

