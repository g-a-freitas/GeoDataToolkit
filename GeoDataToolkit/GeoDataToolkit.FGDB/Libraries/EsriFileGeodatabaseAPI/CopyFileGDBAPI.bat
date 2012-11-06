ECHO =================================================
ECHO Copying FileGeodatabase DLLs to bin dir
ECHO -------------------------------------------------
ECHO Current Dir: %CD%

Set SOLUTION_DIR=%2

ECHO Solution Dir: %SOLUTION_DIR%

IF (%1) EQU (x86) (
  xcopy /Y /Q /D %SOLUTION_DIR%\GeoDataToolkit.FGDB\Libraries\EsriFileGeodatabaseAPI\x86\FileGDBAPI*.*
  xcopy /Y /Q /D %SOLUTION_DIR%\GeoDataToolkit.FGDB\Libraries\EsriFileGeodatabaseAPI\x86\Esri.FileGDB*.*
  GOTO :EOF
)

IF (%1) EQU (AnyCPU) (
  xcopy /Y /Q /D %SOLUTION_DIR%\GeoDataToolkit.FGDB\Libraries\EsriFileGeodatabaseAPI\x86\FileGDBAPI*.*
  xcopy /Y /Q /D %SOLUTION_DIR%\GeoDataToolkit.FGDB\Libraries\EsriFileGeodatabaseAPI\x86\Esri.FileGDB*.*
  GOTO :EOF
)

IF (%1) EQU (x64) (
  xcopy /Y /Q /D %SOLUTION_DIR%\GeoDataToolkit.FGDB\Libraries\EsriFileGeodatabaseAPI\x64\FileGDBAPI*.*
  xcopy /Y /Q /D %SOLUTION_DIR%\GeoDataToolkit.FGDB\Libraries\EsriFileGeodatabaseAPI\x64\Esri.FileGDB*.*
  GOTO :EOF
)

ECHO Unknown platform (%1).  Failed to copy files

ECHO =================================================
