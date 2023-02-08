using Microsoft.AspNetCore.Mvc;

namespace C2_Week3_Review.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainApi : ControllerBase
    {
        [HttpPost(Name = "GetWeatherForecast")]
        public ActionResult<List<string>> IntList(List<int> lint)
        {
            List<string> slist = new List<string>();
            List<int> childList = new List<int>();

            double mean = 0;
            double sum = 0;
            double standardDeviation = 0;

            lint.Sort();

            foreach (int i in lint)
            {
                childList.Add(i);
                if (childList.Count() > 1)
                {
                    mean = childList.Average();
                    sum = childList.Sum(d => (d - mean) * (d - mean));
                    standardDeviation = Math.Sqrt(sum / (childList.Count()-1));
                    slist.Add("Elements: " + childList.Count() + " Current Standard Deviation: " + standardDeviation);
                }
                else
                {
                    slist.Add("List too small");
                }
            }

            //return slist;
            return Accepted(slist);
        }
    }
}