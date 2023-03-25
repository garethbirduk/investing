using System.Runtime.ConstrainedExecution;

namespace InvestingLibrary
{
    public class CompoundProjection
    {
        public static double ProjectFixedRate(double captial, double rate, double numberOfTimePeriodsElapsed, double timesAppliedPerTimePeriod)
        {
            var r = rate;
            var n = timesAppliedPerTimePeriod;
            var t = numberOfTimePeriodsElapsed;
            var P = captial;

            return P * Math.Pow(1 + r / n, n * t);
        }

        public static double ProjectVariableRate(double capital, List<double> rates)
        {
            foreach (var rate in rates)
                capital += capital * rate;
            return capital;
        }

        public static List<double> ProjectVariableRateReport(double capital, List<double> rates, int dp = 0)
        {
            var report = new List<double>()
            {
                capital
            };

            foreach (var rate in rates)
            {
                capital += capital * rate;
                report.Add(capital);
            }
            return report.Select(x => Math.Round(x)).ToList();
        }
    }
}