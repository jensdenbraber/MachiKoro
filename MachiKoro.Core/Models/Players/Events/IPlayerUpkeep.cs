namespace MachiKoro.Core.Players.Events
{
    internal interface IPlayerUpkeep
    {
        public void ActivePlayer_OnPlayerUpkeep(object sender, PlayerUpkeepEventArgs e);
    }
}
