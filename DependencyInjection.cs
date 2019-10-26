using System;
using System.Reflection;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Zilor.DingTalkApi
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDingTalk(this IServiceCollection services, string appkey, string appsecret)
        {
            var dingTalk = new DingTalkApi { Appkey = appkey, Appsecret = appsecret };
            services.AddSingleton(dingTalk);
            return services;
        }
    }
}
