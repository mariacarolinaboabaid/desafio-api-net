using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Models;
using FluentValidation;

namespace DesafioAPI.Validators
{
    public class RealStateImageValidator: AbstractValidator<RealStateImage>
    {
        public RealStateImageValidator()
        {
            RuleFor(x => x.RealStateId).NotEmpty()
                .NotNull()
                .WithMessage("O campo ID DO IMÓVEL possui preenchimento obrigatório.");

            RuleFor(x => x.ImageUrl).NotEmpty()
                .NotNull()
                .WithMessage("O campo URL DA IMAGEM possui preenchimento obrigatório.");

        }
              
    }
}