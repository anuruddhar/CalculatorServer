//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Calculator.XUnitTests {
//    class BaseTests {
//    }
//}

#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Abacus Online Calculator
   Client      -   Abacus          
   Module      -   Test
   Sub_Module  -   
   Copyright   -   Anuruddha.Rajapaksha   

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
09/11/2021         	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Calculator.Test;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
#endregion	  


namespace Calculator.XUnitTests {
    public abstract class BaseTests {

        protected string baseUrl = string.Empty;
        protected HttpClient client;
        private string controllerName;
        protected JsonSerializerSettings serializerSettings;

        public BaseTests(string _controllerName) {
            controllerName = _controllerName;
            baseUrl = $"{TestData.BaseUrl}/{controllerName}";

            serializerSettings = new JsonSerializerSettings {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                DateTimeZoneHandling = DateTimeZoneHandling.Utc,
                NullValueHandling = NullValueHandling.Ignore
            };
            serializerSettings.Converters.Add(new StringEnumConverter());


            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        /*
        [SetUp]
        public void BeforeEachTest() {
            Console.WriteLine($"Before {TestContext.CurrentContext.Test.Name}");
        }

        [TearDown]
        public void AfterEachTest() {
            Console.WriteLine($"After {TestContext.CurrentContext.Test.Name}");
        }

        #region Fixture
        [OneTimeSetUp]
        public void BeforeAnyTestStarted() {
            Console.WriteLine($"*** Before {controllerName} Integration Tests ***");

            client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", TestData.BearerToken);
        }

        [OneTimeTearDown]
        public void AfterAllTestsFinished() {
            Console.WriteLine($"*** After {controllerName}  Integration Tests ***");
        }
        #endregion
        */
    }
}

