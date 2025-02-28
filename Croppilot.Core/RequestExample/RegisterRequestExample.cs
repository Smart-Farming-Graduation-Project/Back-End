using Swashbuckle.AspNetCore.Filters;

namespace Croppilot.Core.RequestExample
{
    public class RegisterRequestExample : IExamplesProvider<object>
    {
        public object GetExamples()
        {
            return new
            {
                frontend = new
                {
                    firstName = "John",
                    lastName = "Doe",
                    userName = "johndoe",
                    email = "john.doe@example.com",
                    password = "P@ssw0rd",
                    confirmPassword = "P@ssw0rd",
                    phone = "+123456789",
                    address = "123 Main Street, City, Country"
                },
                mobile = new
                {
                    email = "john.doe@example.com",
                    password = "P@ssw0rd",
                    confirmPassword = "P@ssw0rd"
                    // ❌ firstName, lastName, phone, address not required for mobile
                }
            };
        }
    }
}
