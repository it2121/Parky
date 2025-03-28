namespace Parky_API.Models
{
    public class AuthenticationModel
    {
        [Requierd]
        public string  Username { get; set; }

        [Requierd]

        public string Password
        {
            get; set;
        }



    }
}
