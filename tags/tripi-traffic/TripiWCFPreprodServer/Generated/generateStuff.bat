rem Generate basic info
svcutil ..\bin\Debug\TripiWCFService.dll

rem Generate Windows proxy
svcutil /namespace:*,TripiWCF.ClientMockup.Proxy tempuri.org.wsdl *.xsd /out:ProxyTripiWCFService.cs
move ProxyTripiWCFService.cs .\ForWindowsClient\

rem Generate Windows Mobile proxy
netcfsvcutil.exe tempuri.org.wsdl tempuri.org.xsd TripiWCF.Service.xsd schemas.microsoft.com.2003.10.Serialization.xsd schemas.microsoft.com.Message.xsd /out:TripiWCFService.cs
move TripiWCFService.cs .\ForMobile\
move CFClientBase.cs .\ForMobile\

rem Satisfy Staro's Sexy Silverlight
SlSvcUtil.exe tempuri.org.wsdl tempuri.org.xsd TripiWCF.Service.xsd schemas.microsoft.com.2003.10.Serialization.xsd schemas.microsoft.com.Message.xsd /o:TripiServiceClient.cs
move TripiServiceClient.cs .\ForSilverlite\

rem Cleanup
del *.config
del *.wsdl
del *.xsd
