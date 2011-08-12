@ECHO OFF

SET OUTDIR=Build\nuget
mkdir %OUTDIR%

3rdParty\nuget\nuget pack AccountNumberTools.nuspec -outputdirectory %OUTDIR%