namespace Assets.Scripts
{
    public class Constants
    {
        public class Tags
        {
            public const string HomeBase = "HomeBase";
            public const string Player = "Player";
            public const string Mushmen = "Mushmen";
            public const string Enemy = "Enemy";
            public const string CloudKiller = "CloudKiller";
            public const string NextSceneTrigger = "NextSceneTrigger";
        }

        public class Scenes
        {
            public const string InstructionsScene = "InstructionsScene";
            public const string GameOver = "GameOver";
            public const string TitleScene = "TitleScene";
            public const string Winner1 = "Winner1";
            public const string Winner2 = "Winners";
            public const string GameScene = "TestScene1";

            public enum SceneType {
              INSTRUCTIONS = 0,
              GAME_OVER = 1,
              TITLE = 2,
              WINNER_1 = 3,
              WINNER_2 = 4,
              GAME = 5,
            };

            static public string GetSceneName(SceneType type) {
              switch(type) {
                case SceneType.INSTRUCTIONS:
                return InstructionsScene;
                case SceneType.GAME_OVER:
                return GameOver;
                case SceneType.TITLE:
                return TitleScene;
                case SceneType.WINNER_1:
                return Winner1;
                case SceneType.WINNER_2:
                return Winner2;
                case SceneType.GAME:
                return GameScene;
                default:
                return string.Empty;
              }
            }
        }
    }
}
