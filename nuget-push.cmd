@ECHO OFF

SET Id=AccountNumberTools
SET VERSION=0.2.0.0

3rdParty\nuget\nuget delete %ID% %VERSION%
3rdParty\nuget\nuget push Build\nuget\%ID%.%VERSION%.nupkg