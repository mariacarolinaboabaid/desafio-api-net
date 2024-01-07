using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioAPI.Models;
using FluentValidation;

namespace DesafioAPI.Validators
{
    public class RealStateValidator : AbstractValidator<RealState>
    {

        public RealStateValidator()
        {
            // Validações dos atributos da classe RealState
            RuleFor(x => x.Title).NotEmpty()
                .NotNull()
                .WithMessage("O campo TÍTULO possui preenchimento obrigatório.")
                .Length(4, 64).WithMessage("O campo TÍTULO deve possuir no mínimo 4 e no máximo 64 caracteres.");

            RuleFor(x => x.Value).NotEmpty()
                .NotNull()
                .WithMessage("O campo VALOR possui preenchimento obrigatório.");

            RuleFor(x => x.Neighborhood).NotEmpty()
                .NotNull()
                .WithMessage("O campo BAIRRO possui preenchimento obrigatório.")
                .Length(4, 64).WithMessage("O campo BAIRRO deve possuir no mínimo 4 e no máximo 64 caracteres.");

            RuleFor(x => x.BedroomQuantity).NotEmpty()
                .NotNull()
                .WithMessage("O campo QUANTIDADE DE DORMITÓRIOS possui preenchimento obrigatório.");

            RuleFor(x => x.BusinessType).NotEmpty()
                .NotNull()
                .WithMessage("O campo TIPO DO NEGÓCIO possui preenchimento obrigatório.")
                .Must(Validator_BusinessType)
                .WithMessage("O campo TIPO DO NEGÓCIO apenas aceita os seguintes valores: 'Aluguel' ou 'Venda'.");

            RuleFor(x => x.Adress).NotEmpty()
                .NotNull()
                .WithMessage("O campo ENDEREÇO possui preenchimento obrigatório.")
                .Length(4, 300).WithMessage("O campo ENDEREÇO deve possuir no mínimo 4 e no máximo 64 caracteres.");
        }

        // Método para validar a entrada do campo 'BusinessType'
        private bool Validator_BusinessType(string type)
        {
            if (type == "Aluguel" || type == "Venda")
                return true;
            else
                return false;
        }
    }
}