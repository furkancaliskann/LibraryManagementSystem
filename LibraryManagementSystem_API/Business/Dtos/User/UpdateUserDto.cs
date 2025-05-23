﻿namespace Business.Dtos.User
{
    public class UpdateUserDto
    {
        public required string Name { get; set; }
        public required string Surname { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public string? Address { get; set; }

        public required string CurrentPassword { get; set; }
        public string? NewPassword { get; set; }
    }
}
