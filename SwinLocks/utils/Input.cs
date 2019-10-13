using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SwinLocks.utils
{
    class Input
    {
        public static KeyboardState lastKeyState;
        public static KeyboardState keyState = Keyboard.GetState();
        public static MouseState lastMouseState;
        public static MouseState mouseState = Mouse.GetState();

        public static bool KeyDown(Keys keyCode) =>
            lastKeyState.IsKeyDown(keyCode);

        public static bool MouseDown() =>
            mouseState.LeftButton == ButtonState.Pressed;

        public static bool KeyPressed(Keys keyCode) =>
            lastKeyState.IsKeyUp(keyCode) && keyState.IsKeyDown(keyCode);

        public static Vector2 MousePos() =>
            mouseState.Position.ToVector2();

        public static void Update()
        {
            lastKeyState = keyState;
            keyState = Keyboard.GetState();
            lastMouseState = mouseState;
            mouseState = Mouse.GetState();
        }
    }
}
