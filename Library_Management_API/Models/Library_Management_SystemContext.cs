using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Library_Management_API.Models
{
    public partial class Library_Management_SystemContext : DbContext
    {
        public Library_Management_SystemContext()
        {
        }

        public Library_Management_SystemContext(DbContextOptions<Library_Management_SystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BorrowedBook> BorrowedBooks { get; set; } = null!;
        public virtual DbSet<LoginUser> LoginUsers { get; set; } = null!;
        public virtual DbSet<Member> Members { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.AuthorBio)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AuthorName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ISBN");

                entity.Property(e => e.PublishedDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Books__AuthorID__5812160E");
            });

            modelBuilder.Entity<BorrowedBook>(entity =>
            {
                entity.HasKey(e => e.BorrowId)
                    .HasName("PK__Borrowed__4295F83FE9E953C8");

                entity.Property(e => e.BorrowDate).HasColumnType("date");

                entity.Property(e => e.ReturnDate).HasColumnType("date");

                entity.Property(e => e.Status)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.BorrowedBooks)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__BorrowedB__BookI__5DCAEF64");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.BorrowedBooks)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__BorrowedB__Membe__5CD6CB2B");
            });

            modelBuilder.Entity<LoginUser>(entity =>
            {
                entity.ToTable("LoginUser");

                entity.Property(e => e.LoginPassword)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
