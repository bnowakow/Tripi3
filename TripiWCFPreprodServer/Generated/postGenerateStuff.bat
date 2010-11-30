rem Copy Windows proxy
robocopy .\ForWindowsClient\ ..\..\TripiWCFClientMockup\ /NJH /NFL /NC /NDL

rem Generate Windows Mobile proxy
robocopy .\ForMobile\ ..\..\TripiMobile\wcf\ /NJH /NFL /NC /NDL

rem Copy Silverlight proxy
robocopy .\ForSilverlite\ ..\..\SilverlightShowcase\ /NJH /NFL /NC /NDL
