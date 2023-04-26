# C# String Class Documentation

## Table of Contents

- Introduction
- Creating Strings
- Common Properties
- Common Methods
- String Manipulation
- String Comparison

## Introduction
In C#, strings are objects of the System.String class. A string is a sequence of characters (letters, numbers, symbols, and whitespace) that can be used to represent text. Strings are immutable, which means that their content cannot be changed after they are created.

## Creating Strings
To create a string, you can use either double quotes or the @ symbol followed by double quotes for verbatim strings:

```
string simpleString = "Hello, world!";
string verbatimString = @"Hello, world!";
```

### Common Properties
Here are some common properties of the String class:

- Length: Returns the number of characters in the string.

```
string text = "Hello, world!";
int length = text.Length; // length = 13
```

- Chars: Retrieves the character at the specified index in the string.
```
string text = "Hello, world!";
char firstChar = text[0]; // firstChar = 'H'
```

## Common Methods
Here is a list of common methods associated with the String class:

- Concat: Concatenates one or more instances of String.

```
string text1 = "Hello";
string text2 = "world!";
string combined = String.Concat(text1, ", ", text2); // combined = "Hello, world!"
```

- Substring: Retrieves a substring from the specified string.
```
string text = "Hello, world!";
string substring = text.Substring(7, 5); // substring = "world"
```

- Replace: Replaces all occurrences of a specified string with another string.

```
string text = "Hello, world!";
string replaced = text.Replace("world", "C#"); // replaced = "Hello, C#!"
```

- ToUpper and ToLower: Converts the string to uppercase or lowercase.
```
string text = "Hello, world!";
string upper = text.ToUpper(); // upper = "HELLO, WORLD!"
string lower = text.ToLower(); // lower = "hello, world!"
```

- Trim: Removes all leading and trailing white-space characters from the string.
```
string text = "   Hello, world!   ";
string trimmed = text.Trim(); // trimmed = "Hello, world!"
```