using UserProfile.Models;

namespace UserProfile.Services
{
    public class ProfileValidator
    {
        public Dictionary<string,string> Validate(User profile)
        {
            var errors = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(profile.FirstName))
            {
                errors["FirstName"] = "نام نمی‌تواند خالی باشد.";
            }
            if (string.IsNullOrWhiteSpace(profile.LastName))
            {
                errors["LastName"] = "نام خانوادگی نمی‌تواند خالی باشد.";
            }
            if (string.IsNullOrWhiteSpace(profile.Email))
            
                errors["Email"] = "ایمیل نمی‌تواند خالی باشد.";
            else if (!isValidEmail(profile.Email))
                    errors["Email"] = "فرمت ایمیل معتبر نیست.";


            if (string.IsNullOrWhiteSpace(profile.Phone))
                errors["Phone"] = "شماره تماس نمی‌تواند خالی باشد.";
            else if (!isValidPhone(profile.Phone))
                errors["Phone"] = "فرمت شماره تماس معتبر نیست.";

            return errors;
        }


        private bool isValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        private bool isValidPhone(string phone)
        {
            // فقط عدد، حداقل ۸ و حداکثر ۱۵ رقم (بعد از پیش‌شماره)
            var cleaned = new string(phone.Where(char.IsDigit).ToArray());
            return cleaned.Length >= 8 && cleaned.Length <= 15;
        }
    }
}
