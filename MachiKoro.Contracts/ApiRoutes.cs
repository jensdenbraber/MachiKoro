namespace MachiKoro.Contracts.v1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class Identity
        {
            public const string Login = Base + "/identity/login";

            public const string Register = Base + "/identity/register";

            public const string Refresh = Base + "/identity/refresh";
        }

        public static class Games
        {
            public const string Create = Base + "/games";

            public const string GetAll = Base + "/games";

            public const string Get = Base + "/games/{gameId}";

            public const string AddPlayer = Base + "/games/{gameId}/players";

            public const string RemovePlayer = Base + "/games/{gameId}/players/{playerId}";

            public const string Update = Base + "/games/{gameId}";

            public const string Delete = Base + "/games/{gameId}";

            public const string Start = Base + "/games/{gameId}/start";
            
            public const string Upkeep = Base + "/games/{gameId}/upkeep/{playerId}";

            public const string RollDice = Base + "/games/{gameId}/rolldice/{playerId}";
        }

        public static class Players
        {
            public const string Create = Base + "/players";

            public const string GetAll = Base + "/players";

            public const string Get = Base + "/players/{playerId}";
            
            public const string GetProfile = Base + "/players/{playerId}/profile";

            public const string GetGames = Base + "/players/{playerId}/games";

            public const string GetGame = Base + "/players/{playerId}/games/{gameId}";

            public const string Update = Base + "/players/{playerId}";

            public const string Delete = Base + "/players/{playerId}";
        }
    }
}
