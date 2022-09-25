using MachiKoro.Domain.Enums;
using MachiKoro.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading;

namespace MachiKoro.Domain.Models.Cards.Establishments.Basic;

public abstract class EstablishmentBase : Card
{
    public List<int> ActivationNumbers { get; }
    public int ConstructionCost { get; }
    private readonly IEstablishmentEffect _establishmentEffect;

    public EstablishmentBase() : base()
    { }

    public EstablishmentBase(string name, CardCategory cardIcon, List<int> activationNumbers, int constructionCost, IEstablishmentEffect establishmentEffect)
        : base(name, cardIcon)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new System.ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
        }

        ActivationNumbers = activationNumbers ?? throw new System.ArgumentNullException(nameof(activationNumbers));
        ConstructionCost = constructionCost;
        _establishmentEffect = establishmentEffect;// ?? throw new System.ArgumentNullException(nameof(establishmentEffect));
    }

    public void ExecuteEffect(Game.Game game, Player.Player player, CancellationToken cancellationToken)
    {
        _establishmentEffect.Activate(game, player, cancellationToken);
    }
}