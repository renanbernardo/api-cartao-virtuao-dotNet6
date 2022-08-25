namespace Domain.Commands.Results;

public class GerarCartaoVirtualCommandResult
{
    public GerarCartaoVirtualCommandResult(string email, string numeroCartao)
    {
        Email = email;
        NumeroCartao = numeroCartao;
    }
    public string Email { get; set; }
    public string NumeroCartao { get; set; }
}