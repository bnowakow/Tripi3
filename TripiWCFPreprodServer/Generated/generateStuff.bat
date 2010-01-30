svcutil TripiWCFService.dll
svcutil /namespace:*,TripiWCF.ClientMockup.Proxy tempuri.org.wsdl *.xsd /out:ProxyTripiWCFService.cs
