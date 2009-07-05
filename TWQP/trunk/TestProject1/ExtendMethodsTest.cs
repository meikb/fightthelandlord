using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestProject1
{
    
    
    /// <summary>
    ///这是 ExtendMethodsTest 的测试类，旨在
    ///包含所有 ExtendMethodsTest 单元测试
    ///</summary>
    [TestClass()]
    public class ExtendMethodsTest
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
        ///Remove 的测试
        ///</summary>
        [TestMethod()]
        public void RemoveTest()
        {
            牌[] 一组牌 = new 牌[] {
            // 黑
            new 牌 { 数据 = 0x010101u },   // A
            new 牌 { 数据 = 0x010102u }, 
            new 牌 { 数据 = 0x010103u }, 
            new 牌 { 数据 = 0x010104u }, 
            new 牌 { 数据 = 0x010105u }, 
            new 牌 { 数据 = 0x010106u }, 
            new 牌 { 数据 = 0x010107u }, 
            new 牌 { 数据 = 0x010108u }, 
            new 牌 { 数据 = 0x010109u }, 
            new 牌 { 数据 = 0x01010Au },   // 10
            new 牌 { 数据 = 0x01010Bu },   // J
            new 牌 { 数据 = 0x01010Cu },   // Q
            new 牌 { 数据 = 0x01010Du },   // K
        };
            牌[] 另一组牌 = new 牌[] {
            // 黑
            new 牌 { 数据 = 0x010101u },   // A
            new 牌 { 数据 = 0x010102u }, 
            new 牌 { 数据 = 0x010103u }, 
            new 牌 { 数据 = 0x010104u }, 
            new 牌 { 数据 = 0x010105u }, 
            new 牌 { 数据 = 0x010106u }, 
            new 牌 { 数据 = 0x010107u }, 
            new 牌 { 数据 = 0x010108u }, 
            new 牌 { 数据 = 0x010109u },
        };
            牌[] 结果 = new 牌[] {
            // 黑
            new 牌 { 数据 = 0x01010Au },   // 10
            new 牌 { 数据 = 0x01010Bu },   // J
            new 牌 { 数据 = 0x01010Cu },   // Q
            new 牌 { 数据 = 0x01010Du },   // K
        };
            


            牌[] Source = 一组牌; // TODO: 初始化为适当的值
            牌[] Target = 另一组牌; // TODO: 初始化为适当的值
            牌[] expected = 结果; // TODO: 初始化为适当的值
            牌[] actual;
            actual = ExtendMethods.Remove(Source, Target);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("验证此测试方法的正确性。");
        }
    }
}
