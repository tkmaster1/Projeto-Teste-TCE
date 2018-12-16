﻿using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Livraria.WebAPI_1
{
    public class Mime : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (!actionContext.Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(
                    new HttpResponseMessage(
                        HttpStatusCode.UnsupportedMediaType)
                );
            }
        }
    }
}
