using Moq;
using SnakesAndLadders.Classes;
using SnakesAndLadders.Interfaces;
using Xunit;

namespace App.Tests
{
    public class UnitTest
    {
        private readonly Mock<IConsoleIO> consoleMock;
        private readonly int boardLength;

        public UnitTest()
        {
            this.consoleMock = new Mock<IConsoleIO>();
            this.boardLength = 100;
        }

        [Fact]
        [Trait("US1", "Token Can Move Across the Board")]
        public void UAT1_Given_GameStarted_When_TokenIsOnBoard_Then_TokenIsInPosition_1()
        {
            //Arrange
            var player = new Player(this.consoleMock.Object);

            //Assert
            Assert.Equal(1, player.TokenPosition);
        }

        [Fact]
        [Trait("US1", "Token Can Move Across the Board")]
        public void UAT2_Given_TokenIsInPosition1_When_TokenMove3_Then_TokenIsInPosition_4()
        {
            //Arrange
            var player = new Player(this.consoleMock.Object);

            //Act
            player.MoveTokenPosition(3, this.boardLength);

            //Assert
            Assert.Equal(4, player.TokenPosition);
        }

        [Fact]
        [Trait("US1", "Token Can Move Across the Board")]
        public void UAT3_Given_TokenIsInPosition1_When_TokenMove3AndTokenMove4_Then_TokenIsInPosition_8()
        {
            //Arrange
            var player = new Player(this.consoleMock.Object);

            //Act
            player.MoveTokenPosition(3, this.boardLength);
            player.MoveTokenPosition(4, this.boardLength);

            //Assert
            Assert.Equal(8, player.TokenPosition);
        }

        [Fact]
        [Trait("US2", "Player Can Win the Game")]
        public void UAT1_Given_TokenIsInPosition97_When_TokenMove3_Then_TokenIsInPosition_100_And_HasWinTheGame()
        {
            //Arrange
            var player = new Player(this.consoleMock.Object);

            //Act
            player.SetNewPosition(97);
            player.MoveTokenPosition(3, this.boardLength);

            //Assert
            Assert.Equal(boardLength, player.TokenPosition);
            Assert.True(player.HasWin);
        }

        [Fact]
        [Trait("US2", "Player Can Win the Game")]
        public void UAT2_Given_TokenIsInPosition97_When_TokenMove4_Then_TokenIsInPosition_97_And_HasNotWinTheGame()
        {
            //Arrange
            var player = new Player(this.consoleMock.Object);

            //Act
            player.SetNewPosition(97);
            player.MoveTokenPosition(4, this.boardLength);

            //Assert
            Assert.Equal(97, player.TokenPosition);
            Assert.False(player.HasWin);
        }

        [Fact]
        [Trait("US3", "Moves Are Determined By Dice Rolls")]
        public void UAT1_Given_GameIsStarted_When_PlayerRollDie_Then_ResultBetween1And6()
        {
            //Arrange
            var player = new Player(this.consoleMock.Object);

            //Act
            var dieResult = player.RollDice();

            //Assert
            Assert.InRange(dieResult, 1, 6);
        }

        [Fact]
        [Trait("US3", "Moves Are Determined By Dice Rolls")]
        public void UAT2_Given_PlayerRoll4_When_MoveTheirToken_Then_TokenShouldMove4()
        {
            //Arrange
            var player = new Player(this.consoleMock.Object);
            var initialPosition = player.TokenPosition;
            var dieResult = 4;

            //Act
            player.MoveTokenPosition(dieResult, this.boardLength);

            //Assert
            Assert.Equal(dieResult, player.TokenPosition - initialPosition);
        }
    }
}