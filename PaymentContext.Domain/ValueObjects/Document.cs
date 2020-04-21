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

            Validate();
        }

        public string  Number { get; private set; }
        public DocumentTypeEnum Type { get; private set; }

        private void Validate()
        {
            if (Type == DocumentTypeEnum.CNPJ && Number.Length != 14) 
                AddNotification("Document.Number", "Invalid CNPJ");

            if (Type == DocumentTypeEnum.CPF && Number.Length != 11) 
                AddNotification("Document.Number", "Invalid CPF");
        }
    }
}