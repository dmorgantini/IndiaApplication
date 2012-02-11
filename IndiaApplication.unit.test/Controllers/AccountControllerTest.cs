using System.Threading;
using NUnit.Framework;
using FluentAssertions;

namespace IndiaApplication.unit.test.Controllers
{
    [TestFixture]
    public class AccountControllerTest
    {
         
        [TestCase(1,2,3)]
        [TestCase(2,2,4)]
        [TestCase(3,2,5)]
        [TestCase(4,2,6)]
        [TestCase(5,2,7)]
        [TestCase(6,2,8)]
        [TestCase(7,2,9)]
        [TestCase(8,2,10)]
        [TestCase(9,2,11)]
        [TestCase(10,2,12)]
        [TestCase(11,2,13)]
        [TestCase(12,2,14)]
        [TestCase(13,2,15)]
        [TestCase(14,2,16)]
        [TestCase(15,2,17)]
        [TestCase(16,2,18)]
        [TestCase(17,2,19)]
        [TestCase(18,2,20)]
        [TestCase(19,2,21)]
        [TestCase(20,2,22)]
        [TestCase(21,2,23)]
        [TestCase(22,2,24)]
        [TestCase(23,2,25)]
        [TestCase(24,2,26)]
        [TestCase(25,2,27)]
        [TestCase(26,2,28)]
        [TestCase(27,2,29)]
        [TestCase(28,2,30)]
        [TestCase(29,2,31)]
        [TestCase(30,2,32)]
        public void ShouldAddStuffProperly(int a, int b, int c)
        {
            Thread.Sleep(50);
            (a + b).Should().Be(c);
        }
    }
}