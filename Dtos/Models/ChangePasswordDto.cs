namespace Dtos
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class ChangePasswordDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
