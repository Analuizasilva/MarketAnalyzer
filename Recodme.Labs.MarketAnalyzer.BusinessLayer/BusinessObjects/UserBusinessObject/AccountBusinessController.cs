using Microsoft.AspNetCore.Identity;
using Recodme.Labs.MarketAnalyzer.BusinessLayer.OperationResults;
using Recodme.RD.FullStoQReborn.DataLayer.UserRecords;
using System;
using System.Threading.Tasks;
using System.Transactions;

namespace Recodme.Labs.MarketAnalyzer.BusinessLayer.BusinessObjects.UserBusinessObject
{
    public class AccountBusinessController
    {
        private UserManager<User> UserManager { get; set; }

        private readonly ProfileBusinessObject _pbo = new ProfileBusinessObject();

        public AccountBusinessController(UserManager<User> uManager)
        {
            UserManager = uManager;
        }


        TransactionOptions transactionOptions = new TransactionOptions
        {
            IsolationLevel = IsolationLevel.ReadCommitted,
            Timeout = TimeSpan.FromSeconds(30)
        };

        public async Task<OperationResult> Register(string userName, string email, string password, Profile profile)
        {
            if (await UserManager.FindByEmailAsync(email) != null)
                return new OperationResult() { Success = false, Message = $"User {email} already exists" };
            if (await UserManager.FindByNameAsync(userName) != null)
                return new OperationResult() { Success = false, Message = $"User {userName} already exists" };
            using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
            try
            {
                var createPersonOperation = await _pbo.CreateAsync(profile);
                if (!createPersonOperation.Success)
                {
                    transactionScope.Dispose();
                    return createPersonOperation;
                }
                var user = new User()
                {
                    Email = email,
                    UserName = userName,
                    ProfileId = profile.Id
                };
                var result = await UserManager.CreateAsync(user, password);
                if (!result.Succeeded)
                {
                    transactionScope.Dispose();
                    return new OperationResult() { Success = false, Message = result.ToString() };
                }

                transactionScope.Complete();
                return new OperationResult() { Success = true };
            }
            catch (Exception e)
            {
                return new OperationResult() { Success = false, Exception = e };
            }
        }

        public async Task<OperationResult<Profile>> GetProfile(IdentityUser<int> user)
        {
            if (user is User)
            {
                var restUser = (User)user;
                try
                {

                    using var transactionScope = new TransactionScope(TransactionScopeOption.Required, transactionOptions, TransactionScopeAsyncFlowOption.Enabled);
                    var personOperation = await _pbo.ReadAsync(restUser.ProfileId);
                    transactionScope.Complete();
                    return personOperation;
                }
                catch (Exception e)
                {
                    return new OperationResult<Profile>() { Success = false, Exception = e };
                }
            }
            return new OperationResult<Profile>() { Success = false, Message = "The user is not a User" };
        }


    }
}

