using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing_Endpoint_Filter_Convention.Controllers
{
    [Authorize(Policy = "defaultpolicy")]
    public class BaseController: Controller
    {
    }
}
