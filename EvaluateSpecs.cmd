@ECHO OFF

SET mstestexe="%programfiles(x86)%\Microsoft Visual Studio 11.0\Common7\ide\MSTest.exe"
SET specflowexe=".\packages\SpecFlow.1.9.0\tools\specflow.exe"

IF EXIST .\TestResults\Tetris.Specs.trx DEL .\TestResults\Tetris.Specs.trx

%mstestexe% /testcontainer:.\Tetris.Specs\bin\Debug\Tetris.Specs.dll /resultsfile:.\TestResults\Tetris.Specs.trx
rem %specflowexe% help mstestexecutionreport
%specflowexe% mstestexecutionreport .\Tetris.Specs\Tetris.Specs.csproj /testResult:.\TestResults\Tetris.Specs.trx /out:.\TestResults\Tetris.Specs.html

.\TestResults\Tetris.Specs.html
