using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

class TickTick : GameEnvironment
{
    static void Main()
    {
        TickTick game = new TickTick();
        game.Run();
    }

    public TickTick()
    {
        Content.RootDirectory = "Content";
        this.IsMouseVisible = true;
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        screen = new Point(1440, 825);
        this.SetFullScreen(false);


        gameStateManager.AddGameState("playingState", new PlayingState(Content));
        gameStateManager.AddGameState("titleMenuState", new TitleMenuState());
        gameStateManager.AddGameState("levelMenuState",new LevelMenuState());
        gameStateManager.SwitchTo("titleMenuState");

        AssetManager.PlayMusic("Sounds/snd_music");
    }
}