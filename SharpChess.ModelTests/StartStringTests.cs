using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpChess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpChess.Model.Tests
{
    [TestClass()]
    public class StartStringTests
    {
        [TestMethod()]
        public void GenerateStartStringTest()
        {
            StartString test = new StartString();

            Assert.IsNotNull(test.GenerateStartString());
        }

        [TestMethod()]
        public void CheckDictionary()
        {
            StartString test = new StartString();
            test.GenerateStartString();

            Assert.IsFalse(test.spaces.ContainsValue('W'));
            Assert.IsFalse(test.spaces.ContainsValue('B'));
        }

        [TestMethod()]
        public void ContainsPieces()
        {
            StartString test = new StartString();
            string store = test.GenerateStartString();

            Assert.IsTrue(store.Contains('k'));
            Assert.IsTrue(store.Contains('r'));
            Assert.IsTrue(store.Contains('b'));
            Assert.IsTrue(store.Contains('q'));
            Assert.IsTrue(store.Contains('n'));
        }



        [TestMethod()]
        public void CreateStringTest()
        {
            StartString test = new StartString();
            Assert.IsNotNull(test.CreateString("A"));
        }

        [TestMethod()]
        public void SpecificBoardTest()
        {
            StartString test = new StartString();
            string testBoardRow = "rkrbbnnq";

            Assert.AreEqual("rkrbbnnq/pppppppp/8/8/8/8/PPPPPPPP/RKRBBNNQ w KQkq - 0 1", test.CreateString(testBoardRow));
        }
    }
}