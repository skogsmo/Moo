using Moo;
using NUnit.Framework;

namespace MooGameTest
{
    [TestFixture]
    public class MooTest
    {

        [Test]
        public void Generate_Target_LessThanFour()
        {
            var target = Game.GenerateTarget();

            Assert.That(target.Length, Is.EqualTo(3));
        }

        [Test]
        public void Generate_Target_GreaterThanFour()
        {
            var target = Game.GenerateTarget();

            Assert.That(target.Length, Is.EqualTo(5));
        }

        [Test]
        public void Generate_Target_ExpectedBehavior()
        {
            var target = Game.GenerateTarget();

            Assert.That(target.Length, Is.EqualTo(4));
        }

        [Test]
        public void BullsAndCows_Success() 
        {
            var target = "abcd";
            string playerGuess = "abcd";
            var sut = Game.CheckBullsAndCows(target, playerGuess);

            Assert.That(sut, Is.EquivalentTo("BBBB,"));
        }

        [Test]
        public void BullsAndCows_Fail()
        {
            var target = "abcd";
            string playerGuess = "dcba";
            var sut = Game.CheckBullsAndCows(target, playerGuess);

            Assert.That(sut, Is.EquivalentTo("CCCB,"));
        }

        [Test]
        public void BullsAndCows_Expect_2Rights()
        {
            var target = "abcd";
            string playerGuess = "asod";
            var sut = Game.CheckBullsAndCows(target, playerGuess);

            Assert.That(sut, Is.EquivalentTo("BB,"));
        }
    }
}