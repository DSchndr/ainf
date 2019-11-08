#!/bin/bash

for dir in *
do
  test -d "$dir" || continue
  cd $dir
  dotnet new sln --force
  dotnet sln add $dir
  cd ..
done
