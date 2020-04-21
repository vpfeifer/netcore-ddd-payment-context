using PaymentContext.Domain.Enums;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document(string number, DocumentTypeEnum type)
        {
            Number = number;
            Type = type;
        }

        public string  Number { get; private set; }
        public DocumentTypeEnum Type { get; private set; }
    }
}