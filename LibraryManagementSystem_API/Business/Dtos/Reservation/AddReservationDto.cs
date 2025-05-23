﻿using Entities.Concrete;

namespace Business.Dtos.Reservation
{
    public class AddReservationDto
    {
        public int UserId { get; set; }
        public int BookCopyId { get; set; }
        public DateTime ReservationDate { get; set; }
        public ReservationStatus Status { get; set; }
    }
}
