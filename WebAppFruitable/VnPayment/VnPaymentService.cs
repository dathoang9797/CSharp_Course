using System.Net;
using Microsoft.Extensions.Options;
using WebAppFruitable.Model;
using WebAppFruitable.Services;
using WebApplication1.VnPayment;

namespace WebAppFruitable.VnPayment;

public class VnPaymentService
{
    private IHttpContextAccessor Accessor { get; set; }
    private VnPaymentRequest Request { get; set; }

    public VnPaymentService(IHttpContextAccessor accessor, IOptions<VnPaymentRequest> options)
    {
        Accessor = accessor;
        Request = options.Value;
    }

    public string ToUrlPayment(Invoice obj)
    {
        var Url = "";
        if (Accessor.HttpContext != null && Accessor.HttpContext.Connection.RemoteIpAddress != null)
        {
            SortedDictionary<string, string> dict = new SortedDictionary<string, string>
            {
                { "vnp_Version", Request.Version },
                { "vnp_Command", Request.Command },
                { "vnp_TmnCode", Request.TmnCode },
                { "vnp_Amount", (obj.Amount * 100).ToString() },
                { "vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss") },
                { "vnp_CurrCode", Request.CurrCode },
                {
                    "vnp_IpAddr",
                    Accessor.HttpContext?.Connection.RemoteIpAddress?.AddressFamily.ToString() ?? string.Empty
                },
                { "vnp_Locale", Request.Locale },
                { "vnp_OrderInfo", $"{obj.Email} Payment with: {obj.Amount}" },
                { "vnp_OrderType", "topup" },
                { "vnp_ReturnUrl", Request.ReturnUrl },
                { "vnp_ExpireDate", DateTime.Now.AddHours(1).ToString("yyyyMMddHHmmss") },
                { "vnp_TxnRef", obj.InvoiceId.ToString() },
            };

            var queryString = string.Join("&", dict.Select(p => $"{p.Key}={WebUtility.UrlEncode(p.Value)}"));
            var hash = Helper.HmaxSha(Request.HashSecret, queryString);
            Url = $"{Request.SandboxUrl}?{queryString}&vnp_SecureHash={hash}";
        }

        return Url;
    }
}