﻿namespace Business.Dtos.Auth
{
    public class RegisterDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public required string Phone { get; set; }
        public string? Address { get; set; }
    }
}
