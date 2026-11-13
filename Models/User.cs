namespace UserProfile.Models
{
    public class User
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email {  get; set; } = string.Empty;

        public string Phone {  get; set; } = string.Empty;

        public string Address {  get; set; } = string.Empty;

        public string City {  get; set; }   = string.Empty;
        
        public double? Latitude { get; set; }

        public double? Longitude { get; set; }

        public string Bio {  get; set; } = string.Empty;

        public string ProfileImageUrl {  get; set; } = "/images/default-avatar.png";


    }
}
