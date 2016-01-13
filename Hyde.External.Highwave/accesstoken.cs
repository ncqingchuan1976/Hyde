using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hyde.External.Highwave
{
    public class accessToken
    {
        public string access_token { get; set; }

        public int expires_in { get; set; }

        public string token_type { get; set; }
    }

    public class error_state
    {
        public string error { get; set; }

        public string error_description { get; set; }

    }
}
