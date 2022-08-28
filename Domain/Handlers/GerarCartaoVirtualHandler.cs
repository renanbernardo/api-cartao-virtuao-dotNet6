using Domain.Commands.Inputs;
using Domain.Commands.Results;
using Domain.Entities;
using Domain.Repositories;

namespace Domain.Handlers;

public class GerarCartaoVirtualHandler
{
    private readonly ICartaoVirtualRepository _repository;
    public GerarCartaoVirtualHandler(ICartaoVirtualRepository repository)
    {
        _repository = repository;
    }

    public CommandResult Handle(GerarCartaoVirtualCommand command)
    {
        // Validar command
        command.Validar();

        if (!command.IsValid)
            return new CommandResult(false, "Email inválido", command.Notifications);

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

        try
        {
            _repository.AdicionarCartaoVirtual(cartaoVirtual);
        }
        catch (Exception ex)
        {
            
            return new CommandResult(false, "Erro ao salvar os dados", ex.Message);
        }

        // Criar command result e retornar
        return new CommandResult(true, "Requisição realizada com sucesso!", new { command.Email, numeroCartao });
    }
}