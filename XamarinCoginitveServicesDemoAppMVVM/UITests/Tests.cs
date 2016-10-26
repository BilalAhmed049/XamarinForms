using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamarinCoginitveServicesDemoApp.UITests
{
	//Set this attribute to indicate which platforms you would like to test:
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public class Tests
	{
		//IApp interface is responsible for communication with the app (like clicking buttons or typing in text fields);
		IApp app;
		//Platform parameter - indicates on which platform Xamarin shoudl launch tests:
		Platform platform;

		//This is constructor for the test with setting the platform:
		public Tests(Platform platform)
		{
			this.platform = platform;
		}

		//This is setup before test is launched - below app object is initialized to enable tests:
		[SetUp]
		public void BeforeEachTest()
		{
			app = AppInitializer.StartApp(platform);
		}

		//In this method REPL console in invoked (with REPL we are able to test our app and see the result in console,
		// we can also test our app manually and all actions will be displayed on the console:
		[Test]
		public void TestMethod()
		{
			//app.Repl();
			AppResult[] results = app.WaitForElement(c => c.Marked("TakePictureButton"));
			Assert.IsTrue(results.Any());
		}
	}
}
