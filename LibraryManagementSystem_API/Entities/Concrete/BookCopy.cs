﻿namespace Entities.Concrete
{
    public class BookCopy : BaseEntity
    {
        public int BookId { get; set; }
        public Book? Book { get; set; }

        public required string CopyNumber { get; set; }
        public BookCopyStatus Status { get; set; }

        public int ShelfId { get; set; }
        public Shelf? Shelf { get; set; }
    }

    public enum BookCopyStatus
    {
        Available,
        Borrowed,
        Reserved
    }
}
