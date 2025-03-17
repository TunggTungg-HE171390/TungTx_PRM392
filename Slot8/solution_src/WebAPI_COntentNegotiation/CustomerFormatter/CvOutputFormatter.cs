using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;

namespace WebAPI_COntentNegotiation.CustomerFormatter
{
    public class CvOutputFormatter : TextOutputFormatter
    {
        public CvOutputFormatter() {
            SupportedMediaTypes.Add("text/csv");
            SupportedEncodings.Add(Encoding.UTF8);
        }
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            throw new NotImplementedException();
        }
    }
}
