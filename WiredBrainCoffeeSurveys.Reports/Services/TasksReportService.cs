using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WiredBrainCoffeeSurveys.Reports.Services
{
    public static class TasksReportService
    {
        public static void GenerateTasksReport(SurveyResults results)
        {
            var tasks = new List<string>();

            // Calculated Values
            double responseRate = results.NumberResponded / results.NumberSurveyed; // Expression statements to calculate and assign values to declared variables; // Declared variables
            double overallScore = (results.ServiceScore + results.CoffeeScore + results.FoodScore + results.PriceScore) / 4;

            if (results.CoffeeScore < results.FoodScore)
            {
                tasks.Add("Investigate coffee recipes and ingredients.");
            }

            tasks.Add(overallScore > 8.0 ? "Work with leadership to reward staff." : "Work with employees for improvement ideas.");

            //if (overallScore > 8.0)
            //{
            //    tasks.Add("Work with leadership to reward staff");
            //}
            //else
            //{
            //    tasks.Add("Work with employees for improvement ideas.");
            //}

            tasks.Add(responseRate switch
            {
                var rate when rate < .33 => "Research options to improve response rate.",
                var rate when rate > .33 && rate < .66 => "Reward participants with free coffee coupon.",
                var rate when rate > .66 => "Rewards participants with discount coffee coupon."
            });

            //if (responseRate < .33)
            //{
            //    tasks.Add("Research options to improve response rate.");
            //}
            //else if (responseRate > .33 && responseRate < .66)
            //{
            //    tasks.Add("Reward participants with free coffee coupon.");
            //}
            //else
            //{
            //    tasks.Add("Rewards participants with discount coffee coupon.");
            //}

            // switch expression syntax with lambda expressions
            tasks.Add(results.AreaToImprove switch
            {
                "RewardsProgram" => "Revisit the rewards deals.",
                "Cleanliness" => "Contact the cleaning vendor.",
                "MobileApp" => "Contact consulting firm about app.",
                _ => "Investigate individual comments for ideas." // c# _discard syntax to act as defualt case
            });

            //switch (results.AreaToImprove)
            //{
            //    case "RewardsProgram":
            //        tasks.Add("Revisit the rewards deals.");
            //        break;

            //    case "Cleanliness":
            //        tasks.Add("Contact the cleaning vendor.");
            //        break;

            //    case "MobileApp":
            //        tasks.Add("Contact consulting firm about app.");
            //        break;
            //    default:
            //        tasks.Add("Investigate individual comments for ideas.");
            //        break;

            //}

            Console.WriteLine(Environment.NewLine + "Tasks Output:");
            foreach (var task in tasks)
            {
                Console.WriteLine(task);
            }

            File.WriteAllLines("TasksReport.csv", tasks);
        }
    }
}
