using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCalculator;
using SimpleCalculator.Controllers;

namespace SimpleCalculator.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {

        HomeController controller = new HomeController();

        [TestMethod]
        public void SimpleAddition()
        {
            // Arrange
            
            int ExpectedResult = 8;
            // Act
            int ActualResult = controller.Addition("1,2,5");

            // Assert
            Assert.AreEqual(ExpectedResult,ActualResult);
        }

        [TestMethod]
        public void AdditionWithNewLine()
        {
            // Arrange

            int ExpectedResult = 6;
            // Act
            int ActualResult = controller.Addition("1\n,2,3");

            // Assert
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        public void AdditionWithNumbersLessThan1000()
        {
            // Arrange

            int ExpectedResult = 2;
            // Act
            int ActualResult = controller.Addition("2,1001");

            // Assert
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

        [TestMethod]
        public void AdditionWithNegativeNumber()
        {
            // Arrange

            int ExpectedResult = 0;
            // Act
            int ActualResult = controller.Addition("2,4,6-7");

            // Assert
            Assert.AreEqual(ExpectedResult, ActualResult);
        }

       


    }
}
