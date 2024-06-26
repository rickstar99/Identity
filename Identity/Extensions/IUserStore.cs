﻿using Identity.Models;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Identity.Extensions
{
    public interface IUserStore
    {
        // Summary:
        //     Automatically provisions a user.
        //
        // Parameters:
        //   provider:
        //     The provider.
        //
        //   userId:
        //     The user identifier.
        //
        //   claims:
        //     The claims.
        public Users AutoProvisionUser(string provider, string userId, List<Claim> claims);
        //
        // Summary:
        //     Finds the user by external provider.
        //
        // Parameters:
        //   provider:
        //     The provider.
        //
        //   userId:
        //     The user identifier.
        public Users FindByExternalProvider(string provider, string userId, string email);
        //
        // Summary:
        //     Finds the user by subject identifier.
        //
        // Parameters:
        //   subjectId:
        //     The subject identifier.
        public Users FindBySubjectId(string subjectId);
        //
        // Summary:
        //     Finds the user by username.
        //
        // Parameters:
        //   username:
        //     The username.
        public Task<Users> FindByUsername(string username);
        //
        // Summary:
        //     Validates the credentials.
        //
        // Parameters:
        //   username:
        //     The username.
        //
        //   password:
        //     The password.
        public bool ValidateCredentials(string username, string password);
    }
}
