using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using MonoGame;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game2
{
    class SpliteAnimation
    {
        Texture2D animation;
        Texture2D baseAnimation;
        Rectangle sourceRect;
        Vector2 position;

        float elapsed;
        float frameTime;
        int numOfFrameH;
        int numOfFrameV;
        int numOfFrameTotal;
        int currentFrame;
        int frameWidth;
        int frameHeight;
        bool looping;

        bool HFlip;
        bool VFlip;


        public SpliteAnimation(ContentManager Content_, string assetName_, float frameSpeed_
            ,int numOfFrameH_, int numOfFrameV_, int numOfFrameTotal_, bool looping_ )
        {
            this.frameTime  = frameSpeed_;
            this.numOfFrameH = numOfFrameH_;
            this.numOfFrameV = numOfFrameV_;
            this.numOfFrameTotal = numOfFrameTotal_;

            this.looping    = looping_;
            this.animation = Content_.Load<Texture2D>(assetName_);
            this.baseAnimation = this.animation;
            frameWidth = animation.Width / numOfFrameH_;
            frameHeight = animation.Height / numOfFrameV_;
            position = new Vector2(0, 0);
            elapsed = 0f;

            HFlip = false;
            VFlip = false;
        }   

        public void PlayAnitmation( GameTime gameTime )
        {
            elapsed += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            sourceRect = new Rectangle((currentFrame % numOfFrameH) * frameWidth,
                0 * frameHeight, frameWidth, frameHeight);
            if (elapsed >= frameTime)
            {
                if (currentFrame > numOfFrameTotal)
                {
                    if (looping) currentFrame = 0;
                }
                else currentFrame++;

                elapsed = 0;
            }

            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffect = HFlip ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            spriteBatch.Draw(animation, position, sourceRect, Color.White,   0f, new Vector2( 0f, 0f ), 1f, spriteEffect, 1f );
            //spriteBatch.Draw(animation, position, sourceRect, new Color(255f,255f,255f,255f), 0f, new Vector2(0, 0), SpriteEffects.None, 1f);
        }

        public Vector2 Position
        {
            get { return this.position; }
            set {
                if (HFlip && this.position.X > value.X) HFlip = false;
                if (!HFlip && this.position.X < value.X) HFlip = true;
                this.position = value;
            }
        }

        public Texture2D Animation
        {
            get { return animation; }
            set {
                this.animation = value;

                frameWidth = animation.Width / numOfFrameH;
                frameHeight = animation.Height / numOfFrameV;
            }
        }


        public void SetPos( Vector2 pos )
        {
            position = pos;
        }

        public Vector2 SetPos( int x, int y )
        {
            position.X = x;
            position.Y = y;
            return position;
        }

        public void SetBase()
        {
            animation = baseAnimation;

            frameWidth = animation.Width / numOfFrameH;
            frameHeight = animation.Height / numOfFrameV;
        }

    }
}