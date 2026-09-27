@echo off
REM Shortcut script for running puzzles on Windows
REM Usage: run [options]
REM   run --tags euler,65
REM   run --tags aoc,2022
REM   run --search "puzzle name"
REM   run --help

dotnet run --project Client/Client.csproj -- %*
