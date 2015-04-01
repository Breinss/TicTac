using Microsoft.Xna.Framework;

partial class Level : GameObjectList
{

    public override void HandleInput(InputHelper inputHelper)
    {
        base.HandleInput(inputHelper);
        if (quitButton.Pressed)
        {
            GameEnvironment.GameStateManager.SwitchTo("levelMenuState");
            this.Reset();
            
        }      
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public override void Reset()
    {
        base.Reset();
    }
}
