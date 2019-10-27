# 钉钉开放平台服务端 API

基本使用
```c#
using Zilor.DingTalkApi;

var ding = new DingTalkClient {
    Appkey = "appkey",
    Appsecret = "appsecret"
};
```

依赖注入
```c#
using Zilor.DingTalkApi;

public void ConfigureServices(IServiceCollection services) {
    services.AddDingTalk("appkey", "appsecret");
}

private DingTalkClient _dingTalkClient { get; set; }

//在控制器使用
public HelloController(DingTalkClient ding) {
    _dingTalkClient = ding;
}
```