using System;
using DingTalk.Api;
using DingTalk.Api.Request;

namespace Zilor.DingTalkApi
{
    public class DingTalkClient
    {
        private string _accessToken;
        private DateTime _validTime;

        public string Appkey { get; set; }
        public string Appsecret { get; set; }

        public string AccessToken
        {
            get
            {
                if (!string.IsNullOrEmpty(_accessToken) && _validTime >= DateTime.Now) return _accessToken;

                var dingtalk = new DefaultDingTalkClient("https://oapi.dingtalk.com/gettoken");
                var request = new OapiGettokenRequest
                {
                    Appkey = Appkey,
                    Appsecret = Appsecret
                };
                request.SetHttpMethod("GET");
                var response = dingtalk.Execute(request);

                if (response.Errcode != 0)
                    throw new Exception(response.Errmsg);

                _accessToken = response.AccessToken;
                _validTime = DateTime.Now.AddSeconds(7000);
                return _accessToken;
            }
        }

        public string GetUserId(string authCode)
        {
            var client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/getuserinfo");
            var request = new OapiUserGetuserinfoRequest { Code = authCode };
            request.SetHttpMethod("GET");
            var response = client.Execute(request, AccessToken);

            if (response.Errcode != 0)
                throw new Exception(response.Errmsg);

            return response.Userid;
        }

        public string GetJobNumber(string userId)
        {
            var client = new DefaultDingTalkClient("https://oapi.dingtalk.com/user/get");
            var request = new OapiUserGetRequest { Userid = userId };
            request.SetHttpMethod("GET");
            var response = client.Execute(request, AccessToken);

            if (response.Errcode != 0)
                throw new Exception(response.Errmsg);

            return response.Jobnumber;
        }
    }

}
