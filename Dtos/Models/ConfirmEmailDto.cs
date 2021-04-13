namespace Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ConfirmEmailDto
    {
        public string Token { get; set; }
        public string Username { get; set; }
    }
}
