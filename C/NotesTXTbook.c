/* All programs must have a main() with no arguments, that's where the program starts

Saving a file as ".c" is the C source code - must be compiled into an executable then run by typing the new name into the command line

Comments indicated by "/*"

Variables must be declared

A #define line creates a symbolic constant (#define LOWER 30)
	• LOWER will always be replaced with 30
	• Included at top of program, before main() or any functions are called

	A text stream is a sequence of characters divided into lines; each line consists of zero or more characters followed by a newline character.
	• C = getchar(); reads the next input character each time it is called
		○ Symbolic int EOF represents the value getchar() receives when it has reached the end of a file
	• Putchar(c); outputs the next character each time it is called

OR is represented by ||, AND by &&

Function structure is as follows:
	return-type function-name(parameter declarations, if any)
	{
	declarations
	statements
	}

Good practice to "return 0;" at the end of all "main" functions as a status note to show normal operation

Null character = '\0' whose value is zero

The usual practice is to collect extern declarations of variables and functions in a separate file, historically called a header, that is included by #include at the front of each source file. The suffix .h is conventional for header names. The functions of the standard library, for example, are declared in headers like <stdio.h>. 
	• GREAT EXERCISES ON PAGE 34

Don't begin variable names with underscore, however, since library routines often use such names. Upper and lower case letters are distinct, so x and X are two different names. Traditional C practice is to use lower case for variable names, and all upper case for symbolic constants.

A character constant is an integer, written as one character within single quotes, such as 'x'. The value of a character constant is the numeric value of the character in the machine's character set. 

Arbitrary bit patterns stored in character variables may appear to be negative on some machines, yet positive on others. For portability, specify signed or unsigned if non-character data is to be stored in charvariables.

Casting allows for conversions of data types without changing the value of the variable itself (sqrt((double) n)
	• If n is an int, the above will convert it to a double before applying sqrt() to give a useful answer, but n is unchanged

Increment/Decrement operators (++/--) change depending on where they're placed (n=5):
	• X = ++n; means that x = 6 because the increment was applied before the assignment
	• X = n++; means that x = 5 because the increment  was applied after the assignment */