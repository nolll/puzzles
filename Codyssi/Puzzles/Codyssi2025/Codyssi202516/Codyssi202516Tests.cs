using System.Numerics;
using FluentAssertions;
using NUnit.Framework;

namespace Pzl.Codyssi.Puzzles.Codyssi2025.Codyssi202516;

public class Codyssi202516Tests
{
    private const string Input1 = """
                                 FACE - VALUE 38
                                 ROW 2 - VALUE 71
                                 ROW 1 - VALUE 57
                                 ROW 3 - VALUE 68
                                 COL 1 - VALUE 52
                                 
                                 LURD
                                 """;
    
    private const string Input2 = """
                                  FACE - VALUE 38
                                  COL 32 - VALUE 39
                                  COL 72 - VALUE 12
                                  COL 59 - VALUE 56
                                  COL 77 - VALUE 31
                                  FACE - VALUE 43
                                  COL 56 - VALUE 47
                                  ROW 73 - VALUE 83
                                  COL 15 - VALUE 87
                                  COL 76 - VALUE 57
                                  
                                  ULDLRLLRU
                                  """;
    
    private const string Input3 = """
                                  FACE - VALUE 99
                                  FACE - VALUE 10
                                  ROW 1 - VALUE 20
                                  COL 80 - VALUE 30
                                  FACE - VALUE 40
                                  ROW 2 - VALUE 50
                                  COL 78 - VALUE 60
                                  FACE - VALUE 70
                                  ROW 3 - VALUE 80
                                  COL 77 - VALUE 90
                                  FACE - VALUE 11
                                  ROW 4 - VALUE 21
                                  COL 76 - VALUE 31
                                  FACE - VALUE 41
                                  ROW 5 - VALUE 51
                                  COL 75 - VALUE 61
                                  FACE - VALUE 71
                                  ROW 6 - VALUE 81
                                  COL 74 - VALUE 91
                                  FACE - VALUE 12
                                  ROW 7 - VALUE 22
                                  COL 73 - VALUE 32
                                  FACE - VALUE 42
                                  ROW 8 - VALUE 52
                                  COL 72 - VALUE 62
                                  FACE - VALUE 72
                                  ROW 9 - VALUE 82
                                  COL 71 - VALUE 92
                                  
                                  ULDDRUURDRULRDLLURLDRLURLLL
                                  """;

