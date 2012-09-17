﻿using RPNCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestTester
{
    
    
    /// <summary>
    ///This is a test class for CalculatorTest and is intended
    ///to contain all CalculatorTest Unit Tests
    ///</summary>
	[TestClass()]
	public class CalculatorTest {


		private TestContext testContextInstance;

		/// <summary>
		///Gets or sets the test context which provides
		///information about and functionality for the current test run.
		///</summary>
		public TestContext TestContext {
			get {
				return testContextInstance;
			}
			set {
				testContextInstance = value;
			}
		}

		#region Additional test attributes
		// 
		//You can use the following additional attributes as you write your tests:
		//
		//Use ClassInitialize to run code before running the first test in the class
		//[ClassInitialize()]
		//public static void MyClassInitialize(TestContext testContext)
		//{
		//}
		//
		//Use ClassCleanup to run code after all tests in a class have run
		//[ClassCleanup()]
		//public static void MyClassCleanup()
		//{
		//}
		//
		//Use TestInitialize to run code before running each test
		//[TestInitialize()]
		//public void MyTestInitialize()
		//{
		//}
		//
		//Use TestCleanup to run code after each test has run
		//[TestCleanup()]
		//public void MyTestCleanup()
		//{
		//}
		//
		#endregion


		/// <summary>
		///A test for Evaluate
		///</summary>
		[TestMethod()]
		[ExpectedException(typeof(ArgumentException))]
		public void EvaluateTest() {
			string exp;
			int returned;
			int expected;
			//exp = "";
			//returned = Calculator.Evaluate(exp);
			//exp = "2";
			//returned = Calculator.Evaluate(exp);
			exp = "+";
			returned = Calculator.Evaluate(exp);
			//exp = "2+2";
			//returned = Calculator.Evaluate(exp);
			//exp = "2 +";
			//returned = Calculator.Evaluate(exp);
			//exp = "+ 2";
			//returned = Calculator.Evaluate(exp);
			exp = "2 2 +";
			returned = Calculator.Evaluate(exp);
			expected = 2 + 2;
			Assert.AreEqual(expected, returned);
		}

		/// <summary>
		///A test for Calculator Constructor
		///</summary>
		[TestMethod()]
		public void CalculatorConstructorTest() {
			Calculator target = new Calculator();
			Assert.IsTrue(true);
		}
	}
}
