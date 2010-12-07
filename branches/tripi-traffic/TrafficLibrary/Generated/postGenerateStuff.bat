rem Copy Windows proxy
robocopy .\ForWindowsClient\ ..\..\TrafficDebugVisualizer\WCF\ /NJH /NFL /NC /NDL

rem Generate Windows Mobile proxy
rem robocopy .\ForMobile\ ..\..\TripiMobile\wcf\ /NJH /NFL /NC /NDL

rem Copy Silverlight proxy
robocopy .\ForSilverlite\ ..\..\SilverlightShowcase\ /NJH /NFL /NC /NDL
