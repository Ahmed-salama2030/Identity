﻿// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.InMemory;
using Microsoft.AspNetCore.Identity.Test;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Identity.DefaultUI.WebSite
{
    public class PocoUserStartup : StartupBase<PocoUser, IdentityDbContext>
    {
        public PocoUserStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
            });

            services.AddDefaultIdentity<Microsoft.AspNetCore.Identity.Test.PocoUser>()
                .AddDefaultUI(UIFramework.Bootstrap4)
                .AddUserManager<UserManager<Microsoft.AspNetCore.Identity.Test.PocoUser>>()
                .AddDefaultUIUserFactory<Microsoft.AspNetCore.Identity.Test.PocoUser>((userName,email) =>
                    new Microsoft.AspNetCore.Identity.Test.PocoUser()
                    {
                        UserName = userName,
                        Email = email
                    });
            services.AddSingleton<IUserStore<Microsoft.AspNetCore.Identity.Test.PocoUser>, InMemoryUserStore<Microsoft.AspNetCore.Identity.Test.PocoUser>>();

            services.AddMvc();
        }
    }
}
