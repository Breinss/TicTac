using Microsoft.Xna.Framework;

class TitleMenuState : GameObjectList
{
    protected Button playButton;

    public TitleMenuState()
    {
        // load the title screens
        SpriteGameObject title_screen = new SpriteGameObject("Backgrounds/spr_title", 0, "background");
        this.Add(title_screen);

        // add a play button
        playButton = new Button("Sprites/spr_button_play", 1);
        playButton.Position = new Vector2((GameEnvironment.Screen.X - playButton.Width) / 2, 540);
        this.Add(playButton);
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (playButton.Pressed)
            GameEnvironment.GameStateManager.SwitchTo("levelMenu");
    }
}
