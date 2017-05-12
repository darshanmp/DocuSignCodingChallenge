using Microsoft.VisualStudio.TestTools.UnitTesting;
using DocuSign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DocuSign.Tests
{
    [TestClass()]
    public class PajamasProblemTests
    {
        [TestMethod()]
        public void AcceptUserInputTest1()
        {
            PajamasProblem prob = new PajamasProblem();
            string input = "HOT 8, 6, 4, 2, 1, 7";
            string expOuptut = "Removing PJs, shorts, t-shirt, sun visor, sandals, leaving house";
            bool doExit = false;
            Assert.AreEqual(prob.AcceptUserInput(input, ref doExit), expOuptut);
        }

        [TestMethod()]
        public void AcceptUserInputTest2()
        {
            PajamasProblem prob = new PajamasProblem();
            string input = "COLD 8, 6, 3, 4, 2, 5, 1, 7";
            string expOuptut = "Removing PJs, pants, socks, shirt, hat, jacket, boots, leaving house";
            bool doExit = false;
            Assert.AreEqual(prob.AcceptUserInput(input, ref doExit), expOuptut);
        }

        [TestMethod()]
        public void AcceptUserInputTest3()
        {
            PajamasProblem prob = new PajamasProblem();
            string input = "HOT 8, 6, 6";
            string expOuptut = "Removing PJs, shorts, fail";
            bool doExit = false;
            Assert.AreEqual(prob.AcceptUserInput(input, ref doExit), expOuptut);
        }

        [TestMethod()]
        public void AcceptUserInputTest4()
        {
            PajamasProblem prob = new PajamasProblem();
            string input = "HOT 8, 6, 3";
            string expOuptut = "Removing PJs, shorts, fail";
            bool doExit = false;
            Assert.AreEqual(prob.AcceptUserInput(input, ref doExit), expOuptut);
        }

        [TestMethod()]
        public void AcceptUserInputTest5()
        {
            PajamasProblem prob = new PajamasProblem();
            string input = "COLD 8, 6, 3, 4, 2, 5, 7";
            string expOuptut = "Removing PJs, pants, socks, shirt, hat, jacket, fail";
            bool doExit = false;
            Assert.AreEqual(prob.AcceptUserInput(input, ref doExit), expOuptut);
        }

        [TestMethod()]
        public void AcceptUserInputTest6()
        {
            PajamasProblem prob = new PajamasProblem();
            string input = "COLD 6";
            string expOuptut = "fail";
            bool doExit = false;
            Assert.AreEqual(prob.AcceptUserInput(input, ref doExit), expOuptut);
        }

        [TestMethod()]
        public void AcceptUserInputTest7()
        {
            PajamasProblem prob = new PajamasProblem();
            string input = "HOT 8, 6, 4, 2, 1, 5, 7";
            string expOuptut = "Removing PJs, shorts, t-shirt, sun visor, sandals, fail";
            bool doExit = true;
            Assert.AreEqual(prob.AcceptUserInput(input, ref doExit), expOuptut);
        }

    }
}