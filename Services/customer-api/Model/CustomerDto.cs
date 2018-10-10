using System;

namespace Sqit.CustomerApi.Model
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public DateTime LastBuyAt { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}