using System;
using System.Collections.Generic;
using System.Text;

namespace BookAndMovieMobile.Model.Google
{
    public class GoogleTokenModel
    {
        public string AccessToken { get; set; }
        public int ExpiresIn { get; set; }
        public string Scope { get; set; }
        public string TokenType { get; set; }
    }
}
