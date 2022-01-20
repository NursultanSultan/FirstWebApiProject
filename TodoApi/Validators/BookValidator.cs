using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApi.Models;

namespace TodoApi.Validators
{
    public class BookValidator : AbstractValidator<Book>
    {

        public BookValidator()
        {
            RuleFor(b => b.BookName).NotEmpty().WithMessage("Book name can not be null");
            RuleFor(b => b.BookName).MaximumLength(100);
            RuleFor(b => b.Genre).NotEmpty();
        }
    }
}
