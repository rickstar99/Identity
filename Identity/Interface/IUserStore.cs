﻿using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Identity.Models;

namespace Identity.Interface
{
    public interface IUserStore
    {
        //
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
        public User AutoProvisionUser(string provider, string userId, List<Claim> claims);
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
        public User FindByExternalProvider(string provider, string userId, string email);
        //
        // Summary:
        //     Finds the user by subject identifier.
        //
        // Parameters:
        //   subjectId:
        //     The subject identifier.
        public Task<User> FindBySubjectId(string subjectId);
        //
        // Summary:
        //     Finds the user by username.
        //
        // Parameters:
        //   username:
        //     The username.
        public Task<User> FindByUsername(string username);
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
        public void MarkEmailAsVerified(string username);
        public bool ValidateCredentials(string username, string password);
        public void ChangePassword(string username, string password, bool isStaff);
    }
}