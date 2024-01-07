using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using DesafioAPI.Models;
using FluentValidation;

namespace DesafioAPI.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            // Validações dos atributos da classe User
            RuleFor(x => x.Name).NotEmpty()
                .NotNull()
                .WithMessage("O campo NOME possui preenchimento obrigatório.")
                .Length(6, 64).WithMessage("O campo NOME deve possuir no mínimo 6 e no máximo 64 caracteres.");


            RuleFor(x => x.Email).NotEmpty()
                .NotNull()
                .WithMessage("O campo E-MAIL possui preenchimento obrigatório.")
                .Length(6, 64).WithMessage("O campo E-MAIL deve possuir no máximo 64 caracteres.")
                .Must(Validator_Email)
                .WithMessage("O campo E-MAIL deve possuir o seguinte formato: xxxxx@xxxx.xxx");

            RuleFor(x => x.Telephone).NotEmpty()
                .NotNull()
                .WithMessage("O campo TELEFONE possui preenchimento obrigatório.")
                .Length(11).WithMessage("O campo TELEFONE deve possuir 11 caracteres.");

            RuleFor(x => x.Password).NotEmpty()
                .NotNull()
                .WithMessage("O campo SENHA possui preenchimento obrigatório.")
                .Length(6, 12).WithMessage("O campo SENHA deve possuir no mínimo 6 e no máximo 12 caracteres.");
        }

        // Método para validar o formato do campo 'Email' 
        private bool Validator_Email(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}