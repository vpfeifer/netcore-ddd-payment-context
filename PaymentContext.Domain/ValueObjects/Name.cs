using Flunt.Validations;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new Contract()
                .Requires()
                .HasMinLen(FirstName, 3, "Name.FirstName", "First name must contain 3 characters or more.")
                .HasMinLen(LastName, 3, "Name.LastName", "Last name must contain 3 characters or more.")
            );
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}