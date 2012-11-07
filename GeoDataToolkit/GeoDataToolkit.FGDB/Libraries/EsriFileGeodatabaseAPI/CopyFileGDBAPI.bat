ECHO =================================================
ECHO Copying FileGeodatabase DLLs to bin dir
ECHO -------------------------------------------------
ECHO Current Dir: %CD%
ECHO Batch Dir: %~dp0

Set BATCHFILE_DIR=%~dp0

IF (%1) EQU (x86) (
  xcopy /Y /Q /D %BATCHFILE_DIR%\x86\FileGDBAPI*.*
  xcopy /Y /Q /D %BATCHFILE_DIR%\x86\Esri.FileGDB*.*
  GOTO :EOF
)

IF (%1) EQU (AnyCPU) (
  xcopy /Y /Q /D %BATCHFILE_DIR%\x86\FileGDBAPI*.*
  xcopy /Y /Q /D %BATCHFILE_DIR%\x86\Esri.FileGDB*.*
  GOTO :EOF
)

IF (%1) EQU (x64) (
  xcopy /Y /Q /D %BATCHFILE_DIR%\x64\FileGDBAPI*.*
  xcopy /Y /Q /D %BATCHFILE_DIR%\x64\Esri.FileGDB*.*
  GOTO :EOF
)

ECHO Unknown platform (%1).  Failed to copy files

ECHO =================================================
