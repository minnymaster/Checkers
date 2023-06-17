using Microsoft.VisualStudio.TestTools.UnitTesting;
using Checkers;
using System.Windows.Forms;
using System.Drawing;
using System;

namespace CheckersTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void TestInit()
        {
            Game game = new Game();

            var expectedCurrentPlayer = 1;
            var expectedIsMoving = false;
            Button expectedPrevButton = null;

            Assert.IsTrue(game.currentPlayer == expectedCurrentPlayer && game.isMoving == expectedIsMoving && game.prevButton == expectedPrevButton);
        }

        [TestMethod]
        public void TestSwitchPlayer()
        {
            Game game = new Game();

            var initialCurrentPlayer = game.currentPlayer;

            game.SwitchPlayer();

            Assert.IsFalse(game.currentPlayer == initialCurrentPlayer);
        }

        [TestMethod]
        public void TestSwitchPlayerError()
        {
            Game game = new Game();

            var initialCurrentPlayer = game.currentPlayer;

            game.map = new int[Game.mapSize, Game.mapSize] {
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0 }
            };
            game.SwitchPlayer();

            Assert.IsTrue(1 == 1);
        }

        [TestMethod]
        public void TestOnFigurePress_CorrectMove()
        {
            Game game = new Game();

            Button figureButton = new Button();
            figureButton.Location = new System.Drawing.Point { X = 150, Y = 100 };

            Button cellButton = new Button();
            cellButton.Location = new System.Drawing.Point { X = 100, Y = 150 };

            game.OnFigurePress(figureButton, new System.EventArgs());
            game.OnFigurePress(cellButton, new System.EventArgs());

            Assert.IsTrue(game.currentPlayer == 2);
        }

        [TestMethod]
        public void TestOnFigurePress_CancelMove()
        {
            Game game = new Game();

            Button figureButton = new Button();
            figureButton.Location = new System.Drawing.Point { X = 150, Y = 100 };

            Button cellButton = new Button();
            cellButton.Location = new System.Drawing.Point { X = 150, Y = 100 };

            game.OnFigurePress(figureButton, new System.EventArgs());
            game.OnFigurePress(cellButton, new System.EventArgs());

            Assert.IsTrue(game.currentPlayer == 1);
        }

        [TestMethod]
        public void TestOnFigurePress_GameSimulation()
        {
            Game game = new Game();

            Button testButton = new Button();
            testButton.Location = new System.Drawing.Point { X = 150, Y = 100 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 150 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 250 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 150, Y = 200 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 150 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 50, Y = 200 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 0, Y = 250 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 150 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 50, Y = 100 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 0, Y = 150 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 150 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 150, Y = 100 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 50 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 200, Y = 150 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 250 };
            game.OnFigurePress(testButton, new System.EventArgs());

            Assert.IsTrue(game.currentPlayer == 2);
        }

        [TestMethod]
        public void TestShowProceduralEat_NoEat()
        {
            Game game = new Game();

            Button testButton = new Button();
            testButton.Location = new System.Drawing.Point { X = 150, Y = 100 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 150 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 250 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 150, Y = 200 };
            game.OnFigurePress(testButton, new System.EventArgs());

            game.ShowProceduralEat(150, 100);

            Assert.IsTrue(game.currentPlayer == 1);
        }

        [TestMethod]
        public void TestShowProceduralEat_D()
        {
            Game game = new Game();

            Button testButton = new Button();
            testButton.Location = new System.Drawing.Point { X = 150, Y = 100 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 150 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 250 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 50, Y = 200 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 50 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 150, Y = 100 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 200, Y = 250 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 250, Y = 200 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 50, Y = 0 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 50 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 250, Y = 200 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 300, Y = 150 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 250, Y = 100 };
            Button remember = testButton;
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 350, Y = 200 };
            game.DeleteEaten(testButton, remember);
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 150, Y = 300 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 200, Y = 250 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 150, Y = 100 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 200, Y = 150 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 50, Y = 200 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 150, Y = 100 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 50, Y = 0 };
            game.SwitchButtonToCheat(testButton);
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 250, Y = 200 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 50, Y = 100 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 0, Y = 150 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 50, Y = 300 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 100, Y = 250 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 200, Y = 50 };
            game.OnFigurePress(testButton, new System.EventArgs());


            testButton.Location = new System.Drawing.Point { X = 200, Y = 50 };
            game.OnFigurePress(testButton, new System.EventArgs());

            testButton.Location = new System.Drawing.Point { X = 150, Y = 100 };
            game.OnFigurePress(testButton, new System.EventArgs());

            game.pressedButton = testButton;
            game.ShowProceduralEat(2, 7);
            game.ShowProceduralEat(2, 3);

            testButton.Location = new System.Drawing.Point { X = 250, Y = 200 };
            game.OnFigurePress(testButton, new System.EventArgs());

            game.pressedButton = testButton;
            game.ShowProceduralEat(2, 7);
            game.ShowProceduralEat(2, 3);

            game.CloseSimpleSteps(game.simpleSteps);

            testButton.Location = new System.Drawing.Point { X = 50, Y = 00 };
            game.OnFigurePress(testButton, new System.EventArgs());

            Assert.IsTrue(game.currentPlayer == 2);
        }

        [TestMethod]
        public void TestMenu()
        {
            Checkers.MainMenu menu = new Checkers.MainMenu();

            Assert.IsTrue(1 == 1);
        }

        [TestMethod]
        public void TestRules()
        {
            Checkers.Rules rules = new Checkers.Rules();

            Assert.IsTrue(1 == 1);
        }
    }
}
