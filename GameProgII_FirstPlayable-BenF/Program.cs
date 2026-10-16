using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameProgII_FirstPlayable_BenF
{
    internal class Program
    {

        #region Added Feature ChrisF-Forced Maximize Startup
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow); //Define the 'Maximize' command constant


        private const int SW_RESTORE = 9;   // Unlocks the layout constraints
        private const int SW_MAXIMIZE = 3;
        #endregion

        static void Main(string[] args)
        {
        #region Added Feature ChrisF-Startup Maxixization
     

            Thread.Sleep(50);//does a little delay on startup to process the screen resize
            IntPtr handle = GetForegroundWindow();
            if (handle != IntPtr.Zero)
            {
                ShowWindow(handle, SW_RESTORE);
                ShowWindow(handle, SW_MAXIMIZE);
            }
      
        #endregion
           GameManager Game = new GameManager();

           while (true)
           {
               Game.GameStart();

               Game.GameEnd();
               
           }
            
        }
    }
}

#region old code
/*
static void CheckCollides(bool PlayerTurn)
{
    (int, int) playerPos = (playerPosX, playerPosY);

    if (PlayerTurn)
    {
        if (playerPos == enemy1Pos)
        {
            enemy1Health -= 1;

            //back to spawn
            enemy1Pos = (1, 12);
        }

        else if (playerPos == enemy2Pos)
        {
            enemy2Health -= 1;

            //back to spawn
            enemy2Pos = (23, 1);
        }

        else if (playerPos == enemy3Pos)
        {
            enemy3Health -= 1;

            //back to spawn
            enemy3Pos = (23, 12);
        }

        else
        {
            //do nothing
        }

        playerTurn = false;
    }

    else
    {
        if (playerPos == enemy1Pos)
        {
            playerHealth -= 1;

            //back to spawn
            enemy1Pos = (1, 12);
        }

        else if (playerPos == enemy2Pos)
        {
            playerHealth -= 1;

            //back to spawn
            enemy2Pos = (23, 1);
        }

        else if (playerPos == enemy3Pos)
        {
            playerHealth -= 1;

            //back to spawn
            enemy3Pos = (23, 12);
        }

        else
        {
            //do nothing
        }

        playerTurn = true;
    }
}
*/
#endregion
