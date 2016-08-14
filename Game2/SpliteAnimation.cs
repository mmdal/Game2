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
        Rectangle sourceRect;
        Vector2 position;

        float elapsed;
        float frameTime;
        int numOfFrameH;
        int numOfFrameV;
        int numOfFrameTotal;
        int currentFrame;
        int width;
        int height;
        int frameWidth;
        int frameHeight;
        bool looping;

        public SpliteAnimation(ContentManager Content_, string assetName_, float frameSpeed_
            ,int numOfFrameH_, int numOfFrameV_, int numOfFrameTotal_, bool looping_ )
        {
            this.frameTime  = frameSpeed_;
            this.numOfFrameH = numOfFrameH_;
            this.numOfFrameV = numOfFrameV_;
            this.numOfFrameTotal = numOfFrameTotal_;

            this.looping    = looping_;
             this.animation = Content_.Load<Texture2D>(assetName_);
            frameWidth = animation.Width / numOfFrameH_;
            frameHeight = animation.Height / numOfFrameV_;
            position = new Vector2(0, 0);
            elapsed = 0f;
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
            spriteBatch.Draw(animation, position, sourceRect, Color.White, 0f, new Vector2( 0f, 0f ), 1f, SpriteEffects.None, 1f );
            //spriteBatch.Draw(animation, position, sourceRect, new Color(255f,255f,255f,255f), 0f, new Vector2(0, 0), SpriteEffects.None, 1f);
        }

        public Vector2 Position
        {
            get { return this.position; }
            set { this.position = value; }
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
  
    }
}