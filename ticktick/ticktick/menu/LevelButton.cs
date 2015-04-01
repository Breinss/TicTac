using Microsoft.Xna.Framework;

class LevelButton : Button
{
    protected TextGameObject text;
    protected int levelIndex;

    public LevelButton(int levelIndex, string imageAsset, int layer = 0, string id = "")
        : base(imageAsset, layer, id)
    {
        this.levelIndex = levelIndex;

        text = new TextGameObject("Fonts/Hud", 1);
        text.Text = levelIndex.ToString();
        text.Position = new Vector2(sprite.Width - text.Size.X - 10, 5);
    }

    public override void Draw(GameTime gameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
    {
        text.Draw(gameTime, spriteBatch);
        base.Draw(gameTime, spriteBatch);
    }

    public int LevelIndex
    {
        get { return levelIndex; }
    }
}
