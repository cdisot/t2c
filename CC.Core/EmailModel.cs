namespace CC.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public abstract class EmailModel
    {
        protected static Regex MailReg =
            new Regex(
                @"(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))");

        protected EmailModel()
        {
            Id = Guid.NewGuid();
        }

        public IEnumerable<string> ToAddresses { get; set; }

        public Guid Id { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }

        public IEnumerable<string> ReplyToAddresses { get; set; }

        public bool IsAddressesValid
        {
            get
            {
                if (ToAddresses == null || ReplyToAddresses == null) return false;
                if (!ToAddresses.Any() || !ReplyToAddresses.Any()) return false;
                return ToAddresses.All(MailReg.IsMatch) && ReplyToAddresses.All(MailReg.IsMatch);
            }
        }

        public bool IsValid
        {
            get { return IsAddressesValid && !string.IsNullOrWhiteSpace(Subject) && !string.IsNullOrWhiteSpace(Content); }
        }

        protected static bool IsValidEmailAddress(string emailAddress)
        {
            return !string.IsNullOrWhiteSpace(emailAddress) && MailReg.IsMatch(emailAddress);
        }
    }
}
