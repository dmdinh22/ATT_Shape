﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twilio.Jwt.AccessToken;


namespace ATT_Shape.domain.Classes
{
    public interface ITokenGenerator
    {
        string Generate(string identity, string endpointId);
    }
    public class TokenGenerator: ITokenGenerator
    {
        public string Generate(string identity, string endpointId)
        {
            var grants = new HashSet<IGrant>
            {
                new IpMessagingGrant {EndpointId = endpointId, ServiceSid = Configuration.IpmServiceSID}
            };
            var token = new Token(
                Configuration.AccountSID,
                Configuration.ApiKey,
                Configuration.ApiSecret,
                identity,
                grants: grants);

            return token.ToJwt();

        }
    }
}
