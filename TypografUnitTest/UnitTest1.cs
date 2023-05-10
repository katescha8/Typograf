using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Typograf;

namespace TypografUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void OnlyOneWhiteSpace()
        {
            var t = new Form1();
            string s = "a  b";
            string result = t.WhiteSpace(s);
            Assert.AreEqual("a b", result);
        }
        [TestMethod]
        public void Meth1()
        {
            var t = new Form1();
            string s = "a,b";
            string result = t.Punctuation(s);
            Assert.AreEqual("a, b", result);
        }
        [TestMethod]
        public void Meth2()
        {
            var t = new Form1();
            string s = "a ,b";
            string result = t.Punctuation(s);
            Assert.AreEqual("a, b", result);
        }
        [TestMethod]
        public void Meth3()
        {
            var t = new Form1();
            string s = "a , b";
            string result = t.Punctuation(s);
            result = t.WhiteSpace(result);
            Assert.AreEqual("a, b", result);
        }
        [TestMethod]
        public void Meth4()
        {
            var t = new Form1();
            string s = "a ( b)";
            string result = t.Punctuation(s);
            result = t.WhiteSpace(result);
            Assert.AreEqual("a (b) ", result);
        }
        [TestMethod]
        public void Meth5()
        {
            var t = new Form1();
            string s = "a(b)";
            string result = t.Punctuation(s);
            Assert.AreEqual("a (b) ", result);
        }
        [TestMethod]
        public void Meth6()
        {
            var t = new Form1();
            string s = "a(b)c";
            string result = t.Punctuation(s);
            Assert.AreEqual("a (b) c", result);
        }
        [TestMethod]
        public void Meth7()
        {
            var t = new Form1();
            string s = "a—b";
            string result = t.Punctuation(s);
            Assert.AreEqual("a — b", result);
        }
        [TestMethod]
        public void YUXTest1()
        {
            var t = new Form1();
            string s = "х";
            string result = t.YUX(s);
            Assert.AreEqual("х", result);
        }
        [TestMethod]
        public void YUXTest2()
        {
            var t = new Form1();
            string s = " х";
            string result = t.YUX(s);
            Assert.AreEqual(" йух", result);
        }
        [TestMethod]
        public void RussiaTest()
        {
            var t = new Form1();
            string s = "рашка";
            string result = t.Russia(s);
            Assert.AreEqual("Великая Россия", result);
        }
        [TestMethod]
        public void PlusMinusTest1()
        {
            var t = new Form1();
            string s = "(+,−)";
            string result = t.PlusMinus(s);
            Assert.AreEqual("±", result);
        }
        [TestMethod]
        public void PlusMinusTest2()
        {
            var t = new Form1();
            string s = "(+b−)";
            string result = t.PlusMinus(s);
            Assert.AreEqual("(+b−)", result);
        }
        [TestMethod]
        public void Tech()
        { 
            var t = new Form1();
            string s = "100 B";
            string result = t.TechnicalSpecs(s);
            Assert.AreEqual("100 B", result);
        }
        [TestMethod]
        public void Num()
        {
            var t = new Form1();
            string s = "100";
            bool result = t.IsNumeric(s);
            Assert.AreEqual(true, result);
        }
    }
}
