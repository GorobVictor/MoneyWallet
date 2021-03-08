using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebApi.Utils
{
    public static class Extensions
    {
        public static int GetUserId(this ControllerBase controller)
        {
            if (controller.User.Identity.IsAuthenticated)
            {
                return Convert.ToInt32(controller.User.Claims.First(x => x.Type == "userId").Value);
            }
            return -1;
        }
    }
}