    private const string Input4 = """
                                  COL 73 - VALUE 9
                                  ROW 49 - VALUE 13
                                  FACE - VALUE 31
                                  ROW 9 - VALUE 60
                                  COL 13 - VALUE 68
                                  ROW 27 - VALUE 94
                                  COL 64 - VALUE 61
                                  ROW 50 - VALUE 15
                                  FACE - VALUE 88
                                  ROW 25 - VALUE 39
                                  COL 2 - VALUE 60
                                  FACE - VALUE 76
                                  ROW 5 - VALUE 98
                                  COL 77 - VALUE 75
                                  ROW 29 - VALUE 2
                                  COL 31 - VALUE 2
                                  COL 38 - VALUE 13
                                  FACE - VALUE 67
                                  COL 18 - VALUE 2
                                  ROW 17 - VALUE 10
                                  FACE - VALUE 61
                                  COL 9 - VALUE 37
                                  ROW 58 - VALUE 9
                                  COL 27 - VALUE 92
                                  ROW 23 - VALUE 7
                                  ROW 70 - VALUE 43
                                  COL 27 - VALUE 8
                                  ROW 53 - VALUE 21
                                  COL 57 - VALUE 14
                                  ROW 37 - VALUE 79
                                  ROW 68 - VALUE 68
                                  ROW 59 - VALUE 20
                                  ROW 37 - VALUE 54
                                  FACE - VALUE 62
                                  ROW 65 - VALUE 79
                                  COL 18 - VALUE 63
                                  COL 48 - VALUE 94
                                  FACE - VALUE 85
                                  ROW 71 - VALUE 70
                                  COL 59 - VALUE 76
                                  COL 31 - VALUE 66
                                  ROW 58 - VALUE 90
                                  ROW 19 - VALUE 15
                                  COL 73 - VALUE 85
                                  COL 67 - VALUE 46
                                  ROW 44 - VALUE 66
                                  COL 28 - VALUE 62
                                  ROW 10 - VALUE 91
                                  COL 57 - VALUE 40
                                  ROW 52 - VALUE 25
                                  ROW 44 - VALUE 21
                                  ROW 76 - VALUE 41
                                  COL 56 - VALUE 10
                                  COL 36 - VALUE 71
                                  COL 42 - VALUE 69
                                  COL 10 - VALUE 49
                                  COL 35 - VALUE 87
                                  COL 16 - VALUE 41
                                  ROW 50 - VALUE 18
                                  COL 15 - VALUE 98
                                  FACE - VALUE 92
                                  COL 46 - VALUE 90
                                  COL 45 - VALUE 69
                                  COL 63 - VALUE 70
                                  ROW 8 - VALUE 79
                                  FACE - VALUE 34
                                  FACE - VALUE 42
                                  ROW 32 - VALUE 45
                                  FACE - VALUE 45
                                  FACE - VALUE 42
                                  ROW 55 - VALUE 27
                                  ROW 42 - VALUE 81
                                  FACE - VALUE 58
                                  ROW 57 - VALUE 26
                                  ROW 70 - VALUE 51
                                  COL 74 - VALUE 20
                                  FACE - VALUE 96
                                  ROW 47 - VALUE 82
                                  ROW 73 - VALUE 68
                                  COL 12 - VALUE 67
                                  COL 5 - VALUE 30
                                  FACE - VALUE 33
                                  ROW 27 - VALUE 49
                                  ROW 26 - VALUE 98
                                  ROW 51 - VALUE 27
                                  FACE - VALUE 49
                                  FACE - VALUE 34
                                  COL 56 - VALUE 39
                                  COL 42 - VALUE 21
                                  COL 49 - VALUE 27
                                  COL 11 - VALUE 78
                                  COL 13 - VALUE 32
                                  ROW 72 - VALUE 82
                                  COL 31 - VALUE 20
                                  FACE - VALUE 74
                                  ROW 42 - VALUE 97
                                  COL 38 - VALUE 17
                                  COL 29 - VALUE 79
                                  FACE - VALUE 43
                                  COL 32 - VALUE 5
                                  COL 22 - VALUE 4
                                  COL 36 - VALUE 7
                                  ROW 20 - VALUE 9
                                  COL 40 - VALUE 80
                                  COL 20 - VALUE 19
                                  COL 11 - VALUE 16
                                  FACE - VALUE 69
                                  COL 32 - VALUE 93
                                  FACE - VALUE 96
                                  ROW 10 - VALUE 20
                                  FACE - VALUE 72
                                  COL 21 - VALUE 34
                                  COL 55 - VALUE 64
                                  ROW 52 - VALUE 51
                                  ROW 76 - VALUE 6
                                  COL 45 - VALUE 38
                                  COL 15 - VALUE 21
                                  COL 37 - VALUE 37
                                  ROW 38 - VALUE 85
                                  COL 37 - VALUE 65
                                  ROW 78 - VALUE 47
                                  COL 63 - VALUE 35
                                  ROW 13 - VALUE 73
                                  ROW 16 - VALUE 37
                                  FACE - VALUE 58
                                  COL 75 - VALUE 42
                                  FACE - VALUE 47
                                  COL 64 - VALUE 81
                                  ROW 23 - VALUE 25
                                  ROW 5 - VALUE 74
                                  FACE - VALUE 24
                                  ROW 31 - VALUE 55
                                  FACE - VALUE 25
                                  ROW 56 - VALUE 9
                                  ROW 39 - VALUE 85
                                  ROW 16 - VALUE 6
                                  ROW 13 - VALUE 94
                                  ROW 19 - VALUE 93
                                  ROW 31 - VALUE 33
                                  COL 13 - VALUE 18
                                  ROW 21 - VALUE 21
                                  ROW 1 - VALUE 62
                                  COL 48 - VALUE 57
                                  COL 44 - VALUE 19
                                  COL 79 - VALUE 51
                                  COL 6 - VALUE 82
                                  COL 20 - VALUE 97
                                  COL 30 - VALUE 61
                                  ROW 50 - VALUE 19
                                  COL 64 - VALUE 25
                                  COL 70 - VALUE 30
                                  ROW 16 - VALUE 7
                                  COL 12 - VALUE 64
                                  COL 48 - VALUE 69
                                  ROW 20 - VALUE 15
                                  ROW 30 - VALUE 88
                                  FACE - VALUE 36
                                  FACE - VALUE 59
                                  COL 77 - VALUE 18
                                  FACE - VALUE 34
                                  FACE - VALUE 85
                                  ROW 69 - VALUE 63
                                  ROW 12 - VALUE 57
                                  ROW 8 - VALUE 37
                                  ROW 26 - VALUE 26
                                  FACE - VALUE 62
                                  COL 53 - VALUE 39
                                  FACE - VALUE 36
                                  ROW 15 - VALUE 77
                                  COL 69 - VALUE 91
                                  ROW 76 - VALUE 22
                                  FACE - VALUE 58
                                  ROW 60 - VALUE 94
                                  FACE - VALUE 3
                                  ROW 13 - VALUE 31
                                  COL 35 - VALUE 12
                                  ROW 58 - VALUE 54
                                  ROW 62 - VALUE 80
                                  COL 46 - VALUE 11
                                  FACE - VALUE 1
                                  COL 11 - VALUE 31
                                  COL 14 - VALUE 69
                                  COL 44 - VALUE 22
                                  FACE - VALUE 71
                                  FACE - VALUE 46
                                  FACE - VALUE 83
                                  COL 79 - VALUE 55
                                  ROW 43 - VALUE 29
                                  FACE - VALUE 6
                                  ROW 8 - VALUE 50
                                  COL 58 - VALUE 60
                                  COL 69 - VALUE 24
                                  ROW 64 - VALUE 40
                                  COL 60 - VALUE 98
                                  ROW 77 - VALUE 34
                                  COL 79 - VALUE 99
                                  COL 71 - VALUE 35
                                  FACE - VALUE 63
                                  FACE - VALUE 80
                                  ROW 78 - VALUE 32
                                  ROW 20 - VALUE 4
                                  COL 27 - VALUE 93
                                  FACE - VALUE 37
                                  COL 9 - VALUE 74
                                  ROW 71 - VALUE 26
                                  COL 73 - VALUE 85
                                  ROW 42 - VALUE 37
                                  ROW 67 - VALUE 97
                                  ROW 73 - VALUE 13
                                  ROW 50 - VALUE 67
                                  COL 52 - VALUE 57
                                  FACE - VALUE 49
                                  ROW 20 - VALUE 2
                                  FACE - VALUE 90
                                  COL 58 - VALUE 95
                                  ROW 15 - VALUE 2
                                  FACE - VALUE 85
                                  ROW 13 - VALUE 27
                                  FACE - VALUE 91
                                  COL 39 - VALUE 91
                                  COL 34 - VALUE 97
                                  COL 7 - VALUE 20
                                  COL 33 - VALUE 86
                                  FACE - VALUE 27
                                  ROW 30 - VALUE 85
                                  ROW 4 - VALUE 79
                                  FACE - VALUE 88
                                  FACE - VALUE 27
                                  ROW 40 - VALUE 57
                                  ROW 55 - VALUE 6
                                  ROW 4 - VALUE 31
                                  COL 48 - VALUE 70
                                  FACE - VALUE 66
                                  FACE - VALUE 89
                                  COL 22 - VALUE 19
                                  ROW 80 - VALUE 23
                                  ROW 67 - VALUE 12
                                  COL 65 - VALUE 17
                                  FACE - VALUE 36
                                  COL 19 - VALUE 97
                                  ROW 15 - VALUE 93
                                  COL 49 - VALUE 82
                                  COL 22 - VALUE 63
                                  COL 46 - VALUE 29
                                  FACE - VALUE 62
                                  FACE - VALUE 98
                                  COL 2 - VALUE 64
                                  FACE - VALUE 96
                                  ROW 28 - VALUE 3
                                  ROW 17 - VALUE 17
                                  FACE - VALUE 60
                                  COL 8 - VALUE 41
                                  FACE - VALUE 32
                                  ROW 13 - VALUE 62
                                  ROW 20 - VALUE 6
                                  ROW 67 - VALUE 1
                                  COL 9 - VALUE 1
                                  FACE - VALUE 90
                                  COL 56 - VALUE 92
                                  COL 48 - VALUE 94
                                  COL 72 - VALUE 36
                                  ROW 46 - VALUE 5
                                  ROW 64 - VALUE 43
                                  ROW 11 - VALUE 95
                                  COL 70 - VALUE 53
                                  FACE - VALUE 72
                                  COL 43 - VALUE 71
                                  COL 7 - VALUE 4
                                  ROW 57 - VALUE 32
                                  ROW 57 - VALUE 89
                                  ROW 51 - VALUE 5
                                  COL 24 - VALUE 99
                                  FACE - VALUE 63
                                  ROW 67 - VALUE 18
                                  COL 34 - VALUE 17
                                  FACE - VALUE 63
                                  FACE - VALUE 58
                                  FACE - VALUE 9
                                  COL 77 - VALUE 69
                                  ROW 60 - VALUE 82
                                  ROW 65 - VALUE 30
                                  COL 4 - VALUE 10
                                  ROW 71 - VALUE 5
                                  FACE - VALUE 41
                                  ROW 56 - VALUE 44
                                  COL 5 - VALUE 42
                                  ROW 30 - VALUE 39
                                  FACE - VALUE 59
                                  COL 17 - VALUE 51
                                  COL 25 - VALUE 40
                                  COL 2 - VALUE 64
                                  COL 15 - VALUE 36
                                  ROW 60 - VALUE 28
                                  ROW 51 - VALUE 53
                                  ROW 28 - VALUE 77
                                  COL 74 - VALUE 68
                                  ROW 34 - VALUE 37
                                  ROW 38 - VALUE 64
                                  COL 8 - VALUE 65
                                  FACE - VALUE 7
                                  FACE - VALUE 73
                                  ROW 79 - VALUE 14
                                  COL 61 - VALUE 5
                                  COL 2 - VALUE 14
                                  ROW 65 - VALUE 69
                                  FACE - VALUE 40
                                  COL 16 - VALUE 37
                                  ROW 80 - VALUE 74
                                  ROW 33 - VALUE 94
                                  ROW 52 - VALUE 87
                                  COL 74 - VALUE 75
                                  ROW 77 - VALUE 61
                                  COL 20 - VALUE 67
                                  COL 61 - VALUE 46
                                  COL 60 - VALUE 83
                                  ROW 36 - VALUE 19
                                  ROW 50 - VALUE 2
                                  FACE - VALUE 93
                                  ROW 51 - VALUE 55
                                  ROW 38 - VALUE 86
                                  COL 21 - VALUE 84
                                  COL 38 - VALUE 7
                                  COL 1 - VALUE 75
                                  FACE - VALUE 92
                                  FACE - VALUE 19
                                  FACE - VALUE 36
                                  COL 29 - VALUE 92
                                  ROW 28 - VALUE 27
                                  FACE - VALUE 2
                                  FACE - VALUE 28
                                  COL 38 - VALUE 42
                                  COL 75 - VALUE 54
                                  COL 15 - VALUE 25
                                  COL 38 - VALUE 66
                                  COL 35 - VALUE 77
                                  ROW 62 - VALUE 72
                                  FACE - VALUE 17
                                  ROW 40 - VALUE 55
                                  ROW 60 - VALUE 60
                                  COL 16 - VALUE 90
                                  COL 4 - VALUE 99
                                  COL 12 - VALUE 2
                                  FACE - VALUE 41
                                  COL 70 - VALUE 35
                                  FACE - VALUE 96
                                  COL 57 - VALUE 85
                                  FACE - VALUE 6
                                  ROW 46 - VALUE 86
                                  ROW 66 - VALUE 70
                                  COL 12 - VALUE 15
                                  FACE - VALUE 2
                                  ROW 56 - VALUE 98
                                  COL 54 - VALUE 56
                                  FACE - VALUE 43
                                  ROW 27 - VALUE 95
                                  FACE - VALUE 87
                                  ROW 68 - VALUE 7
                                  ROW 54 - VALUE 75
                                  COL 34 - VALUE 44
                                  ROW 57 - VALUE 10
                                  COL 24 - VALUE 2
                                  FACE - VALUE 15
                                  COL 63 - VALUE 21
                                  ROW 80 - VALUE 97
                                  ROW 46 - VALUE 7
                                  FACE - VALUE 8
                                  ROW 33 - VALUE 15
                                  ROW 64 - VALUE 68
                                  ROW 76 - VALUE 6
                                  COL 64 - VALUE 67
                                  ROW 6 - VALUE 41
                                  FACE - VALUE 9
                                  COL 58 - VALUE 17
                                  COL 13 - VALUE 5
                                  ROW 9 - VALUE 74
                                  COL 31 - VALUE 27
                                  FACE - VALUE 80
                                  COL 43 - VALUE 19
                                  COL 29 - VALUE 8
                                  COL 70 - VALUE 8
                                  ROW 30 - VALUE 10
                                  FACE - VALUE 61
                                  FACE - VALUE 47
                                  ROW 43 - VALUE 39
                                  COL 22 - VALUE 58
                                  COL 31 - VALUE 28
                                  COL 39 - VALUE 25
                                  COL 35 - VALUE 31
                                  FACE - VALUE 74
                                  ROW 40 - VALUE 92
                                  FACE - VALUE 64
                                  ROW 31 - VALUE 20
                                  ROW 68 - VALUE 29
                                  COL 79 - VALUE 8
                                  COL 4 - VALUE 1
                                  ROW 52 - VALUE 4
                                  FACE - VALUE 41
                                  FACE - VALUE 18
                                  FACE - VALUE 2
                                  ROW 53 - VALUE 49
                                  ROW 79 - VALUE 22
                                  FACE - VALUE 36
                                  FACE - VALUE 75
                                  COL 64 - VALUE 62
                                  ROW 67 - VALUE 46
                                  FACE - VALUE 82
                                  FACE - VALUE 91
                                  ROW 21 - VALUE 21
                                  ROW 4 - VALUE 58
                                  FACE - VALUE 12
                                  FACE - VALUE 67
                                  ROW 72 - VALUE 79
                                  FACE - VALUE 34
                                  ROW 16 - VALUE 68
                                  ROW 41 - VALUE 25
                                  ROW 9 - VALUE 92
                                  ROW 16 - VALUE 55
                                  ROW 9 - VALUE 3
                                  ROW 5 - VALUE 11
                                  FACE - VALUE 52
                                  FACE - VALUE 1
                                  ROW 34 - VALUE 20
                                  ROW 41 - VALUE 75
                                  FACE - VALUE 65
                                  COL 64 - VALUE 93
                                  FACE - VALUE 83
                                  FACE - VALUE 6
                                  FACE - VALUE 24
                                  ROW 57 - VALUE 38
                                  FACE - VALUE 62
                                  COL 8 - VALUE 27
                                  COL 79 - VALUE 61
                                  ROW 62 - VALUE 68
                                  COL 26 - VALUE 38
                                  ROW 48 - VALUE 36
                                  COL 43 - VALUE 21
                                  ROW 8 - VALUE 44
                                  COL 50 - VALUE 74
                                  ROW 13 - VALUE 97
                                  ROW 36 - VALUE 58
                                  ROW 4 - VALUE 45
                                  ROW 1 - VALUE 27
                                  ROW 72 - VALUE 86
                                  ROW 16 - VALUE 36
                                  FACE - VALUE 15
                                  COL 18 - VALUE 11
                                  FACE - VALUE 22
                                  COL 7 - VALUE 43
                                  ROW 11 - VALUE 30
                                  FACE - VALUE 99
                                  ROW 73 - VALUE 19
                                  COL 57 - VALUE 28
                                  COL 4 - VALUE 23
                                  COL 32 - VALUE 67
                                  ROW 37 - VALUE 2
                                  FACE - VALUE 30
                                  FACE - VALUE 28
                                  COL 2 - VALUE 54
                                  COL 74 - VALUE 69
                                  COL 17 - VALUE 85
                                  ROW 66 - VALUE 20
                                  FACE - VALUE 30
                                  ROW 44 - VALUE 90
                                  COL 25 - VALUE 12
                                  FACE - VALUE 66
                                  ROW 75 - VALUE 67
                                  ROW 60 - VALUE 89
                                  ROW 26 - VALUE 44
                                  ROW 2 - VALUE 81
                                  FACE - VALUE 29
                                  ROW 77 - VALUE 99
                                  ROW 25 - VALUE 13
                                  ROW 68 - VALUE 76
                                  COL 54 - VALUE 25
                                  FACE - VALUE 97
                                  COL 80 - VALUE 21
                                  ROW 38 - VALUE 30
                                  COL 64 - VALUE 45
                                  ROW 48 - VALUE 90
                                  ROW 16 - VALUE 2
                                  ROW 36 - VALUE 52
                                  ROW 27 - VALUE 90
                                  ROW 15 - VALUE 55
                                  COL 12 - VALUE 41
                                  COL 41 - VALUE 98
                                  COL 44 - VALUE 9
                                  FACE - VALUE 28
                                  COL 13 - VALUE 1
                                  ROW 44 - VALUE 43
                                  COL 8 - VALUE 79
                                  COL 48 - VALUE 94
                                  ROW 16 - VALUE 25
                                  COL 35 - VALUE 54
                                  COL 37 - VALUE 54
                                  ROW 60 - VALUE 49
                                  FACE - VALUE 87
                                  COL 69 - VALUE 75
                                  FACE - VALUE 30
                                  FACE - VALUE 7
                                  COL 62 - VALUE 79
                                  ROW 20 - VALUE 3
                                  COL 37 - VALUE 3
                                  COL 54 - VALUE 45
                                  FACE - VALUE 7
                                  ROW 65 - VALUE 15
                                  COL 44 - VALUE 15
                                  FACE - VALUE 3
                                  ROW 22 - VALUE 27
                                  COL 73 - VALUE 46
                                  FACE - VALUE 91
                                  ROW 78 - VALUE 18
                                  FACE - VALUE 79
                                  ROW 10 - VALUE 58
                                  FACE - VALUE 14
                                  COL 16 - VALUE 50
                                  ROW 44 - VALUE 20
                                  COL 64 - VALUE 33
                                  COL 71 - VALUE 16
                                  ROW 12 - VALUE 40
                                  FACE - VALUE 53
                                  FACE - VALUE 62
                                  FACE - VALUE 10
                                  COL 69 - VALUE 21
                                  FACE - VALUE 23
                                  COL 22 - VALUE 38
                                  ROW 73 - VALUE 23
                                  ROW 66 - VALUE 62
                                  COL 33 - VALUE 60
                                  COL 59 - VALUE 86
                                  COL 17 - VALUE 78
                                  COL 42 - VALUE 89
                                  FACE - VALUE 76
                                  COL 30 - VALUE 96
                                  ROW 9 - VALUE 57
                                  ROW 4 - VALUE 9
                                  COL 10 - VALUE 96
                                  ROW 59 - VALUE 48
                                  FACE - VALUE 37
                                  FACE - VALUE 59
                                  COL 48 - VALUE 62
                                  ROW 4 - VALUE 99
                                  FACE - VALUE 89
                                  COL 76 - VALUE 15
                                  FACE - VALUE 94
                                  ROW 5 - VALUE 65
                                  COL 73 - VALUE 45
                                  ROW 42 - VALUE 43
                                  COL 11 - VALUE 32
                                  COL 9 - VALUE 9
                                  ROW 33 - VALUE 71
                                  ROW 1 - VALUE 65
                                  ROW 36 - VALUE 66
                                  ROW 77 - VALUE 67
                                  COL 59 - VALUE 52
                                  FACE - VALUE 51
                                  ROW 62 - VALUE 91
                                  FACE - VALUE 28
                                  ROW 41 - VALUE 21
                                  ROW 19 - VALUE 38
                                  FACE - VALUE 4
                                  FACE - VALUE 8
                                  COL 53 - VALUE 1
                                  COL 29 - VALUE 86
                                  COL 24 - VALUE 65
                                  COL 11 - VALUE 16
                                  COL 74 - VALUE 88
                                  ROW 20 - VALUE 53
                                  FACE - VALUE 80
                                  ROW 78 - VALUE 5
                                  COL 48 - VALUE 22
                                  COL 71 - VALUE 57
                                  FACE - VALUE 74
                                  COL 78 - VALUE 61
                                  ROW 63 - VALUE 27
                                  FACE - VALUE 65
                                  COL 79 - VALUE 97
                                  COL 49 - VALUE 92
                                  ROW 3 - VALUE 1
                                  ROW 57 - VALUE 36
                                  ROW 77 - VALUE 19
                                  ROW 4 - VALUE 9
                                  ROW 67 - VALUE 29
                                  FACE - VALUE 58
                                  FACE - VALUE 84
                                  COL 77 - VALUE 21
                                  ROW 33 - VALUE 81
                                  COL 34 - VALUE 83
                                  ROW 80 - VALUE 7
                                  COL 41 - VALUE 61
                                  ROW 44 - VALUE 73
                                  COL 78 - VALUE 41
                                  FACE - VALUE 77
                                  FACE - VALUE 27
                                  ROW 59 - VALUE 8
                                  COL 6 - VALUE 10
                                  FACE - VALUE 4
                                  COL 35 - VALUE 97
                                  ROW 40 - VALUE 87
                                  COL 30 - VALUE 71
                                  ROW 75 - VALUE 7
                                  ROW 25 - VALUE 26
                                  COL 80 - VALUE 19
                                  ROW 11 - VALUE 12
                                  COL 20 - VALUE 81
                                  FACE - VALUE 37
                                  ROW 4 - VALUE 48
                                  ROW 15 - VALUE 95
                                  FACE - VALUE 53
                                  COL 47 - VALUE 69
                                  FACE - VALUE 42
                                  ROW 80 - VALUE 74
                                  COL 54 - VALUE 33
                                  ROW 61 - VALUE 30
                                  FACE - VALUE 67
                                  FACE - VALUE 54
                                  COL 45 - VALUE 44
                                  FACE - VALUE 86
                                  COL 45 - VALUE 61
                                  COL 53 - VALUE 25
                                  COL 47 - VALUE 69
                                  ROW 77 - VALUE 73
                                  FACE - VALUE 58
                                  ROW 29 - VALUE 89
                                  ROW 21 - VALUE 21
                                  FACE - VALUE 93
                                  COL 56 - VALUE 7
                                  FACE - VALUE 20
                                  FACE - VALUE 72
                                  COL 49 - VALUE 49
                                  COL 38 - VALUE 57
                                  ROW 16 - VALUE 17
                                  ROW 62 - VALUE 84
                                  ROW 5 - VALUE 4
                                  FACE - VALUE 68
                                  FACE - VALUE 3
                                  COL 65 - VALUE 76
                                  ROW 61 - VALUE 12
                                  FACE - VALUE 2
                                  COL 29 - VALUE 36
                                  FACE - VALUE 19
                                  COL 29 - VALUE 49
                                  COL 25 - VALUE 94
                                  COL 66 - VALUE 66
                                  ROW 67 - VALUE 12
                                  ROW 24 - VALUE 97
                                  ROW 41 - VALUE 71
                                  FACE - VALUE 81
                                  FACE - VALUE 66
                                  ROW 30 - VALUE 60
                                  COL 60 - VALUE 38
                                  COL 79 - VALUE 95
                                  FACE - VALUE 76
                                  ROW 9 - VALUE 1
                                  ROW 51 - VALUE 12
                                  FACE - VALUE 4
                                  ROW 31 - VALUE 93
                                  ROW 12 - VALUE 53
                                  FACE - VALUE 3
                                  ROW 72 - VALUE 66
                                  COL 75 - VALUE 23
                                  ROW 24 - VALUE 17
                                  ROW 61 - VALUE 90
                                  FACE - VALUE 7
                                  COL 24 - VALUE 97
                                  FACE - VALUE 54
                                  FACE - VALUE 46
                                  COL 69 - VALUE 37
                                  ROW 45 - VALUE 2
                                  FACE - VALUE 45
                                  ROW 50 - VALUE 42
                                  FACE - VALUE 57
                                  FACE - VALUE 98
                                  ROW 66 - VALUE 69
                                  COL 8 - VALUE 20
                                  COL 7 - VALUE 76
                                  ROW 60 - VALUE 99
                                  ROW 56 - VALUE 36
                                  FACE - VALUE 77
                                  COL 30 - VALUE 6
                                  COL 49 - VALUE 50
                                  ROW 2 - VALUE 20
                                  FACE - VALUE 80
                                  FACE - VALUE 21
                                  ROW 40 - VALUE 78
                                  ROW 53 - VALUE 15
                                  COL 58 - VALUE 83
                                  ROW 39 - VALUE 15
                                  ROW 66 - VALUE 61
                                  ROW 11 - VALUE 65
                                  ROW 1 - VALUE 50
                                  COL 51 - VALUE 5
                                  COL 71 - VALUE 33
                                  ROW 10 - VALUE 50
                                  FACE - VALUE 11
                                  FACE - VALUE 6
                                  FACE - VALUE 49
                                  ROW 12 - VALUE 68
                                  ROW 59 - VALUE 41
                                  COL 26 - VALUE 14
                                  COL 19 - VALUE 10
                                  ROW 35 - VALUE 8
                                  ROW 45 - VALUE 31
                                  COL 1 - VALUE 39
                                  FACE - VALUE 32
                                  FACE - VALUE 44
                                  COL 13 - VALUE 85
                                  COL 60 - VALUE 68
                                  FACE - VALUE 28
                                  ROW 49 - VALUE 4
                                  COL 13 - VALUE 50
                                  ROW 68 - VALUE 99
                                  ROW 70 - VALUE 78
                                  COL 29 - VALUE 87
                                  FACE - VALUE 20
                                  ROW 80 - VALUE 74
                                  ROW 35 - VALUE 38
                                  ROW 52 - VALUE 94
                                  FACE - VALUE 21
                                  ROW 29 - VALUE 17
                                  COL 58 - VALUE 67
                                  FACE - VALUE 11
                                  FACE - VALUE 69
                                  ROW 28 - VALUE 74
                                  FACE - VALUE 7
                                  ROW 54 - VALUE 54
                                  COL 26 - VALUE 78
                                  FACE - VALUE 73
                                  ROW 38 - VALUE 2
                                  ROW 9 - VALUE 18
                                  COL 75 - VALUE 31
                                  FACE - VALUE 27
                                  ROW 63 - VALUE 56
                                  ROW 23 - VALUE 24
                                  ROW 2 - VALUE 74
                                  COL 6 - VALUE 44
                                  ROW 50 - VALUE 34
                                  ROW 39 - VALUE 94
                                  ROW 79 - VALUE 7
                                  FACE - VALUE 45
                                  ROW 66 - VALUE 90
                                  COL 26 - VALUE 9
                                  ROW 65 - VALUE 56
                                  COL 57 - VALUE 29
                                  FACE - VALUE 49
                                  ROW 7 - VALUE 61
                                  ROW 14 - VALUE 44
                                  FACE - VALUE 59
                                  COL 28 - VALUE 35
                                  FACE - VALUE 46
                                  FACE - VALUE 24
                                  ROW 57 - VALUE 54
                                  ROW 27 - VALUE 7
                                  COL 13 - VALUE 71
                                  ROW 72 - VALUE 63
                                  FACE - VALUE 3
                                  ROW 29 - VALUE 81
                                  ROW 72 - VALUE 84
                                  FACE - VALUE 34
                                  COL 29 - VALUE 99
                                  COL 54 - VALUE 26
                                  ROW 79 - VALUE 17
                                  ROW 11 - VALUE 1
                                  COL 47 - VALUE 98
                                  COL 21 - VALUE 71
                                  COL 41 - VALUE 25
                                  ROW 5 - VALUE 19
                                  ROW 53 - VALUE 60
                                  COL 32 - VALUE 93
                                  ROW 52 - VALUE 87
                                  FACE - VALUE 63
                                  ROW 78 - VALUE 7
                                  COL 42 - VALUE 91
                                  FACE - VALUE 42
                                  FACE - VALUE 80
                                  FACE - VALUE 7
                                  ROW 37 - VALUE 38
                                  ROW 56 - VALUE 35
                                  ROW 41 - VALUE 69
                                  ROW 27 - VALUE 24
                                  ROW 52 - VALUE 65
                                  ROW 14 - VALUE 72
                                  FACE - VALUE 25
                                  ROW 62 - VALUE 12
                                  COL 5 - VALUE 9
                                  FACE - VALUE 67
                                  COL 62 - VALUE 94
                                  COL 55 - VALUE 73
                                  FACE - VALUE 38
                                  FACE - VALUE 75
                                  COL 80 - VALUE 65
                                  FACE - VALUE 24
                                  ROW 51 - VALUE 79
                                  ROW 28 - VALUE 8
                                  ROW 3 - VALUE 39
                                  COL 9 - VALUE 28
                                  FACE - VALUE 41
                                  COL 2 - VALUE 65
                                  COL 75 - VALUE 57
                                  ROW 23 - VALUE 30
                                  COL 37 - VALUE 32
                                  COL 73 - VALUE 9
                                  ROW 49 - VALUE 13
                                  FACE - VALUE 31
                                  ROW 9 - VALUE 60
                                  COL 13 - VALUE 68
                                  ROW 27 - VALUE 94
                                  COL 64 - VALUE 61
                                  ROW 50 - VALUE 15
                                  FACE - VALUE 88
                                  ROW 25 - VALUE 39
                                  COL 2 - VALUE 60
                                  FACE - VALUE 76
                                  ROW 5 - VALUE 98
                                  COL 77 - VALUE 75
                                  ROW 29 - VALUE 2
                                  COL 31 - VALUE 2
                                  COL 38 - VALUE 13
                                  FACE - VALUE 67
                                  COL 18 - VALUE 2
                                  ROW 17 - VALUE 10
                                  FACE - VALUE 61
                                  COL 9 - VALUE 37
                                  ROW 58 - VALUE 9
                                  COL 27 - VALUE 92
                                  ROW 23 - VALUE 7
                                  ROW 70 - VALUE 43
                                  COL 27 - VALUE 8
                                  ROW 53 - VALUE 21
                                  COL 57 - VALUE 14
                                  ROW 37 - VALUE 79
                                  ROW 68 - VALUE 68
                                  ROW 59 - VALUE 20
                                  ROW 37 - VALUE 54
                                  FACE - VALUE 62
                                  ROW 65 - VALUE 79
                                  COL 18 - VALUE 63
                                  COL 48 - VALUE 94
                                  FACE - VALUE 85
                                  ROW 71 - VALUE 70
                                  COL 59 - VALUE 76
                                  COL 31 - VALUE 66
                                  ROW 58 - VALUE 90
                                  ROW 19 - VALUE 15
                                  COL 73 - VALUE 85
                                  COL 67 - VALUE 46
                                  ROW 44 - VALUE 66
                                  COL 28 - VALUE 62
                                  ROW 10 - VALUE 91
                                  COL 57 - VALUE 40
                                  ROW 52 - VALUE 25
                                  ROW 44 - VALUE 21
                                  ROW 76 - VALUE 41
                                  COL 56 - VALUE 10
                                  COL 36 - VALUE 71
                                  COL 42 - VALUE 69
                                  COL 10 - VALUE 49
                                  COL 35 - VALUE 87
                                  COL 16 - VALUE 41
                                  ROW 50 - VALUE 18
                                  COL 15 - VALUE 98
                                  FACE - VALUE 92
                                  COL 46 - VALUE 90
                                  COL 45 - VALUE 69
                                  COL 63 - VALUE 70
                                  ROW 8 - VALUE 79
                                  FACE - VALUE 34
                                  FACE - VALUE 42
                                  ROW 32 - VALUE 45
                                  FACE - VALUE 45
                                  FACE - VALUE 42
                                  ROW 55 - VALUE 27
                                  ROW 42 - VALUE 81
                                  FACE - VALUE 58
                                  ROW 57 - VALUE 26
                                  ROW 70 - VALUE 51
                                  COL 74 - VALUE 20
                                  FACE - VALUE 96
                                  ROW 47 - VALUE 82
                                  ROW 73 - VALUE 68
                                  COL 12 - VALUE 67
                                  COL 5 - VALUE 30
                                  FACE - VALUE 33
                                  ROW 27 - VALUE 49
                                  ROW 26 - VALUE 98
                                  ROW 51 - VALUE 27
                                  FACE - VALUE 49
                                  FACE - VALUE 34
                                  COL 56 - VALUE 39
                                  COL 42 - VALUE 21
                                  COL 49 - VALUE 27
                                  COL 11 - VALUE 78
                                  COL 13 - VALUE 32
                                  ROW 72 - VALUE 82
                                  COL 31 - VALUE 20
                                  FACE - VALUE 74
                                  ROW 42 - VALUE 97
                                  COL 38 - VALUE 17
                                  COL 29 - VALUE 79
                                  FACE - VALUE 43
                                  COL 32 - VALUE 5
                                  COL 22 - VALUE 4
                                  COL 36 - VALUE 7
                                  ROW 20 - VALUE 9
                                  COL 40 - VALUE 80
                                  COL 20 - VALUE 19
                                  COL 11 - VALUE 16
                                  FACE - VALUE 69
                                  COL 32 - VALUE 93
                                  FACE - VALUE 96
                                  ROW 10 - VALUE 20
                                  FACE - VALUE 72
                                  COL 21 - VALUE 34
                                  COL 55 - VALUE 64
                                  ROW 52 - VALUE 51
                                  ROW 76 - VALUE 6
                                  COL 45 - VALUE 38
                                  COL 15 - VALUE 21
                                  COL 37 - VALUE 37
                                  ROW 38 - VALUE 85
                                  COL 37 - VALUE 65
                                  ROW 78 - VALUE 47
                                  COL 63 - VALUE 35
                                  ROW 13 - VALUE 73
                                  ROW 16 - VALUE 37
                                  FACE - VALUE 58
                                  COL 75 - VALUE 42
                                  FACE - VALUE 47
                                  COL 64 - VALUE 81
                                  ROW 23 - VALUE 25
                                  ROW 5 - VALUE 74
                                  FACE - VALUE 24
                                  ROW 31 - VALUE 55
                                  FACE - VALUE 25
                                  ROW 56 - VALUE 9
                                  ROW 39 - VALUE 85
                                  ROW 16 - VALUE 6
                                  ROW 13 - VALUE 94
                                  ROW 19 - VALUE 93
                                  ROW 31 - VALUE 33
                                  COL 13 - VALUE 18
                                  ROW 21 - VALUE 21
                                  ROW 1 - VALUE 62
                                  COL 48 - VALUE 57
                                  COL 44 - VALUE 19
                                  COL 79 - VALUE 51
                                  COL 6 - VALUE 82
                                  COL 20 - VALUE 97
                                  COL 30 - VALUE 61
                                  ROW 50 - VALUE 19
                                  COL 64 - VALUE 25
                                  COL 70 - VALUE 30
                                  ROW 16 - VALUE 7
                                  COL 12 - VALUE 64
                                  COL 48 - VALUE 69
                                  ROW 20 - VALUE 15
                                  ROW 30 - VALUE 88
                                  FACE - VALUE 36
                                  FACE - VALUE 59
                                  COL 77 - VALUE 18
                                  FACE - VALUE 34
                                  FACE - VALUE 85
                                  ROW 69 - VALUE 63
                                  ROW 12 - VALUE 57
                                  ROW 8 - VALUE 37
                                  ROW 26 - VALUE 26
                                  FACE - VALUE 62
                                  COL 53 - VALUE 39
                                  FACE - VALUE 36
                                  ROW 15 - VALUE 77
                                  COL 69 - VALUE 91
                                  ROW 76 - VALUE 22
                                  FACE - VALUE 58
                                  ROW 60 - VALUE 94
                                  FACE - VALUE 3
                                  ROW 13 - VALUE 31
                                  COL 35 - VALUE 12
                                  ROW 58 - VALUE 54
                                  ROW 62 - VALUE 80
                                  COL 46 - VALUE 11
                                  FACE - VALUE 1
                                  COL 11 - VALUE 31
                                  COL 14 - VALUE 69
                                  COL 44 - VALUE 22
                                  FACE - VALUE 71
                                  FACE - VALUE 46
                                  FACE - VALUE 83
                                  COL 79 - VALUE 55
                                  ROW 43 - VALUE 29
                                  FACE - VALUE 6
                                  ROW 8 - VALUE 50
                                  COL 58 - VALUE 60
                                  COL 69 - VALUE 24
                                  ROW 64 - VALUE 40
                                  COL 60 - VALUE 98
                                  ROW 77 - VALUE 34
                                  COL 79 - VALUE 99
                                  COL 71 - VALUE 35
                                  FACE - VALUE 63
                                  FACE - VALUE 80
                                  ROW 78 - VALUE 32
                                  ROW 20 - VALUE 4
                                  COL 27 - VALUE 93
                                  FACE - VALUE 37
                                  COL 9 - VALUE 74
                                  ROW 71 - VALUE 26
                                  COL 73 - VALUE 85
                                  ROW 42 - VALUE 37
                                  ROW 67 - VALUE 97
                                  ROW 73 - VALUE 13
                                  ROW 50 - VALUE 67
                                  COL 52 - VALUE 57
                                  FACE - VALUE 49
                                  ROW 20 - VALUE 2
                                  FACE - VALUE 90
                                  COL 58 - VALUE 95
                                  ROW 15 - VALUE 2
                                  FACE - VALUE 85
                                  ROW 13 - VALUE 27
                                  FACE - VALUE 91
                                  COL 39 - VALUE 91
                                  COL 34 - VALUE 97
                                  COL 7 - VALUE 20
                                  COL 33 - VALUE 86
                                  FACE - VALUE 27
                                  ROW 30 - VALUE 85
                                  ROW 4 - VALUE 79
                                  FACE - VALUE 88
                                  FACE - VALUE 27
                                  ROW 40 - VALUE 57
                                  ROW 55 - VALUE 6
                                  ROW 4 - VALUE 31
                                  COL 48 - VALUE 70
                                  FACE - VALUE 66
                                  FACE - VALUE 89
                                  COL 22 - VALUE 19
                                  ROW 80 - VALUE 23
                                  ROW 67 - VALUE 12
                                  COL 65 - VALUE 17
                                  FACE - VALUE 36
                                  COL 19 - VALUE 97
                                  ROW 15 - VALUE 93
                                  COL 49 - VALUE 82
                                  COL 22 - VALUE 63
                                  COL 46 - VALUE 29
                                  FACE - VALUE 62
                                  FACE - VALUE 98
                                  COL 2 - VALUE 64
                                  FACE - VALUE 96
                                  ROW 28 - VALUE 3
                                  ROW 17 - VALUE 17
                                  FACE - VALUE 60
                                  COL 8 - VALUE 41
                                  FACE - VALUE 32
                                  ROW 13 - VALUE 62
                                  ROW 20 - VALUE 6
                                  ROW 67 - VALUE 1
                                  COL 9 - VALUE 1
                                  FACE - VALUE 90
                                  COL 56 - VALUE 92
                                  COL 48 - VALUE 94
                                  COL 72 - VALUE 36
                                  ROW 46 - VALUE 5
                                  ROW 64 - VALUE 43
                                  ROW 11 - VALUE 95
                                  COL 70 - VALUE 53
                                  FACE - VALUE 72
                                  COL 43 - VALUE 71
                                  COL 7 - VALUE 4
                                  ROW 57 - VALUE 32
                                  ROW 57 - VALUE 89
                                  ROW 51 - VALUE 5
                                  COL 24 - VALUE 99
                                  FACE - VALUE 63
                                  ROW 67 - VALUE 18
                                  COL 34 - VALUE 17
                                  FACE - VALUE 63
                                  FACE - VALUE 58
                                  FACE - VALUE 9
                                  COL 77 - VALUE 69
                                  ROW 60 - VALUE 82
                                  ROW 65 - VALUE 30
                                  COL 4 - VALUE 10
                                  ROW 71 - VALUE 5
                                  FACE - VALUE 41
                                  ROW 56 - VALUE 44
                                  COL 5 - VALUE 42
                                  ROW 30 - VALUE 39
                                  FACE - VALUE 59
                                  COL 17 - VALUE 51
                                  COL 25 - VALUE 40
                                  COL 2 - VALUE 64
                                  COL 15 - VALUE 36
                                  ROW 60 - VALUE 28
                                  ROW 51 - VALUE 53
                                  ROW 28 - VALUE 77
                                  COL 74 - VALUE 68
                                  ROW 34 - VALUE 37
                                  ROW 38 - VALUE 64
                                  COL 8 - VALUE 65
                                  FACE - VALUE 7
                                  FACE - VALUE 73
                                  ROW 79 - VALUE 14
                                  COL 61 - VALUE 5
                                  COL 2 - VALUE 14
                                  ROW 65 - VALUE 69
                                  FACE - VALUE 40
                                  COL 16 - VALUE 37
                                  ROW 80 - VALUE 74
                                  ROW 33 - VALUE 94
                                  ROW 52 - VALUE 87
                                  COL 74 - VALUE 75
                                  ROW 77 - VALUE 61
                                  COL 20 - VALUE 67
                                  COL 61 - VALUE 46
                                  COL 60 - VALUE 83
                                  ROW 36 - VALUE 19
                                  ROW 50 - VALUE 2
                                  FACE - VALUE 93
                                  ROW 51 - VALUE 55
                                  ROW 38 - VALUE 86
                                  COL 21 - VALUE 84
                                  COL 38 - VALUE 7
                                  COL 1 - VALUE 75
                                  FACE - VALUE 92
                                  FACE - VALUE 19
                                  FACE - VALUE 36
                                  COL 29 - VALUE 92
                                  ROW 28 - VALUE 27
                                  FACE - VALUE 2
                                  FACE - VALUE 28
                                  COL 38 - VALUE 42
                                  COL 75 - VALUE 54
                                  COL 15 - VALUE 25
                                  COL 38 - VALUE 66
                                  COL 35 - VALUE 77
                                  ROW 62 - VALUE 72
                                  FACE - VALUE 17
                                  ROW 40 - VALUE 55
                                  ROW 60 - VALUE 60
                                  COL 16 - VALUE 90
                                  COL 4 - VALUE 99
                                  COL 12 - VALUE 2
                                  FACE - VALUE 41
                                  COL 70 - VALUE 35
                                  FACE - VALUE 96
                                  COL 57 - VALUE 85
                                  FACE - VALUE 6
                                  ROW 46 - VALUE 86
                                  ROW 66 - VALUE 70
                                  COL 12 - VALUE 15
                                  FACE - VALUE 2
                                  ROW 56 - VALUE 98
                                  COL 54 - VALUE 56
                                  FACE - VALUE 43
                                  ROW 27 - VALUE 95
                                  FACE - VALUE 87
                                  ROW 68 - VALUE 7
                                  ROW 54 - VALUE 75
                                  COL 34 - VALUE 44
                                  ROW 57 - VALUE 10
                                  COL 24 - VALUE 2
                                  FACE - VALUE 15
                                  COL 63 - VALUE 21
                                  ROW 80 - VALUE 97
                                  ROW 46 - VALUE 7
                                  FACE - VALUE 8
                                  ROW 33 - VALUE 15
                                  ROW 64 - VALUE 68
                                  ROW 76 - VALUE 6
                                  COL 64 - VALUE 67
                                  ROW 6 - VALUE 41
                                  FACE - VALUE 9
                                  COL 58 - VALUE 17
                                  COL 13 - VALUE 5
                                  ROW 9 - VALUE 74
                                  COL 31 - VALUE 27
                                  FACE - VALUE 80
                                  COL 43 - VALUE 19
                                  COL 29 - VALUE 8
                                  COL 70 - VALUE 8
                                  ROW 30 - VALUE 10
                                  FACE - VALUE 61
                                  FACE - VALUE 47
                                  ROW 43 - VALUE 39
                                  COL 22 - VALUE 58
                                  COL 31 - VALUE 28
                                  COL 39 - VALUE 25
                                  COL 35 - VALUE 31
                                  FACE - VALUE 74
                                  ROW 40 - VALUE 92
                                  FACE - VALUE 64
                                  ROW 31 - VALUE 20
                                  ROW 68 - VALUE 29
                                  COL 79 - VALUE 8
                                  COL 4 - VALUE 1
                                  ROW 52 - VALUE 4
                                  FACE - VALUE 41
                                  FACE - VALUE 18
                                  FACE - VALUE 2
                                  ROW 53 - VALUE 49
                                  ROW 79 - VALUE 22
                                  FACE - VALUE 36
                                  FACE - VALUE 75
                                  COL 64 - VALUE 62
                                  ROW 67 - VALUE 46
                                  FACE - VALUE 82
                                  FACE - VALUE 91
                                  ROW 21 - VALUE 21
                                  ROW 4 - VALUE 58
                                  FACE - VALUE 12
                                  FACE - VALUE 67
                                  ROW 72 - VALUE 79
                                  FACE - VALUE 34
                                  ROW 16 - VALUE 68
                                  ROW 41 - VALUE 25
                                  ROW 9 - VALUE 92
                                  ROW 16 - VALUE 55
                                  ROW 9 - VALUE 3
                                  ROW 5 - VALUE 11
                                  FACE - VALUE 52
                                  FACE - VALUE 1
                                  ROW 34 - VALUE 20
                                  ROW 41 - VALUE 75
                                  FACE - VALUE 65
                                  COL 64 - VALUE 93
                                  FACE - VALUE 83
                                  FACE - VALUE 6
                                  FACE - VALUE 24
                                  ROW 57 - VALUE 38
                                  FACE - VALUE 62
                                  COL 8 - VALUE 27
                                  COL 79 - VALUE 61
                                  ROW 62 - VALUE 68
                                  COL 26 - VALUE 38
                                  ROW 48 - VALUE 36
                                  COL 43 - VALUE 21
                                  ROW 8 - VALUE 44
                                  COL 50 - VALUE 74
                                  ROW 13 - VALUE 97
                                  ROW 36 - VALUE 58
                                  ROW 4 - VALUE 45
                                  ROW 1 - VALUE 27
                                  ROW 72 - VALUE 86
                                  ROW 16 - VALUE 36
                                  FACE - VALUE 15
                                  COL 18 - VALUE 11
                                  FACE - VALUE 22
                                  COL 7 - VALUE 43
                                  ROW 11 - VALUE 30
                                  FACE - VALUE 99
                                  ROW 73 - VALUE 19
                                  COL 57 - VALUE 28
                                  COL 4 - VALUE 23
                                  COL 32 - VALUE 67
                                  ROW 37 - VALUE 2
                                  FACE - VALUE 30
                                  FACE - VALUE 28
                                  COL 2 - VALUE 54
                                  COL 74 - VALUE 69
                                  COL 17 - VALUE 85
                                  ROW 66 - VALUE 20
                                  FACE - VALUE 30
                                  ROW 44 - VALUE 90
                                  COL 25 - VALUE 12
                                  FACE - VALUE 66
                                  ROW 75 - VALUE 67
                                  ROW 60 - VALUE 89
                                  ROW 26 - VALUE 44
                                  ROW 2 - VALUE 81
                                  FACE - VALUE 29
                                  ROW 77 - VALUE 99
                                  ROW 25 - VALUE 13
                                  ROW 68 - VALUE 76
                                  COL 54 - VALUE 25
                                  FACE - VALUE 97
                                  COL 80 - VALUE 21
                                  ROW 38 - VALUE 30
                                  COL 64 - VALUE 45
                                  ROW 48 - VALUE 90
                                  ROW 16 - VALUE 2
                                  ROW 36 - VALUE 52
                                  ROW 27 - VALUE 90
                                  ROW 15 - VALUE 55
                                  COL 12 - VALUE 41
                                  COL 41 - VALUE 98
                                  COL 44 - VALUE 9
                                  FACE - VALUE 28
                                  COL 13 - VALUE 1
                                  ROW 44 - VALUE 43
                                  COL 8 - VALUE 79
                                  COL 48 - VALUE 94
                                  ROW 16 - VALUE 25
                                  COL 35 - VALUE 54
                                  COL 37 - VALUE 54
                                  ROW 60 - VALUE 49
                                  FACE - VALUE 87
                                  COL 69 - VALUE 75
                                  FACE - VALUE 30
                                  FACE - VALUE 7
                                  COL 62 - VALUE 79
                                  ROW 20 - VALUE 3
                                  COL 37 - VALUE 3
                                  COL 54 - VALUE 45
                                  FACE - VALUE 7
                                  ROW 65 - VALUE 15
                                  COL 44 - VALUE 15
                                  FACE - VALUE 3
                                  ROW 22 - VALUE 27
                                  COL 73 - VALUE 46
                                  FACE - VALUE 91
                                  ROW 78 - VALUE 18
                                  FACE - VALUE 79
                                  ROW 10 - VALUE 58
                                  FACE - VALUE 14
                                  COL 16 - VALUE 50
                                  ROW 44 - VALUE 20
                                  COL 64 - VALUE 33
                                  COL 71 - VALUE 16
                                  ROW 12 - VALUE 40
                                  FACE - VALUE 53
                                  FACE - VALUE 62
                                  FACE - VALUE 10
                                  COL 69 - VALUE 21
                                  FACE - VALUE 23
                                  COL 22 - VALUE 38
                                  ROW 73 - VALUE 23
                                  ROW 66 - VALUE 62
                                  COL 33 - VALUE 60
                                  COL 59 - VALUE 86
                                  COL 17 - VALUE 78
                                  COL 42 - VALUE 89
                                  FACE - VALUE 76
                                  COL 30 - VALUE 96
                                  ROW 9 - VALUE 57
                                  ROW 4 - VALUE 9
                                  COL 10 - VALUE 96
                                  ROW 59 - VALUE 48
                                  FACE - VALUE 37
                                  FACE - VALUE 59
                                  COL 48 - VALUE 62
                                  ROW 4 - VALUE 99
                                  FACE - VALUE 89
                                  COL 76 - VALUE 15
                                  FACE - VALUE 94
                                  ROW 5 - VALUE 65
                                  COL 73 - VALUE 45
                                  ROW 42 - VALUE 43
                                  COL 11 - VALUE 32
                                  COL 9 - VALUE 9
                                  ROW 33 - VALUE 71
                                  ROW 1 - VALUE 65
                                  ROW 36 - VALUE 66
                                  ROW 77 - VALUE 67
                                  COL 59 - VALUE 52
                                  FACE - VALUE 51
                                  ROW 62 - VALUE 91
                                  FACE - VALUE 28
                                  ROW 41 - VALUE 21
                                  ROW 19 - VALUE 38
                                  FACE - VALUE 4
                                  FACE - VALUE 8
                                  COL 53 - VALUE 1
                                  COL 29 - VALUE 86
                                  COL 24 - VALUE 65
                                  COL 11 - VALUE 16
                                  COL 74 - VALUE 88
                                  ROW 20 - VALUE 53
                                  FACE - VALUE 80
                                  ROW 78 - VALUE 5
                                  COL 48 - VALUE 22
                                  COL 71 - VALUE 57
                                  FACE - VALUE 74
                                  COL 78 - VALUE 61
                                  ROW 63 - VALUE 27
                                  FACE - VALUE 65
                                  COL 79 - VALUE 97
                                  COL 49 - VALUE 92
                                  ROW 3 - VALUE 1
                                  ROW 57 - VALUE 36
                                  ROW 77 - VALUE 19
                                  ROW 4 - VALUE 9
                                  ROW 67 - VALUE 29
                                  FACE - VALUE 58
                                  FACE - VALUE 84
                                  COL 77 - VALUE 21
                                  ROW 33 - VALUE 81
                                  COL 34 - VALUE 83
                                  ROW 80 - VALUE 7
                                  COL 41 - VALUE 61
                                  ROW 44 - VALUE 73
                                  COL 78 - VALUE 41
                                  FACE - VALUE 77
                                  FACE - VALUE 27
                                  ROW 59 - VALUE 8
                                  COL 6 - VALUE 10
                                  FACE - VALUE 4
                                  COL 35 - VALUE 97
                                  ROW 40 - VALUE 87
                                  COL 30 - VALUE 71
                                  ROW 75 - VALUE 7
                                  ROW 25 - VALUE 26
                                  COL 80 - VALUE 19
                                  ROW 11 - VALUE 12
                                  COL 20 - VALUE 81
                                  FACE - VALUE 37
                                  ROW 4 - VALUE 48
                                  ROW 15 - VALUE 95
                                  FACE - VALUE 53
                                  COL 47 - VALUE 69
                                  FACE - VALUE 42
                                  ROW 80 - VALUE 74
                                  COL 54 - VALUE 33
                                  ROW 61 - VALUE 30
                                  FACE - VALUE 67
                                  FACE - VALUE 54
                                  COL 45 - VALUE 44
                                  FACE - VALUE 86
                                  COL 45 - VALUE 61
                                  COL 53 - VALUE 25
                                  COL 47 - VALUE 69
                                  ROW 77 - VALUE 73
                                  FACE - VALUE 58
                                  ROW 29 - VALUE 89
                                  ROW 21 - VALUE 21
                                  FACE - VALUE 93
                                  COL 56 - VALUE 7
                                  FACE - VALUE 20
                                  FACE - VALUE 72
                                  COL 49 - VALUE 49
                                  COL 38 - VALUE 57
                                  ROW 16 - VALUE 17
                                  ROW 62 - VALUE 84
                                  ROW 5 - VALUE 4
                                  FACE - VALUE 68
                                  FACE - VALUE 3
                                  COL 65 - VALUE 76
                                  ROW 61 - VALUE 12
                                  FACE - VALUE 2
                                  COL 29 - VALUE 36
                                  FACE - VALUE 19
                                  COL 29 - VALUE 49
                                  COL 25 - VALUE 94
                                  COL 66 - VALUE 66
                                  ROW 67 - VALUE 12
                                  ROW 24 - VALUE 97
                                  ROW 41 - VALUE 71
                                  FACE - VALUE 81
                                  FACE - VALUE 66
                                  ROW 30 - VALUE 60
                                  COL 60 - VALUE 38
                                  COL 79 - VALUE 95
                                  FACE - VALUE 76
                                  ROW 9 - VALUE 1
                                  ROW 51 - VALUE 12
                                  FACE - VALUE 4
                                  ROW 31 - VALUE 93
                                  ROW 12 - VALUE 53
                                  FACE - VALUE 3
                                  ROW 72 - VALUE 66
                                  COL 75 - VALUE 23
                                  ROW 24 - VALUE 17
                                  ROW 61 - VALUE 90
                                  FACE - VALUE 7
                                  COL 24 - VALUE 97
                                  FACE - VALUE 54
                                  FACE - VALUE 46
                                  COL 69 - VALUE 37
                                  ROW 45 - VALUE 2
                                  FACE - VALUE 45
                                  ROW 50 - VALUE 42
                                  FACE - VALUE 57
                                  FACE - VALUE 98
                                  ROW 66 - VALUE 69
                                  COL 8 - VALUE 20
                                  COL 7 - VALUE 76
                                  ROW 60 - VALUE 99
                                  ROW 56 - VALUE 36
                                  FACE - VALUE 77
                                  COL 30 - VALUE 6
                                  COL 49 - VALUE 50
                                  ROW 2 - VALUE 20
                                  FACE - VALUE 80
                                  FACE - VALUE 21
                                  ROW 40 - VALUE 78
                                  ROW 53 - VALUE 15
                                  COL 58 - VALUE 83
                                  ROW 39 - VALUE 15
                                  ROW 66 - VALUE 61
                                  ROW 11 - VALUE 65
                                  ROW 1 - VALUE 50
                                  COL 51 - VALUE 5
                                  COL 71 - VALUE 33
                                  ROW 10 - VALUE 50
                                  FACE - VALUE 11
                                  FACE - VALUE 6
                                  FACE - VALUE 49
                                  ROW 12 - VALUE 68
                                  ROW 59 - VALUE 41
                                  COL 26 - VALUE 14
                                  COL 19 - VALUE 10
                                  ROW 35 - VALUE 8
                                  ROW 45 - VALUE 31
                                  COL 1 - VALUE 39
                                  FACE - VALUE 32
                                  FACE - VALUE 44
                                  COL 13 - VALUE 85
                                  COL 60 - VALUE 68
                                  FACE - VALUE 28
                                  ROW 49 - VALUE 4
                                  COL 13 - VALUE 50
                                  ROW 68 - VALUE 99
                                  ROW 70 - VALUE 78
                                  COL 29 - VALUE 87
                                  FACE - VALUE 20
                                  ROW 80 - VALUE 74
                                  ROW 35 - VALUE 38
                                  ROW 52 - VALUE 94
                                  FACE - VALUE 21
                                  ROW 29 - VALUE 17
                                  COL 58 - VALUE 67
                                  FACE - VALUE 11
                                  FACE - VALUE 69
                                  ROW 28 - VALUE 74
                                  FACE - VALUE 7
                                  ROW 54 - VALUE 54
                                  COL 26 - VALUE 78
                                  FACE - VALUE 73
                                  ROW 38 - VALUE 2
                                  ROW 9 - VALUE 18
                                  COL 75 - VALUE 31
                                  FACE - VALUE 27
                                  ROW 63 - VALUE 56
                                  ROW 23 - VALUE 24
                                  ROW 2 - VALUE 74
                                  COL 6 - VALUE 44
                                  ROW 50 - VALUE 34
                                  ROW 39 - VALUE 94
                                  ROW 79 - VALUE 7
                                  FACE - VALUE 45
                                  ROW 66 - VALUE 90
                                  COL 26 - VALUE 9
                                  ROW 65 - VALUE 56
                                  COL 57 - VALUE 29
                                  FACE - VALUE 49
                                  ROW 7 - VALUE 61
                                  ROW 14 - VALUE 44
                                  FACE - VALUE 59
                                  COL 28 - VALUE 35
                                  FACE - VALUE 46
                                  FACE - VALUE 24
                                  ROW 57 - VALUE 54
                                  ROW 27 - VALUE 7
                                  COL 13 - VALUE 71
                                  ROW 72 - VALUE 63
                                  FACE - VALUE 3
                                  ROW 29 - VALUE 81
                                  ROW 72 - VALUE 84
                                  FACE - VALUE 34
                                  COL 29 - VALUE 99
                                  COL 54 - VALUE 26
                                  ROW 79 - VALUE 17
                                  ROW 11 - VALUE 1
                                  COL 47 - VALUE 98
                                  COL 21 - VALUE 71
                                  COL 41 - VALUE 25
                                  ROW 5 - VALUE 19
                                  ROW 53 - VALUE 60
                                  COL 32 - VALUE 93
                                  ROW 52 - VALUE 87
                                  FACE - VALUE 63
                                  ROW 78 - VALUE 7
                                  COL 42 - VALUE 91
                                  FACE - VALUE 42
                                  FACE - VALUE 80
                                  FACE - VALUE 7
                                  ROW 37 - VALUE 38
                                  ROW 56 - VALUE 35
                                  ROW 41 - VALUE 69
                                  ROW 27 - VALUE 24
                                  ROW 52 - VALUE 65
                                  ROW 14 - VALUE 72
                                  FACE - VALUE 25
                                  ROW 62 - VALUE 12
                                  COL 5 - VALUE 9
                                  FACE - VALUE 67
                                  COL 62 - VALUE 94
                                  COL 55 - VALUE 73
                                  FACE - VALUE 38
                                  FACE - VALUE 75
                                  COL 80 - VALUE 65
                                  FACE - VALUE 24
                                  ROW 51 - VALUE 79
                                  ROW 28 - VALUE 8
                                  ROW 3 - VALUE 39
                                  COL 9 - VALUE 28
                                  FACE - VALUE 41
                                  COL 2 - VALUE 65
                                  COL 75 - VALUE 57
                                  ROW 23 - VALUE 30
                                  COL 37 - VALUE 32
                                  
                                  LLDRDRDUUDLRDRRDURUDDLRDLDDRLRDULLDRURURULLULRDRULDULDDDURRRRRLRULDLRDUUDLLRULDLLRRDLDUDRLUULRRDLRLLULLURUUUDLLDUDRLDLLDRDDRLDLRDRRURUDLRUULLDLRLRLDRURUUDLURLDRURLULLLDRULLLURLLUULLUUDULURRLUUDURURRDRLURDLUULDLRUULRUUUDDLULDUULRURUDDRUUDDRLLUUDDRUDRRRUDULRRURDLRLRLLLDRUDLDLDDLUULURLRDULUUUDRLRRULDULUDLLLLRRUDLRLRRRULDUDRRRDLLUDLLLLURDRLDDUURDLULLRRRDLLRUUUULLLLRRLDDURRLULRRDLRLRDRRLLRDDRRUDLRDLUUDUDURRLDLLUUULDDDULRURLRDDUDLLURDRUURDDURURRLDLUUUUURRLDDLDRRUUUUDRLRDRURUDLDDDULRLUULDDDDDLLLULDDLDURLDURDDRULDDUUDLRUUDRLLLRRUURDDLULRUULRDULUUUDRLURDLDRLDLUDRULDULDLURLRDURLRDULRLLRRRDDLRLLLDDRLLRDRLDDULURUDDRLDLLRLUUDUURLRDULLRUDUDRLRRDUUURDULLRULUDUDDRRDDRDUDUDRLLUDLLDRUDRRURRRDUUURDUUDDLDLDLDLLRURURDRURRRULDUURULRDRURUDRRLUDLDRRLURLRRDLUDLUUUURDLRDRDRDURRDRULRLDLLDLLUUDLUDLDLLRULLLRLLUUUUDDDLLDRDRDUUDLRDRRDURUDDLRDLDDRLRDULLDRURURULLULRDRULDULDDDURRRRRLRULDLRDUUDLLRULDLLRRDLDUDRLUULRRDLRLLULLURUUUDLLDUDRLDLLDRDDRLDLRDRRURUDLRUULLDLRLRLDRURUUDLURLDRURLULLLDRULLLURLLUULLUUDULURRLUUDURURRDRLURDLUULDLRUULRUUUDDLULDUULRURUDDRUUDDRLLUUDDRUDRRRUDULRRURDLRLRLLLDRUDLDLDDLUULURLRDULUUUDRLRRULDULUDLLLLRRUDLRLRRRULDUDRRRDLLUDLLLLURDRLDDUURDLULLRRRDLLRUUUULLLLRRLDDURRLULRRDLRLRDRRLLRDDRRUDLRDLUUDUDURRLDLLUUULDDDULRURLRDDUDLLURDRUURDDURURRLDLUUUUURRLDDLDRRUUUUDRLRDRURUDLDDDULRLUULDDDDDLLLULDDLDURLDURDDRULDDUUDLRUUDRLLLRRUURDDLULRUULRDULUUUDRLURDLDRLDLUDRULDULDLURLRDURLRDULRLLRRRDDLRLLLDDRLLRDRLDDULURUDDRLDLLRLUUDUURLRDULLRUDUDRLRRDUUURDULLRULUDUDDRRDDRDUDUDRLLUDLLDRUDRRURRRDUUURDUUDDLDLDLDLLRURURDRURRRULDUURULRDRURUDRRLUDLDRRLURLRRDLUDLUUUURDLRDRDRDURRDRULRLDLLDDLLUUDLUDLDLLRULLLRLLUUUUDDD
                                  """;

    [Test]
    public void Part1() => Sut.RunPart1(Input1, 3).Should().Be(201474);

    [Test]
    public void Part2_1() => Sut.RunPart2(Input1, 3).Should().Be(118727856);
    
    [Test]
    public void Part2_2() => Sut.RunPart2(Input2, 80).Should().Be(BigInteger.Parse("369594451623936000000"));
    
    [Test]
    public void Part2_3() => Sut.RunPart2(Input3, 80).Should().Be(BigInteger.Parse("41477439119464857600000"));
    
    [Test]
    public void Part2_4() => Sut.RunPart2(Input4, 80).Should().Be(BigInteger.Parse("27223044405703882350160"));

    [Test]
    public void Part3() => Sut.Part3(Input1).Answer.Should().Be("0");

    private static Codyssi202516 Sut => new();
}