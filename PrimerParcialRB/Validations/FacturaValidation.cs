using FluentValidation;
using Repository.Models;

namespace WEBAPI.Validations
{
    public class FacturaValidation : AbstractValidator<FacturaRequest>
    {
        public FacturaValidation()
        {
            RuleFor(factura => factura.NroFactura)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("El número de factura es obligatorio")
                .Matches(@"^\d{3}-\d{3}-\d{6}$")
                .WithMessage("El número de factura debe seguir el patrón 123-123-123456");

            RuleFor(factura => factura.Total)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("El total de la factura es obligatorio")
                .GreaterThanOrEqualTo(0)
                .WithMessage("El total de la factura debe ser un número entero");

            RuleFor(factura => factura.TotalIva5)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("El total del IVA al 5% es obligatorio")
                .GreaterThanOrEqualTo(0)
                .WithMessage("El total del IVA al 5% debe ser un número entero");

            RuleFor(factura => factura.TotalIva10)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("El total del IVA al 10% es obligatorio")
                .GreaterThanOrEqualTo(0)
                .WithMessage("El total del IVA al 10% debe ser un número entero");

            RuleFor(factura => factura.TotalIva)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("El total del IVA es obligatorio")
                .GreaterThanOrEqualTo(0)
                .WithMessage("El total del IVA debe ser un número entero");

            RuleFor(persona => persona.TotalLetras)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("El total de la factura en letras es obligatorio")
                .MinimumLength(6)
                .WithMessage("El total de la factura en letras debe tener al menos 6 caracteres");
        }
    }
}
