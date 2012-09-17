using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RPNCalculator {
	/// <summary>
	/// RPN (Reverse Polish Notation) calculator.
	/// RPN notation, also known as post-fix notation,
	/// puts the operator (+, -, *, /) after the operands.
	/// 
	/// See:  en.wikipedia.org/wiki/Reverse_Polish_notation
	/// 
	/// Author: Tony Tuttle
	/// September 16, 2012
	/// </summary>
	public class Calculator {
		/// <summary>
		/// This method evaluates an RPN (post-fix) expression and
		/// returns the result.  Since the order that the operands
		/// and the operators are entered determines the order of 
		/// execution, no parentheses are required.
		/// </summary>
		/// <param name="exp">
		/// The expression to be evaluated.  The string may contain
		/// positive integers and operation symbols (+, -, *, /).
		/// Any other characters inside of the expression will throw
		/// an ArgumentException.
		/// The elements of the expression MUST be separated by at
		/// least one space.  e.g. "2 + 2" is valid, but "2+2" is NOT.
		/// </param>
		/// <returns>
		/// The integer result of the expression.
		/// </returns>
		public static int Evaluate(string exp) {
			// create an array of tokens
			string[] tokens = Regex.Split(exp, " ");
			// trim the elements
			foreach(var toke in tokens)
				toke.Trim();
			// stack to hold the number values
			Stack<Int32> nums = new Stack<Int32>();
			foreach(var toke in tokens) {
				// check for operators
				if(toke == "+") {
					// check that stack contains >= two numbers
					if(nums.Count() < 2)
						throw new ArgumentException("Need two numbers to add.");
					// push the sum back to the stack
					int rightOp = nums.Pop();
					int leftOp = nums.Pop();
					nums.Push(leftOp + rightOp);
				}
				else if(toke == "-") {
					// check there are enough nums in the stack
					if(nums.Count() < 2)
						throw new ArgumentException("Need two numbers to subtract.");
					// push the difference to the stack
					int rightOp = nums.Pop();
					int leftOp = nums.Pop();
					nums.Push(leftOp - rightOp);
				}
				else if(toke == "*") {
					// check the stack
					if(nums.Count() < 2)
						throw new ArgumentException("Need two numbers to multiply.");
					// push the product
					int rightOp = nums.Pop();
					int leftOp = nums.Pop();
					nums.Push(leftOp * rightOp);
				}
				else if(toke == "/") {
					//check the stack
					if(nums.Count() < 2)
						throw new ArgumentException("Need two numbers to divide.");
					// push the quotient
					int rightOp = nums.Pop();
					if(rightOp == 0)
						throw new ArgumentException("Cannot divide by zero.");
					int leftOp = nums.Pop();
					nums.Push(leftOp / rightOp);
				}
				else if(toke == "") {
					// ignore empty strings
				}
				// we must be dealing with a number or an invalid character
				else {
					try {
						int isInt = Convert.ToInt32(toke);
						nums.Push(isInt);
					}
					catch {
						throw new ArgumentException("Invalid character(s) in the expression.");
					}
				}
			}
			if(nums.Count() != 1)
				throw new ArgumentException("There are too many or too few numbers in the expression.");
			return nums.Pop();
		}
	}
}
