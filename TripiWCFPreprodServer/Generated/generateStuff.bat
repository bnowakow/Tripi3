rem svcutil TripiWCFService.dll
rem svcutil /namespace:*,TripiWCF.ClientMockup.Proxy tempuri.org.wsdl *.xsd /out:ProxyTripiWCFService.cs
netcfsvcutil.exe tempuri.org.wsdl tempuri.org.xsd TripiWCF.Service.xsd schemas.microsoft.com.2003.10.Serialization.xsd schemas.microsoft.com.Message.xsd
move tempuri.org.cs .\ForMobile\
move CFClientBase.cs .\ForMobile\
