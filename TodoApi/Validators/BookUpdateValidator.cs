using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Validators
{
    public class BookUpdateValidator:AbstractValidator<Book>
    {

        public BookUpdateValidator()
        {
            RuleFor(b => b.BookName).MaximumLength(100);
        }
    }
}
