using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVCWebApplication.Web.Interfaces
{
    interface IBaseHandler<Request,Response>
    {
        void Handle(Request request,Response response);
    }
}
