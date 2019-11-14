#!/bin/bash

# creates c# projectfolder for consoleapps

echo "Name of project: "
read name
mkdir $name
cd $name
mkdir $name
cd $name
dotnet new console
cd ..
dotnet new sln --force
dotnet sln add $name
cd ..
