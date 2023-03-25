using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InvestingLibrary.Test
{
    [TestClass]
    public class TestCompoundProjection
    {
        [DataTestMethod]
        [DataRow(10000, 0.01, 1, 1, 10100)]
        [DataRow(10000, 0.01, 2, 1, 10201)]
        [DataRow(10000, 0.02, 2, 1, 10404)]
        public void TestProject(double captial, double rate, double numberOfTimePeriodsElapsed, double timesAppliedPerTimePeriod, double expected)
        {
            Assert.AreEqual(expected, CompoundProjection.ProjectFixedRate(captial, rate, numberOfTimePeriodsElapsed, timesAppliedPerTimePeriod));
        }

        [DataTestMethod]
        [DataRow(10000, 10100, 0.01)]
        [DataRow(10000, 10201, 0.01, 0.01)]
        public void TestProjectRates(double captial, double expected, params double[] rates)
        {
            Assert.AreEqual(expected, CompoundProjection.ProjectVariableRate(captial, rates.ToList()));
        }

        [TestMethod]
        public void TestProjectRatesVersusProject()
        {
            var capital = 10000;
            var rate = 0.1;
            var rates = new List<double>() {
                rate,
                rate,
                rate,
                rate,
                rate,
                rate,
                rate,
                rate,
                rate,
                rate,
                rate,
                rate,
                };

            Assert.AreEqual(CompoundProjection.ProjectFixedRate(capital, rate, 12, 1), CompoundProjection.ProjectVariableRate(capital, rates), 0.001);
        }

        [TestMethod]
        public void TestHouse()
        {
            var houseCapital = 240000;
            var houseRates = new List<double>()
            {
                -0.05,
                -0.05,
                -0.05,
                -0.05,
                -0.025,
                -0.025,
                -0.025,
                -0.025,
                0.025,
                0.025,
                0.025,
                0.025,
                0.05,
                0.05,
                0.05,
                0.05,
            };
            var houseValues = CompoundProjection.ProjectVariableRateReport(houseCapital, houseRates);
        }
    }
}