using Flunt.Notifications;
using Flunt.Validations;

namespace Domain.Commands.Inputs;

public class GerarCartaoVirtualCommand : Notifiable<Notification>
{
    public string Email { get; set; }

    public void Validar()
    {
        AddNotifications(new Contract<GerarCartaoVirtualCommand>()
        .IsEmail(Email, "Email", "Email Inválido"));
    }
}