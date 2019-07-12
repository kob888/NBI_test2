using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_2_NBI
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Interval> dates = new List<Interval>()
            {
                new Interval{ Start = new DateTime(2017, 9, 1), End = new DateTime(2020, 12, 10)},
                new Interval{ Start = new DateTime(2017, 8, 3), End = new DateTime(2019, 1, 9)},
                new Interval{ Start = new DateTime(2022, 12, 12), End = new DateTime(2023, 5, 10)},
                new Interval{ Start = new DateTime(2000, 1, 4), End = new DateTime(2001, 7, 5)},
                new Interval{ Start = new DateTime(2001, 6, 1), End = new DateTime(2001, 8, 5)}
            };


            List<Interval> result = new List<Interval>();

            DateTime _start;
            DateTime _end;
            while (dates.Count > 0)
            {
                var minDate = dates.Min(t => t.Start);
                var min = dates.Where(d => d.Start == minDate).First();
                _start = min.Start;
                _end = min.End;
                dates.Remove(min);
                while (dates.Count > 0)
                {
                    if (dates.Any(p => p.Start <= min.End))
                    {
                        var x = dates.Where(p => p.Start <= min.End).FirstOrDefault();
                        _end = x.End;
                        dates.Remove(x);
                        continue;
                    }
                    break;
                }

                Interval model = new Interval()
                {
                    Start = _start,
                    End = _end
                };
                result.Add(model);
            }

            foreach (var item in result)
            {
                Console.WriteLine("{0} {1}", item.Start.ToString("dd/MM/yyyy"), item.End.ToString("dd/MM/yyyy"));
            }

            Console.ReadKey();

        }
    }
}
