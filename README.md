# Puzzles

My solutions to programming challenges

- [Advent of Code](https://adventofcode.com)
- [AquaQ Challenge](https://challenges.aquaq.co.uk)
- [Codyssi](https://www.codyssi.com)
- [Everybody Codes](https://everybody.codes)
- [FlipFlop Codes](https://flipflop.slome.org)
- [Project Euler](https://projecteuler.net)

## Running Puzzles

Use these shortcut scripts to run puzzles without typing the full dotnet command.

### Quick Start

#### macOS / Linux

```bash
./run [options]
```

#### Windows

```cmd
run [options]
```

### Options

**`-t, --tags`** - Filter puzzles by comma-separated tags

```bash
./run --tags euler,65          # Run Euler puzzle 65
./run --tags aoc,2022          # Run all 2022 Advent of Code puzzles
./run --tags ec,2024,12        # Run Everybody Codes event 2024 quest 12
./run --tags ec,s2,1           # Run Everybody Codes story 2 quest 1
./run --tags codyssi,2025,15   # Run Codyssi challenge 15 2025
./run --tags ff,2025,3         # Run FlipFlop puzzle 3 2025
./run --tags aquaq             # Run all Aquaq puzzles
```

**`-s, --search`** - Search by title, class name, or comments

```bash
./run --search "fibonacci"
./run --search "prime numbers"
```

**`-h, --help`** - Display help text

```bash
./run --help
```

### What These Scripts Do

These scripts are shortcuts for:

```bash
dotnet run --project Client/Client.csproj -- [options]
```

They make it easier to run puzzles without typing the full command each time.
