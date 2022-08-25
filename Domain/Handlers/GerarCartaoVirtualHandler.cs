using Domain.Commands.Inputs;
using Domain.Commands.Results;
using Domain.Entities;

namespace Domain.Handlers;

public class GerarCartaoVirtualHandler
{
    public GerarCartaoVirtualCommandResult Handle(GerarCartaoVirtualCommand command)
    {
        // Validar command
        command.Validar();

        if (!command.IsValid)
            return null;

        // Gerar número de cartão aleatório
        var numeroCartao = "";
        const int qtdeBlocosCartao = 4;
        for (int i=0; i < qtdeBlocosCartao; i++)
        {
            var random = new Random();
            var blocoCartao = $"{random.Next(1000, 9999)}";
            numeroCartao = $"{numeroCartao + blocoCartao}";
        }

        // Criar entidade e salvar no banco
        var cartaoVirtual = new CartaoVirtual(command.Email, numeroCartao, DateTime.Now);

        // Criar command result e retornar
        var commandResult = new GerarCartaoVirtualCommandResult(command.Email, numeroCartao);
        return commandResult;
    }
}