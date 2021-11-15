#region Modification Log
/*------------------------------------------------------------------------------------------------------------------------------------------------- 
   System      -   Online Calculator       
   Module      -   Api
   Sub_Module  -   
   Copyright   -   Anuruddha.Rajapaksha   

Modification History:
==================================================================================================================================================
Date              Version      		Modify by              					Description
--------------------------------------------------------------------------------------------------------------------------------------------------
09/11/2021        	  1.0         Anuruddha.Rajapaksha   					Initial Version
--------------------------------------------------------------------------------------------------------------------------------------------------*/
#endregion

#region Namespace
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
#endregion	  

namespace Calculator.Controllers {

    [ApiController]
    [Route("api/calculator")]
    [Produces("application/json")]
    public class CalculatorController : ControllerBase {

        [HttpGet()]
        public IActionResult Welcome() {
            return Ok("Hello Calculator");
        }

        /// <summary>
        /// Take two or more paramters and returns the sum of all the numbers. 
        /// Please refer below examples
        /// Eg:-
        ///     1. http://localhost:51844/api/calculator/add?param1=5&param2=2&param3=3&param4=5&param5=3
        ///     2. http://localhost:51844/api/calculator/add?param1=4.333&param2=2&param3=5.4
        /// </summary>
        /// <returns>sum of all the parameters</returns>
        [HttpGet("add")]
        public IActionResult Add() {
            decimal result = 0;
            int i = 1;
            foreach (var key in HttpContext.Request.Query) {
                var value = HttpContext.Request.Query[$"param{i}"];
                result +=  Convert.ToDecimal(value);
                i++;
            }
            return Ok(result);
        }

        /// <summary>
        /// Take two or more paramters and returns the subtraction of numbers. 
        /// Please refer below examples
        /// Eg:-
        ///     1. http://localhost:51844/api/calculator/subtract?param1=25&param2=2&param3=3&param4=5&param5=3
        /// </summary>
        /// <returns>subtraction of all the parameters</returns>
        [HttpGet("subtract")]
        public IActionResult Subtract() {
            decimal result = 0;
            int i = 1;
            foreach (var key in HttpContext.Request.Query) {
                var value = HttpContext.Request.Query[$"param{i}"];
                if (i == 1) {
                    result = Convert.ToDecimal(value);
                } else {
                    result -= Convert.ToDecimal(value);
                }
                i++;
            }
            return Ok(result);
        }

        /// <summary>
        /// Take two or more paramters and returns the multiplication. 
        /// Please refer below examples
        /// Eg:-
        ///     1. http://localhost:51844/api/calculator/multiply?param1=2&param2=4&param3=3&param4=5
        /// </summary>
        /// <returns>multiplication of all the parameters</returns>
        [HttpGet("multiply")]
        public IActionResult Multiply() {
            decimal result = 1;
            int i = 1;
            foreach (var key in HttpContext.Request.Query) {
                var value = HttpContext.Request.Query[$"param{i}"];
                result *= Convert.ToDecimal(value);
                i++;
            }
            return Ok(result);
        }

        /// <summary>
        /// Take two paramters and returns the division. 
        /// Please refer below examples
        /// Eg:-
        ///     1. http://localhost:51844/api/calculator/divide/16/4
        ///     2. Faile case (Error) -> http://localhost:51844/api/calculator/divide/16/0
        /// </summary>
        /// <returns>division of the parameters</returns>
        [HttpGet("divide/{param1}/{param2}")]
        public IActionResult Divide([FromRoute] decimal param1, [FromRoute] decimal param2) {
            decimal result = param1/ param2;
            return Ok(result);
        }

        /// <summary>
        /// Take two paramters and returns split of param1, param2 times. 
        /// Please refer below examples
        /// Eg:-
        ///     1. http://localhost:51844/api/calculator/splitEq/120/4
        ///     1. http://localhost:51844/api/calculator/splitEq/122/4
        /// </summary>
        /// <returns>split of param1, param2 times</returns>
        [HttpGet("splitEq/{param1}/{param2}")]
        public IActionResult SplitEq([FromRoute] decimal param1, [FromRoute] decimal param2) {
            List<decimal> result = new List<decimal>();
            var remainder = param1 % param2;
            for (int i = 0; i < param2; i++) {
                result.Add(Math.Floor(param1 / param2));
            }
            if (remainder != 0) {
                result.Add(remainder);
            } 
            return Ok(result);
        }


        /// <summary>
        /// Take two or more paramters and returns the remainder. 
        /// Please refer below examples
        /// Eg:-
        ///     1. http://localhost:51844/api/calculator/splitNum?param1=140&param2=45&param3=35&param4=20
        /// </summary>
        /// <returns>remainder of all the parameters</returns>
        [HttpGet("splitNum")]
        public IActionResult SplitNum() {
            decimal result = 0;
            decimal firstValue = 0;
            decimal secondValue = 0;

            int i = 1;
            foreach (var key in HttpContext.Request.Query) {
                var value = HttpContext.Request.Query[$"param{i}"];
                if (i == 1) {
                    firstValue = Convert.ToDecimal(value);
                } else {
                    secondValue += Convert.ToDecimal(value);
                }
                i++;
            }
            result = firstValue % secondValue;
            return Ok(result);
        }

    }



}
