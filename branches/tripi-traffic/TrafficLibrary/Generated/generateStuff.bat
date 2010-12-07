rem Generate basic info
svcutil ..\bin\Debug\TrafficLibrary.dll

rem Generate Windows proxy
svcutil /namespace:*,TrafficDebugVisualizer.WCF tempuri.org.wsdl *.xsd /out:WinTrafficWCFClient.cs
move WinTrafficWCFClient.cs .\ForWindowsClient\

rem Generate Windows Mobile proxy
rem schemas.microsoft.com.Message.xsd schemas.microsoft.com.2003.10.Serialization.xsd
netcfsvcutil.exe tempuri.org.wsdl tempuri.org.xsd TrafficLibrary.xsd schemas.microsoft.com.2003.10.Serialization.xsd schemas.microsoft.com.Message.xsd /namespace:*,TrafficMobile.WCF /out:MobileTrafficWCFClient.cs
move MobileTrafficWCFClient.cs .\ForMobile\
move CFClientBase.cs .\ForMobile\

rem Satisfy Staro's Sexy Silverlight
SlSvcUtil.exe tempuri.org.wsdl tempuri.org.xsd TrafficLibrary.xsd schemas.microsoft.com.2003.10.Serialization.xsd schemas.microsoft.com.Message.xsd /o:SliteTrafficWCFClient.cs
move SliteTrafficWCFClient.cs .\ForSilverlite\

rem Cleanup
del *.config
del *.wsdl
del *.xsd
