using DashBoardGr.Domain.Repository.Repositories.Interfaces;
using DashBoardGr.Domain.Shared;
using FluentValidation;
using MediatR;

namespace DashBoardGr.Domain.Application.Commands.AvaliarAnalise
{
    public class AvaliarAnaliseCommandHandler : INotificationHandler<AvaliarAnaliseNotification>
    {
        private readonly IAnaliseRiscoRepository _analiseRiscoRepository;
        private readonly IValidator<AvaliarAnaliseNotification> _validator;
        public AvaliarAnaliseCommandHandler(IAnaliseRiscoRepository analiseRiscoRepository, IValidator<AvaliarAnaliseNotification> validator)
        {
            _analiseRiscoRepository = analiseRiscoRepository;
            _validator = validator;
        }



        public async Task Handle(AvaliarAnaliseNotification notification, CancellationToken cancellationToken)
        {
            var result = await _validator.ValidateAsync(notification, cancellationToken);
            if (!result.IsValid)
                return;

            await _analiseRiscoRepository.Avaliar(
                notification.Id,
                 notification.Status.ObterDescricaoDoEnum(),
                notification.Motivo.ObterDescricaoDoEnum(),
                notification.Observacao);

            return;
        }
    }
}
