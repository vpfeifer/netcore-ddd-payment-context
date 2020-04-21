using Flunt.Validations;
using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, DocumentTypeEnum type)
        {
            Number = number;
            Type = type;

            AddNotifications(new Contract()
                .Requires()
                .IsTrue(Validate(), "Document.Number", "Invalid document number.")
            );
        }

        public string  Number { get; private set; }
        public DocumentTypeEnum Type { get; private set; }

        private bool Validate()
        {
            if (Type == DocumentTypeEnum.CNPJ && Number.Length == 14) 
                return true;

            if (Type == DocumentTypeEnum.CPF && Number.Length == 11) 
                return true;

            return false;
        }
    }
}