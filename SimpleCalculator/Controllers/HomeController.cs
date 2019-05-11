using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace SimpleCalculator.Controllers
{
    public class HomeController : Controller
    {
        String warning = "";
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string numbers)
        {
            ViewBag.Result = Addition(numbers);
            ViewBag.Message = warning;
            return View();
        }

        public int Addition(String numbers)
        {
            int sum = 0;
            int[] intArray;
            List<int> negNum;
            String msg = "Negative number(s) not allowed: ";
            Regex reg = new Regex(@"^\/\/");
            try
            {
                //validating input box
                if (String.IsNullOrEmpty(numbers))
                {
                    return sum;
                }
                //verifying string starting patter - //
                else if (reg.Match(numbers).Success)
                {
                    //delimiters of arbitrary length
                    int delimiterLength = numbers.IndexOf("\\n") - 2;
                    //delimiter String
                    String delimiterString = numbers.Substring(2, delimiterLength);
                    //String[] delemitersList = delimiterString.Split(',').ToArray();
                    //var newList = String.Join("\",\"", delemitersList);
                    
                    //numbers array 
                    intArray = numbers.Substring(numbers.IndexOf("\\n") + 2).Replace("\\n", "").Split(
                         new[] { delimiterString }, StringSplitOptions.None).Select(int.Parse).ToArray();

                }
                else
                {
                    //parsing numbers having \n
                    intArray = numbers.Replace("\\n", "").Split(',').Select(int.Parse).ToArray();

                }
                //checking negative numbers
                negNum = NegativeNumbers(intArray);
                if (negNum.Capacity == 0 )
                {
                    sum = Result(intArray);
                }
                else
                {
                    foreach (int t in negNum)
                    {
                        if (t < 0)
                        {
                            msg += t;
                        }

                    }
                    warning = msg;
                }
            }
            catch (Exception ex)
            {
                warning = "Something went wrong!!";
            }
            return sum;
       
        }

        public int Result(int[] Array)
        {
            int addition = 0;
            foreach (int num in Array)
            {
                if (num <= 1000)
                {
                    addition += num;
                }

            }
            return addition;
        }

        public List<int> NegativeNumbers(int[] Array)
        {
            List<int> negativeNumberList = new List<int>();
            for(int x=0; x<Array.Length; x++)
            {
                if (Array[x] < 0)
                {
                    negativeNumberList.Add(Array[x]);
                }

            }
            return negativeNumberList;
        }
    }
}