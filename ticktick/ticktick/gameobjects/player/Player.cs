using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;

partial class Player : AnimatedGameObject
{
    protected Vector2 startPosition;
    protected bool isOnTheGround;
    protected float previousYPosition;
    protected bool walkingOnIce, walkingOnHot;

    public Player(Vector2 start) : base(2, "player")
    {
        this.LoadAnimation("Sprites/Player/spr_idle", "idle", true); 
        this.LoadAnimation("Sprites/Player/spr_run@13", "run", true, 0.05f);
        this.LoadAnimation("Sprites/Player/spr_jump@14", "jump", false, 0.05f); 

        startPosition = start;
        Reset();
    }

    public override void Reset()
    {
        this.position = startPosition;
        this.velocity = Vector2.Zero;
        isOnTheGround = true;
        walkingOnIce = false;
        walkingOnHot = false;
        this.PlayAnimation("idle");
        previousYPosition = BoundingBox.Bottom;
    }

    public override void HandleInput(InputHelper inputHelper)
    {
        float walkingSpeed = 400;
        if (walkingOnIce)
            walkingSpeed *= 1.5f;
        if (inputHelper.IsKeyDown(Keys.Left))
            velocity.X = -walkingSpeed;
        else if (inputHelper.IsKeyDown(Keys.Right))
            velocity.X = walkingSpeed;
        else if (!walkingOnIce && isOnTheGround)
            velocity.X = 0.0f;
        if (velocity.X != 0.0f)
            Mirror = velocity.X < 0;
        if ((inputHelper.KeyPressed(Keys.Space) || inputHelper.KeyPressed(Keys.Up)) && isOnTheGround)
            Jump();
    }

    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (isOnTheGround)
            if (velocity.X == 0)
                this.PlayAnimation("idle");
            else
                this.PlayAnimation("run");
        else if (velocity.Y < 0)
            this.PlayAnimation("jump");

        DoPhysics();
    }
}
