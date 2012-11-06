mkdir Results
Tools\OpenCover.4.0.804\OpenCover.Console.exe -target:"Tools\NUnit 2.6.2\nunit-console-x86.exe" -targetargs:"/nologo /noshadow /framework=4.0 ../Tests/GeoDataTests.nunit /xml=Results\nunit_testsresults.xml" -filter:"+[GeoDataToolkit]* +[GeoDataToolkit.FGDB]*" -output:"Results/opencover_results.xml" -register:user
Tools\NUnit-Results\nunit-results.exe Results\nunit_testsresults.xml Results\NUnitReport
Results\NUnitReport\index.html
Tools\ReportGenerator.1.6.1.0\ReportGenerator -reports:Results/opencover_results.xml -targetdir:Results/CoverageReport
Results\CoverageReport\index.htm
pause