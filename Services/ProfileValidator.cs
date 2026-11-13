using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using UserProfile.Models;

namespace UserProfile.Services
{
    public class ProfileValidator
    {
        public Dictionary<string, string> Validate(User profile, bool isPersian)
        {
            var errors = new Dictionary<string, string>();

            if (string.IsNullOrWhiteSpace(profile.FirstName))
            {
                errors["FirstName"] = isPersian
                     ? "نام نمی‌تواند خالی باشد."
                     : "First name is required.";
            }
            if (string.IsNullOrWhiteSpace(profile.LastName))
            {
                errors["LastName"] = isPersian
                     ? "نام خانوادگی نمی‌تواند خالی باشد."
                     : "Last name is required.";
            }
            if (string.IsNullOrWhiteSpace(profile.Email))

                errors["Email"] = isPersian
                     ? "ایمیل نمی‌تواند خالی باشد."
                     : "Email is required.";
            else if (!IsValidEmail(profile.Email))
            {
                errors["Email"] = isPersian
                    ? "فرمت ایمیل معتبر نیست."
                    : "Email format is invalid.";
            }


            if (string.IsNullOrWhiteSpace(profile.Phone))
            {
                errors["Phone"] = isPersian
                  ? "شماره تماس نمی‌تواند خالی باشد."
                  : "Phone number is required.";
            }

            else if (!IsValidPhone(profile.Phone))
            {
                errors["Phone"] = isPersian
                                   ? "شماره تماس معتبر نیست."
                                   : "Phone number is invalid.";
            }


            return errors;
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var normalizedEmail = email.Trim();
                var address = new MailAddress(normalizedEmail);
                return address.Address == normalizedEmail;
            }
            catch(FormatException)
            {
                return false;
            }
        }
        private bool IsValidPhone(string phone)
        {
            var normalizedPhone = NormalizeDigits(phone);
            if (!Regex.IsMatch(normalizedPhone, @"^\+?[0-9\s().-]+$"))
            {
                return false;
            }
            var digitCount = normalizedPhone.Count(char.IsDigit);

            return digitCount >= 8 && digitCount <= 15;
        }

        private static string NormalizeDigits(string value)
        {
            var result = new StringBuilder(value.Length);

            foreach (var character in value)
            {
                if (char.IsDigit(character))
                {
                    result.Append((int)char.GetNumericValue(character));
                }
                else
                {
                    result.Append(character);
                }
            }

            return result.ToString();
        }
    }
}
