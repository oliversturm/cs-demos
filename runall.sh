#!/bin/bash
find . -type f -name \*.csproj -exec bash -c 'echo "Executing {}"; dotnet run --project "{}"' \; 2>&1 | tee runall-output.txt
echo
echo "Check runall-output.txt for results."
