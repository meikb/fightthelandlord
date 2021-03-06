﻿using FightTheLandLord;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///这是 PokerGroupTest 的测试类，旨在
    ///包含所有 PokerGroupTest 单元测试
    ///</summary>
    [TestClass()]
    public class PokerGroupTest
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
        ///GetBuffer 的测试
        ///</summary>
        [TestMethod()]
        public void GetBufferTest()
        {
            PokerGroup target = new PokerGroup(); // TODO: 初始化为适当的值
            target.Add(new Poker(PokerNum.大王, PokerColor.红心));
            target.Add(new Poker(PokerNum.P7, PokerColor.黑桃));
            target.Add(new Poker(PokerNum.P3, PokerColor.梅花));
            target.Add(new Poker(PokerNum.K, PokerColor.方块));
            target.Add(new Poker(PokerNum.A, PokerColor.红心));
            target.Add(new Poker(PokerNum.P4, PokerColor.黑桃));
            target.Add(new Poker(PokerNum.P7, PokerColor.红心));
            target.Add(new Poker(PokerNum.P9, PokerColor.红心));
            byte[] expected = null; // TODO: 初始化为适当的值
            byte[] actual;
            actual = target.GetBuffer();
            string str = Encoding.Default.GetString(actual);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
