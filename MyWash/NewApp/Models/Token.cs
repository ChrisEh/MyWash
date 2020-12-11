using System;
using System.Collections.Generic;
using System.Text;

namespace NewApp.Models
{
    public class Token
    {
        public string Access_token { get; set; }
        public string Aoken_type { get; set; }
        public int User_Id { get; set; }
        public string User_name { get; set; }
        public int Expires_in { get; set; }
        public int Creation_Time { get; set; }
        public int Expiration_Time { get; set; }
    }
}
