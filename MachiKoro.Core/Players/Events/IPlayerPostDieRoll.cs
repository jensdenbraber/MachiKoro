namespace MachiKoro.Core.Players.Events
{
    internal interface IPlayerPostDieRoll
    {
        public void ActivePlayer_OnPlayerPostDieRoll(object sender, PlayerPostDieRollEventArgs e);
    }
}
