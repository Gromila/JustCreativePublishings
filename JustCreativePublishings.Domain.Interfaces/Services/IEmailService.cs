using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustCreativePublishings.Interfaces.Services
{
    public interface IEmailService : IService
    {
        void SendConfirmationToken(String to, String username, String url);

        String CreateConfirmationToken();
    }
}
