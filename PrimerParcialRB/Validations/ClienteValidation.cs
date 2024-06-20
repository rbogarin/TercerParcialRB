using FluentValidation;
using Repository.Contexts;
using Repository.Models;
using Service;

namespace WEBAPI.Validations
{
    public class ClienteValidation: AbstractValidator<ClienteRequest>
    {
        private readonly ContextoAplicacionDB _contexto;
        public ClienteValidation(ContextoAplicacionDB contexto)
        {

            _contexto = contexto;

            RuleFor(cliente => cliente.Nombre)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("El nombre del cliente es obligatorio")
                .MinimumLength(3)
                .WithMessage("El nombre del cliente debe tener al menos 3 caracteres");

            RuleFor(cliente => cliente.Apellido)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("El apellido del cliente es obligatorio")
                .MinimumLength(3)
                .WithMessage("El apellido del cliente debe tener al menos 3 caracteres");

            RuleFor(cliente => cliente.Celular)
                .Cascade(CascadeMode.Stop)
                .Length(10)
                .WithMessage("El número de celular debe tener 10 dígitos")
                .Matches(@"^\d{10}$")
                .WithMessage("El número de celular debe ser numérico");

            RuleFor(cliente => cliente.Documento)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("El número de documento del cliente es obligatorio")
                .MinimumLength(7)
                .WithMessage("El número de documento del cliente debe tener al menos 7 caracteres")
                .Must(validarDocumento)
                .WithMessage("El número de documento ya se encuentra registrado");

            RuleFor(cliente => cliente.Mail)
                .EmailAddress()
                .WithMessage("Correo inválido");
        }

        private bool validarDocumento(string documento)
        {
            ClienteService cs = new ClienteService(_contexto);
            return cs.validarDocumentoCliente(documento);
        }
    }
}
