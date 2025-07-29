using CQRS_Decorator.SharedKernel;

namespace CQRS_Decorator.Domain.Aggregates.UserAggregate
{
    public class User : AggregateRoot<int>
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Email { get; private set; }

        private User() { }

        private User(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public static User Create(string firstName, string lastName, string email)
            => new(firstName, lastName, email);
    }
}
