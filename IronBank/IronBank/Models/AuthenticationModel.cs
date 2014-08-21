﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace IronBank.Models
{
    public class AuthenticationModel
    {
        public class CustomAuthorize : ActionFilterAttribute, IAuthenticationFilter
        {
            public System.Threading.Tasks.Task AuthenticateAsync(HttpAuthenticationContext context, System.Threading.CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }

            public System.Threading.Tasks.Task ChallengeAsync(HttpAuthenticationChallengeContext context, System.Threading.CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}