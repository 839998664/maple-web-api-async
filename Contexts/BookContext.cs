using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using maple_web_api_async.Entities;
using Microsoft.EntityFrameworkCore;

namespace maple_web_api_async.Contexts
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbContextOptions<BookContext> _options { get; }

        public BookContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new List<Author>
            {
                new Author {
                    Id = Guid.Parse("17b04541-76e3-4719-bcd5-bb2018918ec0"),
                    FirstName = "Siddharth",
                    LastName = "Seth"
                },
                new Author {
                    Id = Guid.Parse("4183f7f6-d017-4f64-aae2-695eaa6c65ee"),
                    FirstName = "Apoorva",
                    LastName = "Seth"
                },
                new Author {
                    Id = Guid.Parse("e735dd4d-bd83-484b-b166-61bf6e7c0803"),
                    FirstName = "Ankit",
                    LastName = "Jain"
                }
            });

            modelBuilder.Entity<Book>().HasData(
                new List<Book> {
                    new Book {
                        Id = Guid.Parse("25efcf58-ec53-45e0-a879-ae1a1adfd340"),
                        Title = "A Dove's Tale",
                        Description = "Tale of a lonely Dove in a harsh world",
                        AuthorId = Guid.Parse("17b04541-76e3-4719-bcd5-bb2018918ec0")
                    },
                    new Book {
                        Id = Guid.Parse("357e1727-b7e0-4961-a072-8d999d328d88"),
                        Title = "The Hacker",
                        Description = "Story of rise and fall of a Hacker",
                        AuthorId =  Guid.Parse("4183f7f6-d017-4f64-aae2-695eaa6c65ee")
                    },
                    new Book {
                        Id = Guid.Parse("1fe62c81-5e7a-4c81-bde0-a7b645edca6b"),
                        Title = "The Business Man",
                        Description = "Tragedy in the personal life of a successful Business Tycoon",
                        AuthorId = Guid.Parse("e735dd4d-bd83-484b-b166-61bf6e7c0803")
                    }

                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}