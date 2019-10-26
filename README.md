# 钉钉开放平台服务端 API

基本使用
```c#
var ding = new DingTalkApi {
    Appkey = "appkey",
    Appsecret = "appsecret"
};
```

依赖注入
```c#
public void ConfigureServices(IServiceCollection services) {
    services.AddDingTalk("appkey", "appsecret");
}

//在控制器使用
public HelloController(DingTalkApi ding) {
    
}
```