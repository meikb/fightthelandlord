﻿using FightTheLandLord;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///这是 DConsoleTest 的测试类，旨在
    ///包含所有 DConsoleTest 单元测试
    ///</summary>
    [TestClass()]
    public class DConsoleTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试属性
        // 
        //编写测试时，还可使用以下属性:
        //
        //使用 ClassInitialize 在运行类中的第一个测试前先运行代码
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //使用 ClassCleanup 在运行完类中的所有测试后再运行代码
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //使用 TestInitialize 在运行每个测试前先运行代码
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //使用 TestCleanup 在运行完每个测试后运行代码
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///SameSort 的测试
        ///</summary>
        [TestMethod()]
        public void SameSortTest()
        {
            PokerGroup PG = new PokerGroup(); // TODO: 初始化为适当的值
            PG.Add(new Poker(PokerNum.P10, PokerColor.黑桃));
            PG.Add(new Poker(PokerNum.P10, PokerColor.黑桃));
            PG.Add(new Poker(PokerNum.P9, PokerColor.红心));
            PG.Add(new Poker(PokerNum.P9, PokerColor.黑桃));
            PG.Add(new Poker(PokerNum.P9, PokerColor.黑桃));
            PG.Add(new Poker(PokerNum.P5, PokerColor.方块));
            PG.Add(new Poker(PokerNum.P5, PokerColor.黑桃));
            PG.Add(new Poker(PokerNum.P5, PokerColor.红心));
            //PG.Add(new Poker(PokerNum.P4, PokerColor.方块));
            //PG.Add(new Poker(PokerNum.P4, PokerColor.黑桃));
            //PG.Add(new Poker(PokerNum.P4, PokerColor.红心));
            //PG.Add(new Poker(PokerNum.P3, PokerColor.方块));
            //PG.Add(new Poker(PokerNum.P3, PokerColor.黑桃));
            //PG.Add(new Poker(PokerNum.P3, PokerColor.红心));

            PokerGroup expected = null; // TODO: 初始化为适当的值
            PokerGroup actual;
            actual = DConsole.SameThreeSort(PG);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }

        /// <summary>
        ///IsThreeLinkPokers 的测试
        ///</summary>
        [TestMethod()]
        public void IsThreeLinkPokersTest()
        {
            PokerGroup PG = new PokerGroup(); // TODO: 初始化为适当的值
            PG.Add(new Poker(PokerNum.P2, PokerColor.红心));
            PG.Add(new Poker(PokerNum.P3, PokerColor.黑桃));
            PG.Add(new Poker(PokerNum.P3, PokerColor.黑桃));
            PG.Add(new Poker(PokerNum.P3, PokerColor.方块));
            bool expected = true; // TODO: 初始化为适当的值
            bool actual;
            actual = DConsole.IsThreeLinkPokers(PG);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
