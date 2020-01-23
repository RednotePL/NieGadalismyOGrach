using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FunctionLibrary;
using System.Collections.Generic;
using System.Linq;
using NieGadalismyOGrach;

namespace Tests
{
	[TestClass]
	public class UnitTest1
	{
		[TestMethod]
		public void TestMethod1()
		{
			List<int> testList1 = new List<int>()
			{
				1, 2, 3, 4, 5, 6
			};
			List<int> testList2 = testList1.ToArray().ToList();
			testList2.Shuffle();

			Assert.AreNotEqual(testList1, testList2);
		}

		[TestMethod]
		public void TestMethod2()
		{
			List<int> testList1 = new List<int>()
			{
				1, 2, 3, 4, 5, 6
			};
			List<int> testList2 = testList1.ToArray().ToList();

			testList2.Shuffle();
			testList1.Shuffle();

			Assert.AreNotEqual(testList1, testList2);
		}
	}
}
