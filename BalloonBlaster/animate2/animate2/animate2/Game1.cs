using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace animate2
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        KeyboardState lastKeyboardState = new KeyboardState();
        KeyboardState currentKeyboardState = new KeyboardState();


        enum screen
        {
            Mainmenu,
            Help,
            Credits,
            Win,
            Fail,
            Map1,
            Map2,
            Map3,
            Map4,
            Map5,
            NextLevel,
            pause
        }

        screen currentScreen;

        //Main menu
        SimpleTexture mainMenu;
        //Help
        SimpleTexture help;
        //Credits
        SimpleTexture credits;
        //win
        SimpleTexture win;
        //fail
        SimpleTexture fail;
        //nextLevel
        SimpleTexture nextLevel;
        //map1
        SimpleTexture map1Background;
        //map2
        SimpleTexture map2Background;
        //map3
        SimpleTexture map3Background;
        //map4
        SimpleTexture map4Background;
        //map5
        SimpleTexture map5Background;
        //crosshair
        SimpleTexture crosshair;
        //pause menu
        SimpleTexture pauseBackground;

        Random random = new Random();


        Baloon[] Level1Baloons = new Baloon[5];
        int Level1ArrowCount = 10;
        int score = 0;
        int Level1DesiredScore = 30;
        Arrow arrowLevel1;


        int setCurrentScrren;

        SpriteFont myFont;

        float timer = 1;         //Initialize a 10 second timer
        const float TIMER = 1;

        int timeforLevel1 = 70;
       
        Baloon[] Level2Baloons = new Baloon[8];
        bomb[] Level2Bombs = new bomb[3];
        Health[] Level2Health = new Health[3];
        int Level2ArrowCount = 13;
        int score1 = 0;
        int Level2DesiredScore = 50;
        Arrow arrowLevel2;

        SpriteFont myFont1;

        float timer1 = 1;
        const float TIMER1 = 1;

        int timeforLevel2 = 60;

        Baloon[] Level3Baloons = new Baloon[10];
        bomb[] Level3Bombs = new bomb[4];
        Health[] Level3Health = new Health[4];
        int Level3ArrowCount = 15;
        int score2 = 0;
        int Level3DesiredScore = 60;
        Arrow arrowLevel3;


        SpriteFont myFont2;

        float timer2 = 1;
        const float TIMER2 = 1;

        int timeforLevel3 = 50;


        Baloon[] Level4Baloons = new Baloon[12];
        Baloon[] Level4DeathBaloons = new Baloon[3];
        bomb[] Level4Bombs = new bomb[4];
        Health[] Level4Health = new Health[5];
        int Level4ArrowCount = 17;
        int score3 = 0;
        int Level4DesiredScore = 70;
        Arrow arrowLevel4;


        SpriteFont myFont3;

        float timer3 = 1;
        const float TIMER3 = 1;

        int timeforLevel4 = 40;

        Baloon[] Level5Baloons = new Baloon[15];
        Baloon[] Level5DeathBaloons = new Baloon[5];
        bomb[] Level5Bombs = new bomb[5];
        Health[] Level5Health = new Health[5];
        int Level5ArrowCount = 20;
        int score4 = 0;
        int Level5DesiredScore = 90;
        Arrow arrowLevel5;



        SpriteFont myFont4;

        float timer4 = 1;
        const float TIMER4 = 1;

        int timeforLevel5 = 30;
        
        //audio

        AudioEngine audioEngine;
        WaveBank waveBank;
        SoundBank soundBank;
        Cue backgroundMusic;
        bool WinOncePlay = true;
        Cue Win;
        bool FailOncePlay = true;
        Cue Fail;
        Cue Fire;
        Cue Blast;
        Cue KeyPress;
        Cue Bomb;
        Cue Balloon;
        Cue Health;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 720;
            graphics.PreferredBackBufferWidth = 1280;
            graphics.IsFullScreen = false;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);


            //Main menu
            mainMenu = new SimpleTexture(Content.Load<Texture2D>(@"Images\MenuPictures\MainMenu"),new Rectangle(), Vector2.Zero );
            //Help
            help = new SimpleTexture(Content.Load<Texture2D>(@"Images\MenuPictures\Help"), new Rectangle(), Vector2.Zero);
            //Credits
            credits = new SimpleTexture(Content.Load<Texture2D>(@"Images\MenuPictures\Credits"), new Rectangle(), Vector2.Zero);
            //win
            win = new SimpleTexture(Content.Load<Texture2D>(@"Images\MenuPictures\Win"), new Rectangle(), Vector2.Zero);
            //fail
            fail = new SimpleTexture(Content.Load<Texture2D>(@"Images\MenuPictures\Fail"), new Rectangle(), Vector2.Zero);
            //nextLeve
            nextLevel = new SimpleTexture(Content.Load<Texture2D>(@"Images\MenuPictures\NextLevel"), new Rectangle(), Vector2.Zero);

            //map1
            map1Background = new SimpleTexture(Content.Load<Texture2D>(@"Images\MapBackgrounds\map1"), new Rectangle(), Vector2.Zero);
            //map2
            map2Background = new SimpleTexture(Content.Load<Texture2D>(@"Images\MapBackgrounds\map4"), new Rectangle(), Vector2.Zero);
            //map3
            map3Background = new SimpleTexture(Content.Load<Texture2D>(@"Images\MapBackgrounds\map8"), new Rectangle(), Vector2.Zero);
            //map4
            map4Background = new SimpleTexture(Content.Load<Texture2D>(@"Images\MapBackgrounds\map6"), new Rectangle(), Vector2.Zero);
            //map5
            map5Background = new SimpleTexture(Content.Load<Texture2D>(@"Images\MapBackgrounds\map10"), new Rectangle(), Vector2.Zero);
            //crosshair
            crosshair = new SimpleTexture(Content.Load<Texture2D>(@"Images\Others\Crosshair"), new Rectangle(), new Vector2(800, 520));
            //pause
            pauseBackground = new SimpleTexture(Content.Load<Texture2D>(@"Images\MenuPictures\pauseMenu"), new Rectangle(), Vector2.Zero);

            //arrow

            arrowLevel1 = new Arrow(Content.Load<Texture2D>(@"Images\Others\Arrow"), new Rectangle(), new Vector2(2000, 620), 5f);
            arrowLevel2 = new Arrow(Content.Load<Texture2D>(@"Images\Others\Arrow"), new Rectangle(), new Vector2(2000, 620), 5f);
            arrowLevel3 = new Arrow(Content.Load<Texture2D>(@"Images\Others\Arrow"), new Rectangle(), new Vector2(2000, 620), 5f);
            arrowLevel4 = new Arrow(Content.Load<Texture2D>(@"Images\Others\Arrow"), new Rectangle(), new Vector2(2000, 620), 7f);
            arrowLevel5 = new Arrow(Content.Load<Texture2D>(@"Images\Others\Arrow"), new Rectangle(), new Vector2(2000, 620), 10f);
            //level2
            //bomb

            Level2Bombs[0] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level2Bombs[1] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level2Bombs[2] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);

            //health

            Level2Health[0] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level2Health[1] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level2Health[2] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);

            //level3
            //bomb
            Level3Bombs[0] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level3Bombs[1] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level3Bombs[2] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level3Bombs[3] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            //health
            Level3Health[0] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level3Health[1] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level3Health[2] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level3Health[3] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);

            //level4
            //bomb
            Level4Bombs[0] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level4Bombs[1] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level4Bombs[2] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level4Bombs[3] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            //health
            Level4Health[0] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level4Health[1] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level4Health[2] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level4Health[3] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level4Health[4] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);

            //level5
            //bomb
            Level5Bombs[0] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level5Bombs[1] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level5Bombs[2] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level5Bombs[3] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level5Bombs[4] = new bomb(Content.Load<Texture2D>(@"Images\Others\bomb"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            //health
            Level5Health[0] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level5Health[1] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level5Health[2] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level5Health[3] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);
            Level5Health[4] = new Health(Content.Load<Texture2D>(@"Images\Others\health"), new Rectangle(), new Vector2(random.Next(0, 1280), -100), 3f);

            //baloongs

            //Level1Baloons[0] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Yellow"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0,360)), 3f);
            //Level1Baloons[1] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Red"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            //Level1Baloons[2] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Orange"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            //Level1Baloons[3] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Pink"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            //Level1Baloons[4] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Purple"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);

            Level1Baloons[0] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Yellow"), new Rectangle(), new Vector2(0, random.Next(0, 360)), 3f);
            Level1Baloons[1] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Red"), new Rectangle(), new Vector2(256, random.Next(0, 360)), 3f);
            Level1Baloons[2] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Orange"), new Rectangle(), new Vector2(512, random.Next(0, 360)), 3f);
            Level1Baloons[3] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Pink"), new Rectangle(), new Vector2(768, random.Next(0, 360)), 3f);
            Level1Baloons[4] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Purple"), new Rectangle(), new Vector2(1024, random.Next(0, 360)), 3f);


            
            Level2Baloons[0] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Purple"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level2Baloons[1] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Pink"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level2Baloons[2] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Red"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level2Baloons[3] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Black"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level2Baloons[4] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Yellow"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level2Baloons[5] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Blue"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level2Baloons[6] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Brown"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level2Baloons[7] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Maroon"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
           
            Level3Baloons[0] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Purple"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level3Baloons[1] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Pink"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level3Baloons[2] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Red"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level3Baloons[3] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Black"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level3Baloons[4] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Yellow"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level3Baloons[5] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Blue"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level3Baloons[6] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Brown"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level3Baloons[7] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Maroon"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level3Baloons[8] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Orange"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level3Baloons[9] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Pink"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);

            //Level4 Death baloons

            Level4DeathBaloons[0] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\One1"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level4DeathBaloons[1] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\One"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level4DeathBaloons[2] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\One1"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);

            Level4Baloons[0] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Purple"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level4Baloons[1] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Pink"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level4Baloons[2] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Red"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level4Baloons[3] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Black"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level4Baloons[4] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Yellow"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level4Baloons[5] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Blue"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level4Baloons[6] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Brown"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level4Baloons[7] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Maroon"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level4Baloons[8] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Orange"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level4Baloons[9] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Pink"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level4Baloons[10] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Blue"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level4Baloons[11] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Brown"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);

            //Level5 Death baloons

            Level5DeathBaloons[0] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Two"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5DeathBaloons[1] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Two1"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5DeathBaloons[2] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Two"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5DeathBaloons[3] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Two1"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5DeathBaloons[4] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Two"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);


            Level5Baloons[0] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Purple"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[1] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Pink"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[2] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Red"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[3] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Black"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[4] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Yellow"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[5] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Blue"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[6] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Brown"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[7] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Maroon"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[8] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Orange"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[9] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Pink"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[10] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Blue"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[11] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Brown"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[12] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Maroon"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[13] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Orange"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            Level5Baloons[14] = new Baloon(Content.Load<Texture2D>(@"Images\Baloons\Pink"), new Rectangle(), new Vector2(random.Next(0, 1280), random.Next(0, 360)), 3f);
            

            //fonts

            myFont = Content.Load<SpriteFont>(@"Font\myFont");
            myFont1 = Content.Load<SpriteFont>(@"Font\myFont");
            myFont2 = Content.Load<SpriteFont>(@"Font\myFont");
            myFont3 = Content.Load<SpriteFont>(@"Font\myFont");
            myFont4 = Content.Load<SpriteFont>(@"Font\myFont");

            //audio

            audioEngine = new AudioEngine(@"Content\Audio\GameAudio.xgs");
            waveBank = new WaveBank(audioEngine, @"Content\Audio\Wave Bank.xwb");
            soundBank = new SoundBank(audioEngine, @"Content\Audio\Sound Bank.xsb");

            backgroundMusic = soundBank.GetCue("Background");
            backgroundMusic.Play();

            currentScreen = screen.Mainmenu;
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (currentKeyboardState.IsKeyDown(Keys.Q))
                this.Exit();

            lastKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            switch (currentScreen)
            {
                case screen.Mainmenu:
                    {
                        mainMenu.Update();

                        //set level data

                        Level1ArrowCount = 10;
                        score = 0;
                        timeforLevel1 = 70;

                        for (int x = 0; x < 5; x++)
                            Level1Baloons[x].doUpdate = true;

                        Level2ArrowCount = 13;
                        score1 = 0;
                        timeforLevel2 = 60;

                        
                        for (int x = 0; x < 8; x++)
                            Level2Baloons[x].doUpdate = true;

                        Level3ArrowCount = 15;
                        score2 = 0;
                        timeforLevel3 = 50;

                        for (int x = 0; x < 10; x++)
                            Level3Baloons[x].doUpdate = true;

                        Level4ArrowCount = 17;
                        score3 = 0;
                        timeforLevel4 = 40;

                        for (int x = 0; x < 12; x++)
                            Level4Baloons[x].doUpdate = true;

                        Level5ArrowCount = 20;
                        score4 = 0;
                        timeforLevel5 = 30;

                        for (int x = 0; x < 15; x++)
                            Level5Baloons[x].doUpdate = true;


                        Level1Baloons[0].position= new Vector2(0, random.Next(0,360));
                        Level1Baloons[1].position = new Vector2(256, random.Next(0, 360));
                        Level1Baloons[2].position = new Vector2(512, random.Next(0, 360));
                        Level1Baloons[3].position = new Vector2(768, random.Next(0, 360));
                        Level1Baloons[4].position = new Vector2(1024, random.Next(0, 360));

                        //end set

                        //start game
                        if ((currentKeyboardState.IsKeyDown(Keys.Enter) && lastKeyboardState.IsKeyUp(Keys.Enter)))
                        {

                            setCurrentScrren = 1;
                            KeyPress = soundBank.GetCue("KeyPress");
                            KeyPress.Play();

                            currentScreen = screen.Map1;
                        }

                        //show help
                        if ((currentKeyboardState.IsKeyDown(Keys.F1) && lastKeyboardState.IsKeyUp(Keys.F1)))
                        {
                            KeyPress = soundBank.GetCue("KeyPress");
                            KeyPress.Play();

                            currentScreen = screen.Help;
                        }

                        //show credits
                        if ((currentKeyboardState.IsKeyDown(Keys.F2) && lastKeyboardState.IsKeyUp(Keys.F2)))
                        {
                            KeyPress = soundBank.GetCue("KeyPress");
                            KeyPress.Play();

                            currentScreen = screen.Credits;
                        }

              


                        break;
                    }

                case screen.Help:
                    {
                        help.Update();

                        //go back
                        if ((currentKeyboardState.IsKeyDown(Keys.Escape) && lastKeyboardState.IsKeyUp(Keys.Escape)))
                        {
                            KeyPress = soundBank.GetCue("KeyPress");
                            KeyPress.Play();

                            currentScreen = screen.Mainmenu;
                        }

                        break;
                    }

                case screen.Credits:
                    {
                        credits.Update();

                        //go back
                        if ((currentKeyboardState.IsKeyDown(Keys.Escape) && lastKeyboardState.IsKeyUp(Keys.Escape)))
                        {
                            KeyPress = soundBank.GetCue("KeyPress");
                            KeyPress.Play();
                            currentScreen = screen.Mainmenu;
                        }
                        break;
                    }

                case screen.Win:
                    {
                        win.Update();

                        if (WinOncePlay)
                        {
                            Win = soundBank.GetCue("Win");
                            Win.Play();
                            WinOncePlay = false;
                        }
                        if ((currentKeyboardState.IsKeyDown(Keys.Enter) && lastKeyboardState.IsKeyUp(Keys.Enter)))
                        {

                            currentScreen = screen.Mainmenu;


                        }
                        break;
                    }

                case screen.Fail:
                    {
                        Level1Baloons[0].position = new Vector2(0, random.Next(0, 360));
                        Level1Baloons[1].position = new Vector2(256, random.Next(0, 360));
                        Level1Baloons[2].position = new Vector2(512, random.Next(0, 360));
                        Level1Baloons[3].position = new Vector2(768, random.Next(0, 360));
                        Level1Baloons[4].position = new Vector2(1024, random.Next(0, 360));


                        fail.Update();

                        if (FailOncePlay)
                        {
                            Fail = soundBank.GetCue("Fail");
                            Fail.Play();
                            FailOncePlay = false;
                        }

                        if ((currentKeyboardState.IsKeyDown(Keys.Enter) && lastKeyboardState.IsKeyUp(Keys.Enter)))
                        {
                           
                            KeyPress = soundBank.GetCue("KeyPress");
                            KeyPress.Play();

                            currentScreen = screen.Map1;
                        }

                     
                        //reset all map data

                        //reset map 1

                        Level1ArrowCount = 10;
                        score = 0;
                        timeforLevel1 = 70;
                       
                        for (int x = 0; x < 5; x++)
                            Level1Baloons[x].doUpdate = true;


                        //reset map 2

                        Level2ArrowCount = 13;
                        score1 = 0;
                        timeforLevel2 = 60;
                        //Level2ArrowCount -= 1;
                        //Level2ArrowCount += 2;
                        for (int x = 0; x < 8; x++)
                            Level2Baloons[x].doUpdate = true;

                   
                        //reset map 3

                        Level3ArrowCount = 15;
                        score2 = 0;
                        timeforLevel3 = 50;

                        for (int x = 0; x < 10; x++)
                            Level3Baloons[x].doUpdate = true;

                        //reset map 4

                        Level4ArrowCount = 17;
                        score3 = 0;
                        timeforLevel4 = 40;

                        for (int x = 0; x < 12; x++)
                            Level4Baloons[x].doUpdate = true;

                        //reset map 5

                        Level5ArrowCount = 20;
                        score4 = 0;
                        timeforLevel5 = 30;

                        for (int x = 0; x < 15; x++)
                            Level5Baloons[x].doUpdate = true;
                        
                            break;

                    }
            
                case screen.Map1:
                    {
                        FailOncePlay = true;
                        WinOncePlay = true;

                        setCurrentScrren = 1;

                        if ((currentKeyboardState.IsKeyDown(Keys.Escape) && lastKeyboardState.IsKeyUp(Keys.Escape)))
                        {
                            
                            KeyPress = soundBank.GetCue("KeyPress");
                            KeyPress.Play();

                            currentScreen = screen.pause;
                        }

                        
                        //if ((currentKeyboardState.IsKeyDown(Keys.F3) && lastKeyboardState.IsKeyUp(Keys.F3)))
                        //{
                            
                        //    KeyPress = soundBank.GetCue("KeyPress");
                        //    KeyPress.Play();

                        //    currentScreen = screen.Mainmenu;
                        //}

                        map1Background.Update();
                        crosshair.UpdateCrosshair();
                        arrowLevel1.Update();
                        

                        if ((currentKeyboardState.IsKeyDown(Keys.Space) && lastKeyboardState.IsKeyUp(Keys.Space)) && Level1ArrowCount >0)
                        {
                            Fire = soundBank.GetCue("Fire");
                            Fire.Play();

                            arrowLevel1.position = new Vector2(crosshair.position.X + 160, crosshair.position.Y) ;
                            arrowLevel1.n = true;
                            Level1ArrowCount--;
                        }


                        for (int x = 0; x < 5; x++)
                            Level1Baloons[x].Update(gameTime);

                       
                           for(int x=0; x<5; x++)
                        {
                            if (arrowLevel1.rect.Intersects(Level1Baloons[x].rect) && Level1Baloons[x].doUpdate)
                            {
                                arrowLevel1.position = new Vector2(5000, 5000);
                                Blast = soundBank.GetCue("Blast");
                                Blast.Play();

                                score += 10;
                                Level1Baloons[x].doUpdate = false;
                                
                                
                                
                            }

                          
                        }


                            //load next level
                            if (Level1ArrowCount == 0 && arrowLevel1.position == new Vector2(5000, 5000) && score >= Level1DesiredScore)
                                currentScreen = screen.NextLevel;

                            //display fail screen
                            if (Level1ArrowCount == 0 && arrowLevel1.position == new Vector2(5000, 5000) && score < Level1DesiredScore)
                                currentScreen = screen.Fail;

                            //load next level
                            if (timeforLevel1 < 0 && score >= Level1DesiredScore)
                                currentScreen = screen.NextLevel;

                            if (!Level1Baloons[0].doUpdate && !Level1Baloons[1].doUpdate && !Level1Baloons[2].doUpdate && !Level1Baloons[3].doUpdate && !Level1Baloons[4].doUpdate)
                            {
                                if (score >= Level1DesiredScore)
                                    currentScreen = screen.NextLevel;
                                else
                                    currentScreen = screen.Fail;
                            }

                            //display fail screen
                            if(timeforLevel1 < 0 && score < Level1DesiredScore)
                                currentScreen = screen.Fail;

                        // checking time for map1

                        float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                        timer -= elapsed;
                        if (timer < 0)
                        {
                            //Timer expired, execute action
                            timeforLevel1--;
                            timer = TIMER;   //Reset Timer
                        }

                     

                            break;
                    }

                case screen.Map2:
                    {
                        FailOncePlay = true;
                        WinOncePlay = true;
                        
                        setCurrentScrren = 2;

                        if ((currentKeyboardState.IsKeyDown(Keys.Escape) && lastKeyboardState.IsKeyUp(Keys.Escape)))
                        {
                            
                            KeyPress = soundBank.GetCue("KeyPress");
                            KeyPress.Play();

                            currentScreen = screen.pause;
                        }

                        //  if ((currentKeyboardState.IsKeyDown(Keys.F3) && lastKeyboardState.IsKeyUp(Keys.F3)))
                        //{
                            
                        //    KeyPress = soundBank.GetCue("KeyPress");
                        //    KeyPress.Play();

                        //    currentScreen = screen.Mainmenu;
                        //}
                       
                       
                        map2Background.Update();
                        crosshair.UpdateCrosshair();
                        arrowLevel2.Update();

                        if ((currentKeyboardState.IsKeyDown(Keys.Space) && lastKeyboardState.IsKeyUp(Keys.Space)) && Level2ArrowCount > 0)
                        {
                            Fire = soundBank.GetCue("Fire");
                            Fire.Play();

                            arrowLevel2.position = new Vector2(crosshair.position.X + 160, crosshair.position.Y);
                            arrowLevel2.n = true;
                            Level2ArrowCount--;
                        }

                        for (int x = 0; x < 8; x++)
                            Level2Baloons[x].Update(gameTime);

                        for (int x = 0; x < 8; x++)
                        {
                            if (arrowLevel2.rect.Intersects(Level2Baloons[x].rect) && Level2Baloons[x].doUpdate)
                            {
                                arrowLevel2.position = new Vector2(5000, 5000);
                                Blast = soundBank.GetCue("Blast");
                                Blast.Play();

                                score1 += 10;
                                Level2Baloons[x].doUpdate = false;
                            }
                        }

                        //load next level
                        if (Level2ArrowCount == 0 && arrowLevel2.position == new Vector2(5000, 5000) && score1 >= Level2DesiredScore)
                            currentScreen = screen.NextLevel;

                        //display fail screen
                        if (Level2ArrowCount == 0 && arrowLevel2.position == new Vector2(5000, 5000) && score1 < Level2DesiredScore)
                            currentScreen = screen.Fail;

                        //load next level
                        if (timeforLevel2 < 0 && score1 >= Level2DesiredScore)
                            currentScreen = screen.NextLevel;

                        if (!Level2Baloons[0].doUpdate && !Level2Baloons[1].doUpdate && !Level2Baloons[2].doUpdate && !Level2Baloons[3].doUpdate && !Level2Baloons[4].doUpdate && !Level2Baloons[5].doUpdate && !Level2Baloons[6].doUpdate && !Level2Baloons[7].doUpdate)
                        
                        {
                            if (score1 >= Level2DesiredScore)
                                currentScreen = screen.NextLevel;
                            else
                                currentScreen = screen.Fail;
                        }

                        //display fail screen
                        if (timeforLevel2 < 0 && score1 < Level2DesiredScore)
                            currentScreen = screen.Fail;

                        // checking time for map1

                        float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                        timer1 -= elapsed;
                        if (timer1 < 0)
                        {
                            //Timer expired, execute action
                            timeforLevel2--;
                            timer1 = TIMER1;   //Reset Timer
                        }

                        //BOMBS

                        //drop bomb at 55
                        if (timeforLevel2 < 55)
                        {
                            Level2Bombs[0].n = true;
                            Level2Bombs[0].Update(gameTime);
                        }

                        //drop bomb at 35
                        if (timeforLevel2 < 35)
                        {
                            Level2Bombs[1].n = true;
                            Level2Bombs[1].Update(gameTime);
                        }

                        //drop bomb at 15
                        if (timeforLevel2 < 15)
                        {
                            Level2Bombs[2].n = true;
                            Level2Bombs[2].Update(gameTime);
                        }

                        //check bomb collide with bow
                        for (int x = 0; x < 3; x++)
                        {
                            if (Level2Bombs[x].getRectangle().Intersects(crosshair.getRectangle()))
                            {
                                Bomb = soundBank.GetCue("Bomb");
                                Bomb.Play();
                                Level2Bombs[x].position = new Vector2(50000, 50000);
                                Level2ArrowCount -= 1;
                            }
                        }


                        //HEALTH

                        //drop health at 45
                        if (timeforLevel2 < 45)
                        {
                            Level2Health[0].n = true;
                            Level2Health[0].Update(gameTime);
                        }

                        //drop health at 25
                        if (timeforLevel2 < 25)
                        {
                            Level2Health[1].n = true;
                            Level2Health[1].Update(gameTime);
                        }

                        //drop health at 10
                        if (timeforLevel2 < 10)
                        {
                            Level2Health[2].n = true;
                            Level2Health[2].Update(gameTime);
                        }

                        //check health collide with arrow
                        for (int x = 0; x < 3; x++)
                        {
                            if (Level2Health[x].getRectangle().Intersects(arrowLevel2.getRectangle()))
                            {

                                arrowLevel2.position = new Vector2(5000, 5000);
                                Health = soundBank.GetCue("Health");
                                Health.Play();


                                Level2Health[x].position = new Vector2(50000, 50000);
                                Level2ArrowCount += 2;
                            }
                        }

                        break;
                    }

                case screen.Map3:
                    {

                        FailOncePlay = true;
                        WinOncePlay = true;

                        setCurrentScrren = 3;

                        if ((currentKeyboardState.IsKeyDown(Keys.Escape) && lastKeyboardState.IsKeyUp(Keys.Escape)))
                        {

                            KeyPress = soundBank.GetCue("KeyPress");
                            KeyPress.Play();

                            currentScreen = screen.pause;
                        }

                        // if ((currentKeyboardState.IsKeyDown(Keys.F3) && lastKeyboardState.IsKeyUp(Keys.F3)))
                        //{

                        //    KeyPress = soundBank.GetCue("KeyPress");
                        //    KeyPress.Play();

                        //    currentScreen = screen.Mainmenu;
                        //}

                        map3Background.Update();
                        crosshair.UpdateCrosshair();
                        arrowLevel3.Update();

                        if ((currentKeyboardState.IsKeyDown(Keys.Space) && lastKeyboardState.IsKeyUp(Keys.Space)) && Level3ArrowCount > 0)
                        {
                            Fire = soundBank.GetCue("Fire");
                            Fire.Play();

                            arrowLevel3.position = new Vector2(crosshair.position.X + 160, crosshair.position.Y);
                            arrowLevel3.n = true;
                            Level3ArrowCount--;
                        }

                        for (int x = 0; x < 10; x++)
                            Level3Baloons[x].Update(gameTime);

                        for (int x = 0; x < 10; x++)
                        {
                            if (arrowLevel3.rect.Intersects(Level3Baloons[x].rect) && Level3Baloons[x].doUpdate)
                            {
                                arrowLevel3.position = new Vector2(5000, 5000);
                                Blast = soundBank.GetCue("Blast");
                                Blast.Play();

                                score2 += 10;
                                Level3Baloons[x].doUpdate = false;
                            }
                        }

                        //load next level
                        if (Level3ArrowCount == 0 && arrowLevel3.position == new Vector2(5000, 5000) && score2 >= Level3DesiredScore)
                            currentScreen = screen.NextLevel;

                        //display fail screen
                        if (Level3ArrowCount == 0 && arrowLevel3.position == new Vector2(5000, 5000) && score2 < Level3DesiredScore)
                            currentScreen = screen.Fail;

                        //load next level
                        if (timeforLevel3 < 0 && score2 >= Level3DesiredScore)
                            currentScreen = screen.NextLevel;

                        if (!Level3Baloons[0].doUpdate && !Level3Baloons[1].doUpdate && !Level3Baloons[2].doUpdate && !Level3Baloons[3].doUpdate && !Level3Baloons[4].doUpdate && !Level3Baloons[5].doUpdate && !Level3Baloons[6].doUpdate && !Level3Baloons[7].doUpdate)
                        {
                            if (score2 >= Level3DesiredScore)
                                currentScreen = screen.NextLevel;
                            else
                                currentScreen = screen.Fail;
                        }

                        //display fail screen
                        if (timeforLevel3 < 0 && score2 < Level3DesiredScore)
                            currentScreen = screen.Fail;

                        // checking time for map1

                        float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                        timer2 -= elapsed;
                        if (timer2 < 0)
                        {
                            //Timer expired, execute action
                            timeforLevel3--;
                            timer2 = TIMER2;   //Reset Timer
                        }

                        //BOMBS

                        //drop bomb at 45
                        if (timeforLevel3 < 45)
                        {
                            Level3Bombs[0].n = true;
                            Level3Bombs[0].Update(gameTime);
                        }

                        //drop bomb at 35
                        if (timeforLevel3 < 35)
                        {
                            Level3Bombs[1].n = true;
                            Level3Bombs[1].Update(gameTime);
                        }

                        //drop bomb at 25
                        if (timeforLevel3 < 25)
                        {
                            Level3Bombs[2].n = true;
                            Level3Bombs[2].Update(gameTime);
                        }

                        //drop bomb at 15
                        if (timeforLevel3 < 15)
                        {
                            Level3Bombs[3].n = true;
                            Level3Bombs[3].Update(gameTime);
                        }


                        //check bomb collide with bow
                        for (int x = 0; x < 4; x++)
                        {
                            if (Level3Bombs[x].getRectangle().Intersects(crosshair.getRectangle()))
                            {
                                Bomb = soundBank.GetCue("Bomb");
                                Bomb.Play();
                                Level3Bombs[x].position = new Vector2(50000, 50000);
                                Level3ArrowCount -= 1;
                            }
                        }


                        //HEALTH

                        //drop health at 40
                        if (timeforLevel3 < 40)
                        {
                            Level3Health[0].n = true;
                            Level3Health[0].Update(gameTime);
                        }

                        //drop health at 30
                        if (timeforLevel3 < 30)
                        {
                            Level3Health[1].n = true;
                            Level3Health[1].Update(gameTime);
                        }

                        //drop health at 20
                        if (timeforLevel3 < 20)
                        {
                            Level3Health[2].n = true;
                            Level3Health[2].Update(gameTime);
                        }

                        //drop health at 10
                        if (timeforLevel3 < 10)
                        {
                            Level3Health[3].n = true;
                            Level3Health[3].Update(gameTime);
                        }

                        //check health collide with arrow
                        for (int x = 0; x < 4; x++)
                        {
                            if (Level3Health[x].getRectangle().Intersects(arrowLevel3.getRectangle()))
                            {

                                arrowLevel3.position = new Vector2(5000, 5000);
                                Health = soundBank.GetCue("Health");
                                Health.Play();


                                Level3Health[x].position = new Vector2(50000, 50000);
                                Level3ArrowCount += 2;
                            }
                        }

                        break;
                    }

                case screen.Map4:
                    {
                        FailOncePlay = true;
                        WinOncePlay = true;

                        setCurrentScrren = 4;

                        if ((currentKeyboardState.IsKeyDown(Keys.Escape) && lastKeyboardState.IsKeyUp(Keys.Escape)))
                        {

                            KeyPress = soundBank.GetCue("KeyPress");
                            KeyPress.Play();

                            currentScreen = screen.pause;
                        }

                        //if ((currentKeyboardState.IsKeyDown(Keys.F3) && lastKeyboardState.IsKeyUp(Keys.F3)))
                        //{

                        //    KeyPress = soundBank.GetCue("KeyPress");
                        //    KeyPress.Play();

                        //    currentScreen = screen.Mainmenu;
                        //}

                        map4Background.Update();
                        crosshair.UpdateCrosshair();
                        arrowLevel4.Update();

                        if ((currentKeyboardState.IsKeyDown(Keys.Space) && lastKeyboardState.IsKeyUp(Keys.Space)) && Level4ArrowCount > 0)
                        {
                            Fire = soundBank.GetCue("Fire");
                            Fire.Play();

                            arrowLevel4.position = new Vector2(crosshair.position.X + 160, crosshair.position.Y);
                            arrowLevel4.n = true;
                            Level4ArrowCount--;
                        }

                        for (int x = 0; x < 12; x++)
                            Level4Baloons[x].Update(gameTime);

                        for (int x = 0; x < 3; x++)
                            Level4DeathBaloons[x].Update(gameTime);


                        for (int x = 0; x < 12; x++)
                        {
                            if (arrowLevel4.rect.Intersects(Level4Baloons[x].rect) && Level4Baloons[x].doUpdate)
                            {
                                arrowLevel4.position = new Vector2(5000, 5000);
                                Blast = soundBank.GetCue("Blast");
                                Blast.Play();

                                score3 += 10;
                                Level4Baloons[x].doUpdate = false;
                            }

                            //for death ballons
                            if (x < 3)
                            {
                                if (arrowLevel4.rect.Intersects(Level4DeathBaloons[x].rect) && Level4DeathBaloons[x].doUpdate)
                                {
                                    arrowLevel4.position = new Vector2(5000, 5000);
                                    Balloon = soundBank.GetCue("Balloon");
                                    Balloon.Play();

                                    //decrese score if hit
                                    score3 -= 20;
                                    Level4DeathBaloons[x].doUpdate = false;



                                }
                            }
                        }
                        //load next level
                        if (Level4ArrowCount == 0 && arrowLevel4.position == new Vector2(5000, 5000) && score3 >= Level4DesiredScore)
                            currentScreen = screen.NextLevel;

                        //display fail screen
                        if (Level4ArrowCount == 0 && arrowLevel4.position == new Vector2(5000, 5000) && score3 < Level4DesiredScore)
                            currentScreen = screen.Fail;

                        //load next level
                        if (timeforLevel4 < 0 && score3 >= Level4DesiredScore)
                            currentScreen = screen.NextLevel;

                        if (!Level4Baloons[0].doUpdate && !Level4Baloons[1].doUpdate && !Level4Baloons[2].doUpdate && !Level4Baloons[3].doUpdate && !Level4Baloons[4].doUpdate && !Level4Baloons[5].doUpdate && !Level4Baloons[6].doUpdate && !Level4Baloons[7].doUpdate && !Level4Baloons[8].doUpdate && !Level4Baloons[9].doUpdate && !Level4Baloons[10].doUpdate && !Level4Baloons[11].doUpdate)
                        {
                            if (score3 >= Level4DesiredScore)
                                currentScreen = screen.NextLevel;
                            else
                                currentScreen = screen.Fail;
                        }

                        //display fail screen
                        if (timeforLevel4 < 0 && score3 < Level4DesiredScore)
                            currentScreen = screen.Fail;

                        // checking time for map1

                        float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                        timer3 -= elapsed;
                        if (timer3< 0)
                        {
                            //Timer expired, execute action
                            timeforLevel4--;
                            timer3 = TIMER3;  //Reset Timer
                        }

                        //BOMBS

                        //drop bomb at 35
                        if (timeforLevel4 < 35)
                        {
                            Level4Bombs[0].n = true;
                            Level4Bombs[0].Update(gameTime);
                        }

                        //drop bomb at 25
                        if (timeforLevel4 < 25)
                        {
                            Level4Bombs[1].n = true;
                            Level4Bombs[1].Update(gameTime);
                        }

                        //drop bomb at 15
                        if (timeforLevel4 < 15)
                        {
                            Level3Bombs[2].n = true;
                            Level3Bombs[2].Update(gameTime);
                        }

                        //drop bomb at 5
                        if (timeforLevel4 < 5)
                        {
                            Level4Bombs[3].n = true;
                            Level4Bombs[3].Update(gameTime);
                        }


                        //check bomb collide with bow
                        for (int x = 0; x < 4; x++)
                        {
                            if (Level4Bombs[x].getRectangle().Intersects(crosshair.getRectangle()))
                            {
                                Bomb = soundBank.GetCue("Bomb");
                                Bomb.Play();
                                Level4Bombs[x].position = new Vector2(50000, 50000);
                                Level4ArrowCount -= 1;
                            }
                        }


                        //HEALTH

                        //drop health at 30
                        if (timeforLevel4 < 30)
                        {
                            Level4Health[0].n = true;
                            Level4Health[0].Update(gameTime);
                        }

                        //drop health at 22
                        if (timeforLevel4 < 22)
                        {
                            Level4Health[1].n = true;
                            Level4Health[1].Update(gameTime);
                        }

                        //drop health at 17
                        if (timeforLevel4 < 17)
                        {
                            Level4Health[2].n = true;
                            Level4Health[2].Update(gameTime);
                        }

                        //drop health at 10
                        if (timeforLevel4 < 10)
                        {
                            Level4Health[3].n = true;
                            Level4Health[3].Update(gameTime);
                        }

                        //drop health at 4
                        if (timeforLevel4 < 4)
                        {
                            Level4Health[4].n = true;
                            Level4Health[4].Update(gameTime);
                        }

                        //check health collide with arrow
                        for (int x = 0; x < 5; x++)
                        {
                            if (Level4Health[x].getRectangle().Intersects(arrowLevel4.getRectangle()))
                            {

                                arrowLevel4.position = new Vector2(5000, 5000);
                                Health = soundBank.GetCue("Health");
                                Health.Play();


                                Level4Health[x].position = new Vector2(50000, 50000);
                                Level4ArrowCount += 2;
                            }
                        }


                        break;
                    }

                case screen.Map5:
                    {
                        FailOncePlay = true;
                        WinOncePlay = true;

                        setCurrentScrren = 5;

                        if ((currentKeyboardState.IsKeyDown(Keys.Escape) && lastKeyboardState.IsKeyUp(Keys.Escape)))
                        {

                            KeyPress = soundBank.GetCue("KeyPress");
                            KeyPress.Play();

                            currentScreen = screen.pause;
                        }

                        
                        //if ((currentKeyboardState.IsKeyDown(Keys.F3) && lastKeyboardState.IsKeyUp(Keys.F3)))
                        //{

                        //    KeyPress = soundBank.GetCue("KeyPress");
                        //    KeyPress.Play();

                        //    currentScreen = screen.Mainmenu;
                        //}

                        map5Background.Update();
                        crosshair.UpdateCrosshair();
                        arrowLevel5.Update();

                        if ((currentKeyboardState.IsKeyDown(Keys.Space) && lastKeyboardState.IsKeyUp(Keys.Space)) && Level5ArrowCount > 0)
                        {
                            Fire = soundBank.GetCue("Fire");
                            Fire.Play();

                            arrowLevel5.position = new Vector2(crosshair.position.X + 160, crosshair.position.Y);
                            arrowLevel5.n = true;
                            Level5ArrowCount--;
                        }

                        for (int x = 0; x < 15; x++)
                            Level5Baloons[x].Update(gameTime);

                        for (int x = 0; x < 5; x++)
                            Level5DeathBaloons[x].Update(gameTime);


                        for (int x = 0; x < 15; x++)
                        {
                            if (arrowLevel5.rect.Intersects(Level5Baloons[x].rect) && Level5Baloons[x].doUpdate)
                            {
                                arrowLevel5.position = new Vector2(5000, 5000);
                                Blast = soundBank.GetCue("Blast");
                                Blast.Play();

                                score4 += 10;
                                Level5Baloons[x].doUpdate = false;
                            }



                            //for death ballons
                            if (x < 5)
                            {
                                if (arrowLevel5.rect.Intersects(Level5DeathBaloons[x].rect) && Level5DeathBaloons[x].doUpdate)
                                {
                                    arrowLevel5.position = new Vector2(5000, 5000);
                                    Balloon = soundBank.GetCue("Balloon");
                                    Balloon.Play();

                                    //decrese score if hit
                                    score4 -= 20;
                                    Level5DeathBaloons[x].doUpdate = false;



                                }

                            }

                        }   

                        //load next level
                        if (Level5ArrowCount == 0 && arrowLevel5.position == new Vector2(5000, 5000) && score4 >= Level5DesiredScore)
                            currentScreen = screen.NextLevel;

                        //display fail screen
                        if (Level5ArrowCount == 0 && arrowLevel5.position == new Vector2(5000, 5000) && score4 < Level5DesiredScore)
                            currentScreen = screen.Fail;

                        //load next level
                        if (timeforLevel5 < 0 && score4 >= Level5DesiredScore)
                            currentScreen = screen.NextLevel;

                        if (!Level5Baloons[0].doUpdate && !Level5Baloons[1].doUpdate && !Level5Baloons[2].doUpdate && !Level5Baloons[3].doUpdate && !Level5Baloons[4].doUpdate && !Level5Baloons[5].doUpdate && !Level5Baloons[6].doUpdate && !Level5Baloons[7].doUpdate && !Level5Baloons[8].doUpdate && !Level5Baloons[9].doUpdate && !Level5Baloons[10].doUpdate && !Level5Baloons[11].doUpdate && !Level5Baloons[12].doUpdate && !Level5Baloons[13].doUpdate && !Level5Baloons[14].doUpdate)
                        {
                            if (score4 >= Level5DesiredScore)
                                currentScreen = screen.NextLevel;
                            else
                                currentScreen = screen.Fail;
                        }

                        //display fail screen
                        if (timeforLevel5 < 0 && score4 < Level5DesiredScore)
                            currentScreen = screen.Fail;

                        // checking time for map1

                        float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;
                        timer4 -= elapsed;
                        if (timer4 < 0)
                        {
                            //Timer expired, execute action
                            timeforLevel5--;
                            timer4 = TIMER4;  //Reset Timer
                        }

                        //BOMBS

                        //drop bomb at 27
                        if (timeforLevel5 < 27)
                        {
                            Level5Bombs[0].n = true;
                            Level5Bombs[0].Update(gameTime);
                        }

                        //drop bomb at 22
                        if (timeforLevel5 < 22)
                        {
                            Level5Bombs[1].n = true;
                            Level5Bombs[1].Update(gameTime);
                        }

                        //drop bomb at 17
                        if (timeforLevel5 < 17)
                        {
                            Level5Bombs[2].n = true;
                            Level5Bombs[2].Update(gameTime);
                        }

                        //drop bomb at 12
                        if (timeforLevel5 < 12)
                        {
                            Level5Bombs[3].n = true;
                            Level5Bombs[3].Update(gameTime);
                        }

                        //drop bomb at 7
                        if (timeforLevel5 < 7)
                        {
                            Level5Bombs[4].n = true;
                            Level5Bombs[4].Update(gameTime);
                        }

                        //check bomb collide with bow
                        for (int x = 0; x < 5; x++)
                        {
                            if (Level5Bombs[x].getRectangle().Intersects(crosshair.getRectangle()))
                            {
                                Bomb = soundBank.GetCue("Bomb");
                                Bomb.Play();
                                Level5Bombs[x].position = new Vector2(50000, 50000);
                                Level5ArrowCount -= 1;
                            }
                        }


                        //HEALTH

                        //drop health at 25
                        if (timeforLevel5 < 25)
                        {
                            Level5Health[0].n = true;
                            Level5Health[0].Update(gameTime);
                        }

                        //drop health at 20
                        if (timeforLevel5 < 20)
                        {
                            Level5Health[1].n = true;
                            Level5Health[1].Update(gameTime);
                        }

                        //drop health at 15
                        if (timeforLevel5 < 15)
                        {
                            Level5Health[2].n = true;
                            Level5Health[2].Update(gameTime);
                        }

                        //drop health at 10
                        if (timeforLevel5 < 10)
                        {
                            Level5Health[3].n = true;
                            Level5Health[3].Update(gameTime);
                        }

                        //drop health at 4
                        if (timeforLevel5 < 4)
                        {
                            Level5Health[4].n = true;
                            Level5Health[4].Update(gameTime);
                        }

                        //check health collide with arrow
                        for (int x = 0; x < 5; x++)
                        {
                            if (Level5Health[x].getRectangle().Intersects(arrowLevel5.getRectangle()))
                            {

                                arrowLevel5.position = new Vector2(5000, 5000);
                                Health = soundBank.GetCue("Health");
                                Health.Play();


                                Level5Health[x].position = new Vector2(50000, 50000);
                                Level5ArrowCount += 2;
                            }
                        }


                        break;
                    }

                

                case screen.NextLevel:
                    {

                        if (WinOncePlay)
                        {
                            Win = soundBank.GetCue("Win");
                            Win.Play();
                            WinOncePlay = false;
                        }

                        if ((currentKeyboardState.IsKeyDown(Keys.Enter) && lastKeyboardState.IsKeyUp(Keys.Enter)) && setCurrentScrren != 5)
                        {
                            if (setCurrentScrren == 1)
                                currentScreen = screen.Map2;
                            if (setCurrentScrren == 2)
                                currentScreen = screen.Map3;
                            if (setCurrentScrren == 3)
                                currentScreen = screen.Map4;
                            if (setCurrentScrren== 4)
                                currentScreen = screen.Map5;
                         
                        }

                        if (setCurrentScrren == 5)
                            currentScreen = screen.Win;

                      
                        break;
                    }

                case screen.pause:
                    {
                        pauseBackground.Update();

                        if ((currentKeyboardState.IsKeyDown(Keys.Enter) && lastKeyboardState.IsKeyUp(Keys.Enter)))
                        {
                            if (setCurrentScrren == 1)
                                currentScreen = screen.Map1;
                            if (setCurrentScrren == 2)
                                currentScreen = screen.Map2;
                            if (setCurrentScrren == 3)
                                currentScreen = screen.Map3;
                            if (setCurrentScrren == 4)
                                currentScreen = screen.Map4;
                            if (setCurrentScrren == 5)
                                currentScreen = screen.Map5;
                           
                        }

                        if ((currentKeyboardState.IsKeyDown(Keys.F3) && lastKeyboardState.IsKeyUp(Keys.F3)))
                        {
                           
                                currentScreen = screen.Mainmenu;
                          

                        }
                   
      
                    
                   break;
                }
            
               
                default:
                    {
                        break;
                    }
            }
          

            

    

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            switch (currentScreen)
            {
                case screen.Mainmenu:
                    {
                        mainMenu.DrawBackground(spriteBatch);
                        break;
                    }

                case screen.Help:
                    {
                        help.DrawBackground(spriteBatch);
                        break;
                    }

                case screen.Credits:
                    {
                        credits.DrawBackground(spriteBatch);
                        break;
                    }

                case screen.Win:
                    {
                        win.DrawBackground(spriteBatch);
                        break;
                    }

                case screen.Fail:
                    {
                        fail.DrawBackground(spriteBatch);
                        break;
                    }

                case screen.Map1:
                    {
                        map1Background.DrawBackground(spriteBatch);
                        crosshair.Draw(spriteBatch);

                        for (int x = 0; x < 5; x++)
                            Level1Baloons[x].Draw(spriteBatch);

                        
                      

                        arrowLevel1.Draw(spriteBatch);

                        //draw marks and remaining arrows

                        spriteBatch.DrawString(myFont, "Remaining Time : " + timeforLevel1.ToString() , new Vector2(5, 590), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont, "Score : " + score.ToString(), new Vector2(5, 620), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont, "Arrows : " + Level1ArrowCount.ToString(), new Vector2(5, 680), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont, "DesiredScore : 30 ", new Vector2(5, 650), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                            
                        break;
                    }

                case screen.Map2:
                    {
                        map2Background.DrawBackground(spriteBatch);
                        crosshair.Draw(spriteBatch);

                        for (int x = 0; x < 8; x++)
                            Level2Baloons[x].Draw(spriteBatch);
                        
                        for (int x = 0; x < 3; x++)
                            Level2Bombs[x].Draw(spriteBatch);

                        for (int x = 0; x < 3; x++)
                            Level2Health[x].Draw(spriteBatch);

                        arrowLevel2.Draw(spriteBatch);

                        //draw marks and remaining arrows

                        spriteBatch.DrawString(myFont1, "Remaining Time : " + timeforLevel2.ToString(), new Vector2(5, 590), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont1, "Score : " + score1.ToString(), new Vector2(5, 620), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont1, "Arrows : " + Level2ArrowCount.ToString(), new Vector2(5, 680), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont1, "DesiredScore : 50 ", new Vector2(5, 650), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        break; 

                      
                    }

                case screen.Map3:
                    {
                        map3Background.DrawBackground(spriteBatch);
                        crosshair.Draw(spriteBatch);

                        for (int x = 0; x < 10; x++)
                            Level3Baloons[x].Draw(spriteBatch);
                       
                        for (int x = 0; x < 4; x++)
                            Level3Bombs[x].Draw(spriteBatch);

                        for (int x = 0; x < 4; x++)
                            Level3Health[x].Draw(spriteBatch);


                        arrowLevel3.Draw(spriteBatch);

                        //draw marks and remaining arrows

                        spriteBatch.DrawString(myFont2, "Remaining Time : " + timeforLevel3.ToString(), new Vector2(5, 590), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont2, "Score : " + score2.ToString(), new Vector2(5, 620), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont2, "Arrows : " + Level3ArrowCount.ToString(), new Vector2(5, 680), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont2, "DesiredScore : 60 ", new Vector2(5, 650), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);

                        break;
                    }

                case screen.Map4:
                    {
                        map4Background.DrawBackground(spriteBatch);
                        crosshair.Draw(spriteBatch);

                        for (int x = 0; x < 12; x++)
                            Level4Baloons[x].Draw(spriteBatch);
                       
                        for (int x = 0; x < 3; x++)
                            Level4DeathBaloons[x].Draw(spriteBatch);

                        for (int x = 0; x < 4; x++)
                            Level4Bombs[x].Draw(spriteBatch);

                        for (int x = 0; x < 5; x++)
                            Level4Health[x].Draw(spriteBatch);

                        arrowLevel4.Draw(spriteBatch);

                        //draw marks and remaining arrows

                        spriteBatch.DrawString(myFont3, "Remaining Time : " + timeforLevel4.ToString(), new Vector2(5, 590), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont3, "Score : " + score3.ToString(), new Vector2(5, 620), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont3, "Arrows : " + Level4ArrowCount.ToString(), new Vector2(5, 680), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont3, "DesiredScore : 70 ", new Vector2(5, 650), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);


                        break;
                    }

                case screen.Map5:
                    {
                        map5Background.DrawBackground(spriteBatch);
                        crosshair.Draw(spriteBatch);

                        for (int x = 0; x < 15; x++)
                            Level5Baloons[x].Draw(spriteBatch);

                        for (int x = 0; x < 5; x++)
                            Level5DeathBaloons[x].Draw(spriteBatch);

                        for (int x = 0; x < 5; x++)
                            Level5Bombs[x].Draw(spriteBatch);

                        for (int x = 0; x < 5; x++)
                            Level5Health[x].Draw(spriteBatch);

                        arrowLevel5.Draw(spriteBatch);

                        //draw marks and remaining arrows

                        spriteBatch.DrawString(myFont4, "Remaining Time : " + timeforLevel5.ToString(), new Vector2(5, 590), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont4, "Score : " + score4.ToString(), new Vector2(5, 620), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont4, "Arrows : " + Level5ArrowCount.ToString(), new Vector2(5, 680), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);
                        spriteBatch.DrawString(myFont4, "DesiredScore : 90 ", new Vector2(5, 650), Color.Black, 0, Vector2.Zero, 1, SpriteEffects.None, 1);


                        break;
                    }

               

                case screen.NextLevel:
                    {
                        nextLevel.Draw(spriteBatch);


                        break;
                    }

                case screen.pause:
                    {
                        pauseBackground.DrawBackground(spriteBatch);

                        
                        break;
                    }
            

                default:
                    {
                        break;
                    }
            }


 
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
