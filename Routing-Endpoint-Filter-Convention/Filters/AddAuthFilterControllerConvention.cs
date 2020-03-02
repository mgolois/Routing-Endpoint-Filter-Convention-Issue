using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Routing_Endpoint_Filter_Convention.Filters
{
    public class AddAuthFilterControllerConvention : IControllerModelConvention
    {

        public void Apply(ControllerModel controller)
        {
            var filters = controller.Filters.Where(f => f.GetType() == typeof(AuthorizeFilter));

            foreach (var authFilter in filters)
            {
                var removeFilter = (authFilter as AuthorizeFilter)?.Policy.Requirements.FirstOrDefault(r => r.GetType() == typeof(RoleRequirement));

                if (removeFilter != null)
                {
                    controller.Filters.Remove(authFilter);
                }
            }
        }
    }
}
